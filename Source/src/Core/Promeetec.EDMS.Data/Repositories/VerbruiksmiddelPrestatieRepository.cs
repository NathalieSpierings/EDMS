using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Extensions;

namespace Promeetec.EDMS.Data.Repositories;

public class VerbruiksmiddelPrestatieRepository : Repository<VerbruiksmiddelPrestatie>, IVerbruiksmiddelPrestatieRepository
{
    public VerbruiksmiddelPrestatieRepository(EDMSDbContext context)
        : base(context)
    {
    }

    /// <inheritdoc />
    public Dictionary<DateTime, DateTime> GetActiefZorgprofielPeriods(DateTime profielStartdatum, DateTime processDateLastDay)
    {
        // De einddatum wordt de laatste dag van de process
        var einddatum = processDateLastDay;

        var dic = new Dictionary<DateTime, DateTime>();
        for (var i = profielStartdatum; i <= einddatum; i = i.AddMonths(1).GetFirstDayOfMonth())
        {
            var lastDayOfMonth = i.GetLastDayOfMonth();
            dic.Add(i.Date, einddatum <= lastDayOfMonth ? einddatum : lastDayOfMonth);
        }

        return dic;
    }

    /// <inheritdoc />
    public async Task<bool> HasActiefZorgprofielRecordForProcessMonth(Guid organisatieId, DateTime processDate, Guid verzekerdeId, ProfielCode code, DateTime profielStartdatum)
    {
        var currentDateFirstDay = processDate.GetFirstDayOfMonth();
        var currentDateLastDay = processDate.GetLastDayOfMonth();

        var dbQuery = await Query().AsNoTracking()
            .Where(x => x.OrganisatieId == organisatieId
                        && x.Verzekerde.Id == verzekerdeId
                        && x.HulpmiddelenSoort == HulpmiddelenSoort.Profiel
                        && x.ProfielCode == code
                        && x.ProfielStartdatum == profielStartdatum
                        && x.ProfielEinddatum == currentDateLastDay).FirstOrDefaultAsync();

        if (dbQuery != null)
            return true;

        return false;
    }

    /// <inheritdoc />
    public async Task<bool> HasActiefZorgprofielRecordForPeriod(Guid organisatieId, DateTime startDate, DateTime endDate, Guid verzekerdeId, ProfielCode code)
    {
        var dbQuery = await Query().AsNoTracking()
            .Where(x => x.OrganisatieId == organisatieId
                        && x.Verzekerde.Id == verzekerdeId
                        && x.HulpmiddelenSoort == HulpmiddelenSoort.Profiel
                        && x.ProfielCode == code
                        && x.ProfielStartdatum == startDate
                        && x.ProfielEinddatum == endDate).FirstOrDefaultAsync();

        if (dbQuery != null)
            return true;

        return false;
    }




    public Dictionary<DateTime, DateTime> GetHistoryZorgprofielPeriods(DateTime profielStartdatum, DateTime profielEinddatum, DateTime processDateLastDay)
    {
        // De einddatum wordt of de laaste dag van de process maand of de profiel einddatum
        var einddatum = profielEinddatum >= processDateLastDay ? processDateLastDay : profielEinddatum;

        var dic = new Dictionary<DateTime, DateTime>();
        for (var i = profielStartdatum; i <= einddatum; i = i.AddMonths(1).GetFirstDayOfMonth())
        {
            var lastDayOfMonth = i.GetLastDayOfMonth();
            dic.Add(i.Date, einddatum <= lastDayOfMonth ? einddatum : lastDayOfMonth);
        }

        return dic;
    }

    public async Task<bool> HasHistoryZorgprofielRecordForPeriod(Guid organisatieId, DateTime startDate, DateTime endDate, Guid verzekerdeId, ProfielCode code)
    {
        var dbQuery = await Query().AsNoTracking()
            .Where(x => x.OrganisatieId == organisatieId
                        && x.Verzekerde.Id == verzekerdeId
                        && x.HulpmiddelenSoort == HulpmiddelenSoort.Profiel
                        && x.ProfielCode == code
                        && x.ProfielStartdatum == startDate
                        && x.ProfielEinddatum == endDate).FirstOrDefaultAsync();

        if (dbQuery != null)
            return true;

        return false;
    }

    public async Task<bool> HasHistoryZorgprofielRecordForMonth(Guid organisatieId, Guid verzekerdeId, ProfielCode code, DateTime profielStartdatum, DateTime profielEinddatum)
    {
        var dbQuery = await Query().AsNoTracking()
            .Where(x => x.OrganisatieId == organisatieId
                        && x.Verzekerde.Id == verzekerdeId
                        && x.HulpmiddelenSoort == HulpmiddelenSoort.Profiel
                        && x.ProfielCode == code
                        && x.ProfielStartdatum == profielStartdatum
                        && x.ProfielStartdatum <= profielEinddatum).FirstOrDefaultAsync();

        if (dbQuery != null)
            return true;

        return false;
    }



    /// <inheritdoc />
    public async Task<bool> PresatieExistAsync(Guid verzekerdeId, DateTime prestatieDatum, int zIndex, int hoeveelheid)
    {
        var dbQuery = await Query()
            .Where(x => x.VerzekerdeId == verzekerdeId && x.PrestatieDatum == prestatieDatum && x.ZIndex == zIndex && x.Hoeveelheid == hoeveelheid)
            .ToListAsync();

        if (dbQuery.Any())
            return true;

        return false;
    }
}