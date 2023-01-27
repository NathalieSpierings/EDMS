using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class GliIntakeRepository : Repository<GliIntake>, IGliIntakeRepository
{
    public GliIntakeRepository(EDMSDbContext context)
        : base(context)
    {
    }

    /// <inheritdoc />
    public async Task<bool> IntakeExistAsync(Guid verzekerdeId, DateTime intakeDatum)
    {
        var dbQuery = await Query().AsNoTracking().Where(x => x.Verzekerde.Id == verzekerdeId && x.IntakeDatum == intakeDatum).ToListAsync();
        if (dbQuery.Any())
            return true;

        return false;
    }

    /// <inheritdoc />
    public async Task<List<GliDto>> GetIntakeVoorVerwerkingAsync(Guid organisatieId, List<Guid> ids)
    {
        var dbQuery = await Query().AsNoTracking()
            .Include(i => i.Organisatie)
            .Include(i => i.Behandelaar)
            .Include(i => i.Verzekerde)
            .Include(i => i.Verzekerde.Zorgverzekering.Verzekeraar)
            .Where(x => ids.Contains(x.Id) && x.OrganisatieId == organisatieId)
            .Select(x => new GliDto
            {
                IntakeId = x.Id,
                OrganisatieId = x.OrganisatieId,
                OrganisatieNummer = x.Organisatie.Nummer,
                OrganisatieNaam = x.Organisatie.Naam,
                Bsn = x.Verzekerde.Bsn,
                Geslacht = x.Verzekerde.Persoon.Geslacht.ToString(),
                Geboortedatum = x.Verzekerde.Persoon.Geboortedatum!.Value,
                Voorletters = x.Verzekerde.Persoon.Voorletters,
                Tussenvoegsel = x.Verzekerde.Persoon.Tussenvoegsel,
                Achternaam = x.Verzekerde.Persoon.Achternaam,
                AgbCodeVerwijzer = x.Verzekerde.AgbCodeVerwijzer,
                NaamVerwijzer = x.Verzekerde.NaamVerwijzer,
                Uzovi = x.Verzekerde.Zorgverzekering.Verzekeraar.Uzovi,
                IntakeDatum = x.IntakeDatum,
                IntakeOpmerking = x.Opmerking,
                BehandelaarVolledigeNaam = x.Behandelaar.Persoon.VolledigeNaam,
                AangemaaktOp = DateTime.Now
            }).ToListAsync();

        return dbQuery;
    }
}