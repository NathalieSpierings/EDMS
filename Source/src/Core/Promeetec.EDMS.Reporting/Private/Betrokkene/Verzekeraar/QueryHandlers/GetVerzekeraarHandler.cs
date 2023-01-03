using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.QueryHandlers;

public class GetVerzekeraarHandler : IQueryHandlerAsync<GetVerzekeraar, VerzekeraarViewModel>
{
    private readonly IVerzekeraarRepository _repository;

    public GetVerzekeraarHandler(IVerzekeraarRepository repository)
    {
        _repository = repository;
    }

    public async Task<VerzekeraarViewModel> HandleAsync(GetVerzekeraar query)
    {
        var model = await _repository.Query()
            .AsNoTracking()
            .Where(x => x.Id == query.VerzekeraarId)
            .Select(x => new VerzekeraarViewModel
            {
                Id = x.Id,
                Uzovi = x.Uzovi,
                Naam = x.Naam,
                Actief = x.Actief
            }).FirstOrDefaultAsync();

        return model;
    }
}