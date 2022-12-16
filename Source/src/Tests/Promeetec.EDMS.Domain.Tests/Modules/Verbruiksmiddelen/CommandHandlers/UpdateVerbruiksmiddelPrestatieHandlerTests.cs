using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Handlers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Verbruiksmiddelen.CommandHandlers;


[TestFixture]
public class UpdateVerbruiksmiddelPrestatieHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IVerbruiksmiddelPrestatieRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new VerbruiksmiddelPrestatieRepository(_context);
    }

    [Test]
    public async Task Should_update_prestatie()
    {
        var cmd = Fixture.Build<CreateVerbruiksmiddelPrestatie>()
            .With(x => x.Id, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var prestatie = new VerbruiksmiddelPrestatie(cmd);
        _context.VerbruiksmiddelPrestaties.Add(prestatie);
        await _context.SaveChangesAsync();

        var command = Fixture.Build<UpdateVerbruiksmiddelPrestatie>()
            .With(x => x.Id, prestatie.Id)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();


        var validator = new Mock<IValidator<UpdateVerbruiksmiddelPrestatie>>();
        validator.Setup(x => x.ValidateAsync(command, new CancellationToken())).ReturnsAsync(new ValidationResult());

        var sut = new UpdateVerbruiksmiddelPrestatieHandler(_repository, validator.Object);
        await sut.Handle(command);

        var dbEntity = await _context.VerbruiksmiddelPrestaties.FirstOrDefaultAsync(x => x.Id == prestatie.Id);

        validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));

        Assert.NotNull(dbEntity);
        Assert.AreEqual(command.AgbCodeOnderneming, dbEntity?.AgbCodeOnderneming);
    }
}