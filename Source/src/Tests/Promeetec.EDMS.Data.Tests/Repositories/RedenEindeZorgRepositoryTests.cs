using NUnit.Framework;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Data.Repositories;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.RedenEindeZorg;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;
using Promeetec.EDMS.Portaal.Tests.Helpers;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Data.Tests.Repositories;

[TestFixture]
public class RedenEindeZorgRepositoryTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IRedenEindeZorgRepository _sut;

    [SetUp]
    public void SetUp()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _sut = new RedenEindeZorgRepository(_context);
    }

    [Test]
    public async Task Should_get_code_en_omschrijving_by_id()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var id3 = Guid.NewGuid();

        _context.Set<RedenEindeZorg>().AddRange(
            new RedenEindeZorg
            {
                Id = id1,
                Code = "1",
                Omschrijving = "Lorum ipsum 1",
                Status = Status.Actief
            },
            new RedenEindeZorg
            {
                Id = id2,
                Code = "2",
                Omschrijving = "Lorum ipsum 2",
                Status = Status.Actief
            },
            new RedenEindeZorg
            {
                Id = id3,
                Code = "3",
                Omschrijving = "Lorum ipsum 3",
                Status = Status.Inactief
            }
        );

        await _context.SaveChangesAsync();

        var actual = await _sut.GetCodeEnOmschrijvingByIdAsync(id2);
        Assert.NotNull(actual);

        var actual1 = await _sut.GetCodeEnOmschrijvingByIdAsync(id3);
        Assert.IsEmpty(actual1);
    }
}
