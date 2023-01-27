using System.Globalization;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Tests;

[TestFixture]
public class DbSeed
{
    private string ConnectionString = "Server=.;Database=Promeetec.EDMS.DOTCore;Trusted_Connection=True; Encrypt=False;MultipleActiveResultSets=true";
    private EDMSDbContext _context;
    private Medewerker _admin;
    private Guid _adminId;
    private Land _nederland;

    [SetUp]
    public void SetUp()
    {
        _adminId = Guid.NewGuid();
        _context = new EDMSDbContext(new DbContextOptionsBuilder<EDMSDbContext>().UseSqlServer(ConnectionString).Options);
    }

    [Test]
    public void Seed()
    {
        var landen = AddCountries();
        _nederland = landen.FirstOrDefault(x => x.NativeName == "Nederland");

        AddPromeetec();
    }

    private List<Land> AddCountries()
    {
        if (_context.Landen.FirstOrDefault() == null)
        {
            var codes = new List<string>
            {
                "nl-NL",
                "nl-BE",
                "de-DE"
            };

            var countries = GetCountriesByCode(codes);
            foreach (var country in countries)
            {
                var land = new Land
                {
                    CultureCode = country.Name,
                    NativeName = country.NativeName,
                    Status = Status.Actief
                };
                _context.Landen.Add(land);
            }

            _context.SaveChanges();
        }

        return _context.Landen.ToList();
    }
    private List<RegionInfo> GetCountriesByCode(List<string> codes)
    {
        var countries = new List<RegionInfo>();
        if (codes is { Count: > 0 })
        {
            foreach (var code in codes)
            {
                try
                {
                    countries.Add(new RegionInfo(code));
                }
                catch
                {
                    // Ignores the invalid culture code.
                }
            }
        }

        return countries.OrderBy(p => p.NativeName).ToList();
    }


    private Organisatie AddPromeetec()
    {
        var promeetec = _context.Organisaties.FirstOrDefault(x => x.Nummer == "0000");
        if (promeetec == null)
        {
            var adresboekId = Guid.NewGuid();
            promeetec = new Organisatie
            {
                Id = Guid.Parse("7b1cd428-7b47-4ca4-9cfc-0dd1f1dac33f"),
                Nummer = "0000",
                Naam = "Promeetec",
                AgbCodeOnderneming = "98098352",
                Zorggroep = false,
                TelefoonZakelijk = "0402300392",
                Email = "info@promeetec.nl",
                Website = "https://promeetec.nl",
                Status = Status.Actief,
                ContactpersoonId = null,
                AdresboekId = adresboekId,
                Adresboek = new Adresboek { Id = adresboekId },
                Settings = new OrganisatieSettings
                {
                    AanleverStatusNaSchrijvenAanleverbestanden = AanleverStatusNaSchrijvenAanleverbestanden.Onbekend,
                    VerwijzerInAdresboek = VerwijzerInAdresboekType.VerwijzerNietZichtbaar
                },
                Adres = new Adres
                {
                    Straat = "Luchthavenweg",
                    Huisnummer = "81",
                    Huisnummertoevoeging = "101",
                    Postcode = "5657 EA",
                    Woonplaats = "Eindhoven",
                    LandId = _nederland.Id
                }
            };
            _context.Organisaties.Add(promeetec);
            _context.SaveChanges();
        }
        return promeetec;
    }
}
