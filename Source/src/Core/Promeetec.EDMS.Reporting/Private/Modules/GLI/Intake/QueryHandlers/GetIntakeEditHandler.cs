using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.WeegMoment;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Betrokkene.WeegMoment.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.QueryHandlers;

public class GetIntakeEditHandler : IQueryHandlerAsync<GetIntakeEdit, EditIntakeViewModel>
{
    private readonly IGliIntakeRepository _repository;
    private readonly IWeegMomentRepository _weegMomentRepository;

    public GetIntakeEditHandler(IGliIntakeRepository repository, IWeegMomentRepository weegMomentRepository)
    {
        _repository = repository;
        _weegMomentRepository = weegMomentRepository;
    }

    public async Task<EditIntakeViewModel> HandleAsync(GetIntakeEdit query)
    {
        var model = await _repository.Query().AsNoTracking()
            .Include(i => i.Organisatie)
            .Include(i => i.Behandelaar)
            .Include(i => i.Verzekerde)
            .Include(i => i.Verzekerde.WeegMomenten)
            .Where(x => x.Id == query.IntakeId)
            .Select(x => new EditIntakeViewModel
            {
                Id = x.Id,
                OrganisatieId = query.OrganisatieId,
                VerzekerdeId = x.VerzekerdeId,
                IntakeDatum = x.IntakeDatum,
                Opmerking = x.Opmerking,
                BehandelaarId = x.BehandelaarId,
                Behandelaar = new MedewerkerViewModel
                {
                    Id = x.BehandelaarId,
                    VolledigeNaam = x.Behandelaar.Persoon.VolledigeNaam
                },
                Verzekerde = new VerzekerdeViewModel
                {
                    Id = x.VerzekerdeId,
                    AgbCodeVerwijzer = x.Verzekerde.AgbCodeVerwijzer,
                    NaamVerwijzer = x.Verzekerde.NaamVerwijzer,
                    Lengte = x.Verzekerde.Lengte,
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = x.OrganisatieId,
                    },
                    FormeleNaam = x.Verzekerde.Persoon.FormeleNaam,
                    VolledigeNaam = x.Verzekerde.Persoon.VolledigeNaam,
                    Achternaam = x.Verzekerde.Persoon.Achternaam,
                    WeegMomenten = x.Verzekerde.WeegMomenten
                }
            }).FirstOrDefaultAsync();

        if (model.Verzekerde != null)
        {
            var weegmoment = await _weegMomentRepository.GetLaasteWeegmomentVanVerzekerdeAsync(model.Verzekerde.Id);
            model.WeegMoment = new WeegMomentCreateViewModel
            {
                Id = weegmoment.Id,
                VerzekerdeId = weegmoment.VerzekerdeId.Value,
                Gewicht = weegmoment.Gewicht,
                Lengte = weegmoment.Verzekerde.Lengte,
                Opnamedatum = weegmoment.Opnamedatum
            };
        }

        return model;
    }
}