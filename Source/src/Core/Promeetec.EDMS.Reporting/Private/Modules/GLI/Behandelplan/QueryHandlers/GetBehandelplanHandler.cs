using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Domain.Registratie.Gli.Behandelplan;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Persoon.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Queries;
using Promeetec.EDMS.Reporting.Registratie.GLI.Behandelplan.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.QueryHandlers
{
    public class GetBehandelplanHandler : IQueryHandlerAsync<GetBehandelplan, BehandelplanViewModel>
    {
        private readonly IGliBehandelplanRepository _repository;

        public GetBehandelplanHandler(IGliBehandelplanRepository repository)
        {
            _repository = repository;
        }

        public async Task<BehandelplanViewModel> HandleAsync(GetBehandelplan query)
        {
            var model = await _repository.Query().AsNoTracking()
                .Where(x => x.Id == query.BehandelplanId)
                .Select(x => new BehandelplanViewModel
                {
                    Id = x.Id,
                    OrganisatieId = query.OrganisatieId,
                    Startdatum = x.Startdatum,
                    Einddatum = x.Einddatum,
                    GliProgramma = x.GliProgramma,
                    Fase = x.Fase,
                    Opmerking = x.Opmerking,
                    VoortijdigGestopt = x.VoortijdigGestopt,
                    VoortijdigeStopdatum = x.VoortijdigeStopdatum,
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
                        OrganisatieId = query.OrganisatieId,
                        Persoon = new PersoonViewModel
                        {
                            Voorletters = x.Verzekerde.Persoon.Voorletters,
                            Voornaam = x.Verzekerde.Persoon.Voornaam,
                            Tussenvoegsel = x.Verzekerde.Persoon.Tussenvoegsel,
                            Achternaam = x.Verzekerde.Persoon.Achternaam,
                            FormeleNaam = x.Verzekerde.Persoon.FormeleNaam,
                            VolledigeNaam = x.Verzekerde.Persoon.VolledigeNaam,
                        }
                    }
                }).FirstOrDefaultAsync();

            return model;
        }
    }
}