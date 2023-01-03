using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Domain.Declaratie.ION;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Declaratie.ION.Models;
using Promeetec.EDMS.Reporting.Private.Modules.ION.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.QueryHandlers
{
    public class GetAangeleverdeIONPopulatieHandler : IQueryHandlerAsync<GetAangeleverdeIONPopulatie, AangeleverdeIONPopulatieListItemViewModel>
    {
        private readonly IIONPopulatieRepository _repository;
        private readonly IMedewerkerRepository _medewerkerRepository;
        public GetAangeleverdeIONPopulatieHandler(IIONPopulatieRepository repository, IMedewerkerRepository medewerkerRepository)
        {
            _repository = repository;
            _medewerkerRepository = medewerkerRepository;
        }

        public async Task<AangeleverdeIONPopulatieListItemViewModel> HandleAsync(GetAangeleverdeIONPopulatie query)
        {
            var model = new AangeleverdeIONPopulatieListItemViewModel
            {
                MedewerkerId = query.MedewerkerId,
                OrganisatieId = query.OrganisatieId,
                Periode = query.Peildatum,
                FormeleNaam = await _medewerkerRepository.GetFormeleNaamByIdAsync(query.MedewerkerId),
            };

            var dbQuery = _repository.Query()
                .AsNoTracking()
                .Where(x => x.MedewerkerId == query.MedewerkerId && x.Periode == query.Peildatum);

            model.AantalPatientRelaties = await dbQuery.CountAsync();

            return model;
        }
    }
}