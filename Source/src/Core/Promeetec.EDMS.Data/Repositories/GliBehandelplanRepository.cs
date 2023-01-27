using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan;
using GliStatus = Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.GliStatus;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class GliBehandelplanRepository : Repository<GliBehandelplan>, IGliBehandelplanRepository
{
    public GliBehandelplanRepository(EDMSDbContext context)
        : base(context)
    {
    }

    /// <inheritdoc />
    public async Task<bool> BehandelplanExistAsync(Guid verzekerdeId, GliBehandelfase fase)
    {
        var dbQuery = await Query().AsNoTracking().Where(x => x.VerzekerdeId == verzekerdeId && x.Fase == fase).ToListAsync();
        if (dbQuery.Any())
            return true;

        return false;
    }

    /// <inheritdoc />
    public async Task<List<GliBehandelplan>> GetBehandelplannenVanTraject(Guid intakeId)
    {
        return await Query().AsNoTracking().Where(x => x.IntakeId == intakeId).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<List<GliDto>> GetBehandelplanVoorVerwerkingAsync(Guid organisatieId, List<Guid> ids)
    {
        var dbQuery = await Query().AsNoTracking()
            .Include(i => i.Organisatie)
            .Include(i => i.Behandelaar)
            .Include(i => i.Verzekerde)
            .Include(i => i.Verzekerde.Zorgverzekering.Verzekeraar)
            .Where(x => ids.Contains(x.Id) && x.OrganisatieId == organisatieId)
            .Select(x => new GliDto
            {
                OrganisatieId = x.OrganisatieId,
                OrganisatieNummer = x.Organisatie.Nummer,
                OrganisatieNaam = x.Organisatie.Naam,
                BehandelaarVolledigeNaam = x.Behandelaar.Persoon.VolledigeNaam,
                Bsn = x.Verzekerde.Bsn,
                Geslacht = x.Verzekerde.Persoon.Geslacht.ToString(),
                Geboortedatum = x.Verzekerde.Persoon.Geboortedatum!.Value,
                Voorletters = x.Verzekerde.Persoon.Voorletters,
                Tussenvoegsel = x.Verzekerde.Persoon.Tussenvoegsel,
                Achternaam = x.Verzekerde.Persoon.Achternaam,
                AgbCodeVerwijzer = x.Verzekerde.AgbCodeVerwijzer,
                NaamVerwijzer = x.Verzekerde.NaamVerwijzer,
                Uzovi = x.Verzekerde.Zorgverzekering.Verzekeraar.Uzovi,
                IntakeId = x.IntakeId,
                BehandelplanId = x.Id,
                Fase = x.Fase.ToString(),
                StartdatumBehandelplan = x.Startdatum,
                EinddatumBehandelplan = x.Einddatum,
                GliProgramma = x.GliProgramma.ToString(),
                GliStatus = x.GliStatus.ToString(),
                OpmerkingBehandelplan = x.Opmerking,
                VoortijdigGestopt = x.VoortijdigGestopt,
                VoortijdigeStopdatum = x.VoortijdigeStopdatum,
                CodeRedenEindeZorg = x.RedenEindeZorg.Code,
                OmschrijvingRedenEindeZorg = x.RedenEindeZorg.Omschrijving,
                AangemaaktOp = DateTime.Now
            }).ToListAsync();

        return dbQuery;
    }

    /// <inheritdoc />
    public async Task<List<GliBehandelplan>> GetBehandelplannenVoorAutomatischeVerwerking(DateTime date)
    {
        var behandelplannen = await Query()
            .AsNoTracking()
            .Include(i => i.Organisatie)
            .Include(i => i.Behandelaar)
            .Include(i => i.Verzekerde)
            .Include(i => i.Verzekerde.Zorgverzekering.Verzekeraar)
            .Where(x => x.Startdatum == date
                        && x.Einddatum == date
                        && x.GliStatus == GliStatus.NogNietGestart
                        && x.GliStatus != GliStatus.Gestart)
            .ToListAsync();

        return behandelplannen;
    }
}