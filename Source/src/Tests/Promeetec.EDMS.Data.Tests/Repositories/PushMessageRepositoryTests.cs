using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Document.Rapportage;
using Promeetec.EDMS.Domain.Models.Document.Rapportage.Commands;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Data.Tests.Repositories;

[TestFixture]
public class PushMessageRepositoryTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IPushMessageRepository _sut;

    [SetUp]
    public void SetUp()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _sut = new PushMessageRepository(_context);
    }

    [Test]
    public async Task Should_get_pushmessage_by_id()
    {
        var cmd = Fixture.Create<CreateOrganisatie>();
        var organisatie = new Organisatie(cmd);
        _context.Organisaties.Add(organisatie);
        await _context.SaveChangesAsync();

        var cmdUser = Fixture.Build<CreateMedewerker>()
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .Create();

        var user = new Medewerker(cmdUser);
        _context.Medewerkers.Add(user);
        await _context.SaveChangesAsync();

        //var pushMessage = _context.PushMessages.Add(new PushMessage{
        //    Id = Guid.NewGuid(),
        //    Title = "Test message",
        //    Message = "The message content",
        //    Users = new 
        //});

        var cmdPushmsg = Fixture.Build<CreatePushMessage>()
            .With(x => x.OrganisatieId, organisatie.Id)
            .With(x => x.GroupIds, new List<Guid>{user.Id})
            .Create();
        var pushMessage = new PushMessage(cmdPushmsg);
        _context.PushMessages.Add(pushMessage);
        await _context.SaveChangesAsync();
        
        var actual = await _sut.GetPushmessageByIdAsync(pushMessage.Id);
        Assert.NotNull(actual);
    }
}
