using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Verzekeraar.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.QueryHandlers;

public class GetVerzekeraarsHandler : IQueryHandlerAsync<GetVerzekeraars, VerzekeraarsViewModel>
{
    private readonly IVerzekeraarRepository _repository;

    public GetVerzekeraarsHandler(IVerzekeraarRepository repository)
    {
        _repository = repository;
    }

    public async Task<VerzekeraarsViewModel> HandleAsync(GetVerzekeraars query)
    {
        var model = new VerzekeraarsViewModel();

        var dbQuery = _repository.Query().AsNoTracking();
        dbQuery = query.IncludeInactive
            ? dbQuery
            : dbQuery.Where(x => x.Actief);


        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                dbQuery = dbQuery.Where(x => x.Uzovi.ToString().Trim().Contains(match) ||
                                             x.Naam.Contains(match));
            }
        }

        var items = dbQuery.Select(x => new VerzekeraarViewModel
        {
            Id = x.Id,
            Uzovi = x.Uzovi,
            Naam = x.Naam,
            Actief = x.Actief
        });

        model.Verzekeraars = await items
            .OrderBy(o => o.Naam)
            .ToListAsync();

        return model;
    }
}