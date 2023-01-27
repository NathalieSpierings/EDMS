﻿using System.Security.Claims;
using System.Security.Principal;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Core.Queries;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Portaal.Reporting.Public.User.Models;
using Promeetec.EDMS.Portaal.Reporting.Public.User.Queries;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Reporting.Tests.Public;

[TestFixture]
public class GetCurrentUserHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private Mock<IHttpContextAccessor> _httpContextAccessor;
    private IMedewerkerRepository _repository;
    private IQueryHandler<GetCurrentUser, CurrentUserModel> _sut;


    [SetUp]
    public void SetUp()
    {
        _context = new EDMSDbContext(Promeetec.EDMS.Tests.Helpers.Shared.CreateContextOptions());
        _httpContextAccessor = new Mock<IHttpContextAccessor>();
        _repository = new MedewerkerRepository(_context);
    }

    [Test]
    public async Task Should_get_current_user()
    {
        var userId = Guid.NewGuid();

        var cmdOrg = Fixture.Create<CreateOrganisatie>();
        var organisatie = new Organisatie(cmdOrg);
        _context.Organisaties.Add(organisatie);
        await _context.SaveChangesAsync();

        // Create user
        var cmd = Fixture.Build<CreateMedewerker>()
            .With(x => x.UserId, userId)
            .With(x => x.OrganisatieId, organisatie.Id)
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .Create();

        var medewerker = new Medewerker(cmd);
        _context.Medewerkers.Add(medewerker);
        await _context.SaveChangesAsync();

        // Fake identity
        var fakeIdentity = new GenericIdentity("User");
        fakeIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, medewerker.Id.ToString()));
        fakeIdentity.AddClaim(new Claim(ClaimTypes.Name, "TestUser"));

        var principal = new GenericPrincipal(fakeIdentity, null);
        _httpContextAccessor.Setup(x => x.HttpContext.User).Returns(principal);

        _sut = new GetCurrentUserHandler(_httpContextAccessor.Object, _repository);

        var currentUser = await _sut.Handle(new GetCurrentUser());
        Assert.IsNotNull(currentUser);
    }
}
