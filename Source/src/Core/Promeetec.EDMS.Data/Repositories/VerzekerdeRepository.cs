using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Portaal.Data.Repositories
{
    public class VerzekerdeRepository : Repository<Verzekerde>, IVerzekerdeRepository
    {
        public VerzekerdeRepository(EDMSDbContext context)
            : base(context)
        {
        }

        public async Task<Verzekerde?> GetPossibleExisitingVerzekerde(Guid adresboekId, string voorletters, string achternaam, DateTime geboortedatum, string bsn)
        {
            await Task.CompletedTask;
            var verzekerde = Query()
                .AsNoTracking()
                .FirstOrDefault(x => x.AdresboekId == adresboekId &&
                            x.Persoon.Voorletters == voorletters &&
                            x.Persoon.Achternaam == achternaam &&
                            x.Persoon.Geboortedatum == geboortedatum &&
                            x.Bsn == bsn);

            return verzekerde;
        }


        public async Task<bool> IsPatientNummerUniqueAsync(Guid adresboekId, string nummer, Guid? verzekerdeId = default)
        {
            var verzekerdeIdByPatientNummer = await GetVerzekerdeIdByPatientNummerAsync(adresboekId, nummer);
            return verzekerdeIdByPatientNummer == Guid.Empty || verzekerdeId != default && verzekerdeIdByPatientNummer == verzekerdeId;
        }


        public async Task<bool> IsBsnUniqueAsync(Guid adresboekId, string bsn, Guid verzekerdeId = new Guid())
        {
            var id = await Query()
                .Where(x => x.Bsn == bsn && x.AdresboekId == adresboekId)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            return id == Guid.Empty || verzekerdeId != Guid.Empty && id == verzekerdeId;
        }

        public bool IsBsnUnique(Guid adresboekId, string bsn, Guid verzekerdeId = new Guid())
        {
            var verzekerdeIdByBsn = Query()
                .Where(x => x.Bsn == bsn && x.AdresboekId == adresboekId)
                .Select(x => x.Id)
                .FirstOrDefault();

            return verzekerdeIdByBsn == Guid.Empty || verzekerdeId != Guid.Empty && verzekerdeIdByBsn == verzekerdeId;
        }


        public async Task<Guid> GetVerzekerdeIdByPatientNummerAsync(Guid adresboekId, string nummer)
        {
            var id = await Query()
                .Where(x => x.Zorgverzekering.PatientNummer == nummer && x.AdresboekId == adresboekId)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
            return id;
        }

        public async Task<Guid> GetVerzekerdeIdByBsnAsync(Guid adresboekId, string bsn)
        {
            var id = await Query()
                .Where(x => x.Bsn == bsn && x.AdresboekId == adresboekId)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();
            return id;
        }

        public bool IsZorgprofielEindatumValid(Guid verzekerdeId, DateTime zorgprofielEinddatum)
        {
            var verzekerde = Query().Include(i => i.Zorgprofiel).FirstOrDefault(x => x.Id == verzekerdeId);
            var isValid = verzekerde != null && verzekerde.Zorgprofielen.Any(x => x.Zorgprofiel.ProfielEinddatum >= zorgprofielEinddatum);
            return !isValid;
        }

        public bool IsZorgprofielStartdatumValid(Guid verzekerdeId, DateTime zorgprofielStartdatum)
        {
            var verzekerde = Query().Include(i => i.Zorgprofiel).FirstOrDefault(x => x.Id == verzekerdeId);
            var isValid = verzekerde != null && verzekerde.Zorgprofielen.Any(x => x.Zorgprofiel.ProfielStartdatum >= zorgprofielStartdatum);
            return !isValid;
        }

        public DateTime GetLaatsteZorgprofielEinddatum(Guid verzekerdeId)
        {
            var verzekerde = Query().Include(i => i.Zorgprofiel).FirstOrDefault(x => x.Id == verzekerdeId);
            var profiel = verzekerde?.Zorgprofielen.LastOrDefault();
            if (profiel?.Zorgprofiel.ProfielEinddatum != null)
                return profiel.Zorgprofiel.ProfielEinddatum.Value;

            return default;
        }

        public DateTime GetLaatsteZorgprofielStartdatum(Guid verzekerdeId)
        {
            var verzekerde = Query().Include(i => i.Zorgprofiel).FirstOrDefault(x => x.Id == verzekerdeId);
            var profiel = verzekerde?.Zorgprofielen.LastOrDefault();
            if (profiel?.Zorgprofiel.ProfielStartdatum != null)
                return profiel.Zorgprofiel.ProfielStartdatum;

            return default;
        }
    }
}