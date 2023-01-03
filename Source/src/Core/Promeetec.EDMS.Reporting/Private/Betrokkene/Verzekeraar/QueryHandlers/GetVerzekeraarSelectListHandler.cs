using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.QueryHandlers;

public class GetVerzekeraarSelectListHandler : IQueryHandlerAsync<GetVerzekeraarSelectList, VerzekeraarSelectList>
{
    private readonly IVerzekeraarRepository _repository;

    public GetVerzekeraarSelectListHandler(IVerzekeraarRepository repository)
    {
        _repository = repository;
    }

    public async Task<VerzekeraarSelectList> HandleAsync(GetVerzekeraarSelectList query)
    {
        var dbQuery = await _repository.Query()
            .AsNoTracking()
            .Where(x => x.Actief)
            .OrderBy(o => o.Naam)
            .Select(x => new
            {
                x.Id,
                Value = string.Concat(x.Naam, " (", x.Uzovi, ")")
            }).ToListAsync();

        return new VerzekeraarSelectList
        {
            Verzekeraars = new SelectList(dbQuery, "Id", "Value")
        };
    }
}