using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Data.Tests.Repositories;

[TestFixture]
public class AdresboekRepositoryTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IAdresboekRepository _sut;

    [SetUp]
    public void SetUp()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _sut = new AdresboekRepository(_context);
    }

    [Test]
    public async Task Should_get_adresboek_with_verzekerden()
    {
        var cmd = Fixture.Create<CreateOrganisatie>();
        var organisatie = new Organisatie(cmd);
        _context.Organisaties.Add(organisatie);
        await _context.SaveChangesAsync();

        _context.Verzekerden.AddRange(
            new Verzekerde
            {
                Id = Guid.NewGuid(),
                Bsn = "999999999",
                Persoon = new Persoon
                {
                    Voorletters = "P",
                    Achternaam = "Van puffelen",
                    Email = "pvan@puffelen.nl"
                },
                AgbCodeVerwijzer = "00000000",
                NaamVerwijzer = "Udeverwijzer",
                AangemaaktDoorId = Guid.NewGuid(),
                AangemaaktDoor = "AdeAdmin",
                AdresboekId = organisatie.AdresboekId
            },
            new Verzekerde
            {
                Id = Guid.NewGuid(),
                Bsn = "999999999",
                Persoon = new Persoon
                {
                    Voorletters = "A",
                    Achternaam = "Cornelissen",
                    Email = "annie@cornelissen.nl"
                },
                AgbCodeVerwijzer = "00000000",
                NaamVerwijzer = "Udeverwijzer",
                AangemaaktDoorId = Guid.NewGuid(),
                AangemaaktDoor = "AdeAdmin",
                AdresboekId = organisatie.AdresboekId
            }
        );
        await _context.SaveChangesAsync();

        var actual = await _sut.GetAdresboekWithVerzekerdenAsync(organisatie.AdresboekId);
        Assert.NotNull(actual);
    }
}
