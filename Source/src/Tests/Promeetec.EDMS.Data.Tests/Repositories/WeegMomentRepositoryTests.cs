using AutoFixture;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Zorgverzekering;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Data.Tests.Repositories;

[TestFixture]
public class WeegmomentRepositoryTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IWeegmomentRepository _sut;

    [SetUp]
    public void SetUp()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _sut = new WeegmomentRepository(_context);
    }

    [Test]
    public async Task Should_get_weegmometen_van_verzekerde()
    {
        var cmd = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgprofiel, Fixture.Build<Zorgprofiel>()
                .Without(x => x.Verzekerden)
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var verzekerde = new Verzekerde(cmd);
        _context.Verzekerden.Add(verzekerde);
        await _context.SaveChangesAsync();

        var command = Fixture.Create<CreateWeegmoment>();
        var weegmoment = new Weegmoment(command);
        _context.Weegmomenten.Add(weegmoment);
        await _context.SaveChangesAsync();

        var actual = await _sut.GetWeegmomentenVanVerzekerdeAsync(verzekerde.Id);
        Assert.NotNull(actual);
    }

    [Test]
    public async Task Should_get_laatste_weegmomet_van_verzekerde()
    {
        var cmd = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgprofiel, Fixture.Build<Zorgprofiel>()
                .Without(x => x.Verzekerden)
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var verzekerde = new Verzekerde(cmd);
        _context.Verzekerden.Add(verzekerde);
        await _context.SaveChangesAsync();

        _context.Set<Weegmoment>().AddRange(
            new Weegmoment
            {
                Id = Guid.NewGuid(),
                VerzekerdeId = verzekerde.Id,
                Opnamedatum = DateTime.Now.AddDays(-5),
                Gewicht = 75
            },
            new Weegmoment
            {
                Id = Guid.NewGuid(),
                VerzekerdeId = verzekerde.Id,
                Opnamedatum = DateTime.Now.AddDays(-4),
                Gewicht = 70
            },
            new Weegmoment
            {
                Id = Guid.NewGuid(),
                VerzekerdeId = verzekerde.Id,
                Opnamedatum = DateTime.Now.AddDays(-3),
                Gewicht = 65
            }
        );

        await _context.SaveChangesAsync();
        
        var actual = await _sut.GetLaasteWeegmomentVanVerzekerdeAsync(verzekerde.Id);
        Assert.NotNull(actual);
    }
}
