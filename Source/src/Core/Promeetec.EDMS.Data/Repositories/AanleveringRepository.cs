using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

namespace Promeetec.EDMS.Data.Repositories;

public class AanleveringRepository : Repository<Aanlevering>, IAanleveringRepository
{
    public AanleveringRepository(EDMSDbContext context)
        : base(context)
    {
    }


    //public async Task<Aanlevering> GetAanleveringByIdAsync(Guid id)
    //{
    //    var dbEntity = await Query()
    //        .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Verwijderd);
    //    return dbEntity;
    //}

    //public async Task<Aanlevering> GetAanleveringByIdAsync(Guid id, bool includeAanleverbestanden = false, bool includeOverigebestanden = false, bool includeBerichten = false)
    //{
    //    var dbQuery = Query()
    //        .Include(i => i.Organisatie);

    //    dbQuery = dbQuery.Include(i => i.Aanleverbestanden);

    //    if (includeAanleverbestanden)
    //        dbQuery = dbQuery.Include(i => i.Aanleverbestanden);

    //    if (includeOverigebestanden)
    //        dbQuery = dbQuery.Include(i => i.Overigebestanden);

    //    if (includeBerichten)
    //        dbQuery = dbQuery.Include(i => i.Aanleverberichten);


    //    var dbEntity = await dbQuery.FirstOrDefaultAsync(x => x.Id == id);
    //    return dbEntity;
    //}

    //public async Task<Aanlevering> GetAanleveringForRemoveByIdAsync(Guid id)
    //{
    //    var dbQuery = await Query()
    //        .AsNoTracking()
    //        .Include(i => i.Aanleverbestanden)
    //        .Include(i => i.Overigebestanden)
    //        .Include(i => i.Aanleverberichten)
    //        .FirstOrDefaultAsync(x => x.Id == id);
    //    return dbQuery;
    //}

    //public IQueryable<Aanlevering> GetAanleveringenVanOrganisatie(Guid organisatieId)
    //{
    //    var dbQuery = Query()
    //        .AsNoTracking()
    //        .Include(i => i.Organisatie)
    //        .Include(i => i.Aanleverbestanden)
    //        .Include(i => i.Overigebestanden)
    //        .Include(i => i.Aanleverberichten)
    //        .Where(x => x.OrganisatieId == organisatieId);

    //    return dbQuery;
    //}

    //public async Task<string> GetReferentiePromeetecByIdAsync(Guid id)
    //{
    //    var dbEntity = await Query().FirstOrDefaultAsync(x => x.Id == id);
    //    return dbEntity?.ReferentiePromeetec;
    //}

    //public async Task<string> GetReferentieByMedewerkerSoortAsync(Guid aanleveringId, UserPrincipal user)
    //{
    //    var dbQuery = await Query()
    //        .AsNoTracking()
    //        .Where(x => x.Id == aanleveringId)
    //        .FirstOrDefaultAsync();

    //    return user.IsInterneMedewerker ? dbQuery?.ReferentiePromeetec : dbQuery?.Referentie;
    //}

    //public bool MagDocumentToevoegen(Guid aanleveringId)
    //{
    //    var toevoegenBestand = false;
    //    var aanlevering = GetById(aanleveringId);
    //    if (aanlevering != null)
    //        toevoegenBestand = aanlevering.ToevoegenBestand;

    //    return toevoegenBestand;
    //}

    //public async Task<bool> IsReferentiePromeetecUniqueAsnyc(Guid organisatieId, string referentiePromeetec)
    //{
    //    var dbQuery = await Query()
    //        .CountAsync(x => x.OrganisatieId == organisatieId &&
    //                         x.ReferentiePromeetec == referentiePromeetec);

    //    return dbQuery == 0;
    //}

    //public async Task<string> GetUniqueReferentiePromeetecAsync(Guid organisatieId, string organisatieNummer)
    //{
    //    var prefix = $"{organisatieNummer}-{DateTime.Now:yy}";
    //    var volgnr = BepaalVolgNummer(organisatieId);
    //    var referentiePromeetec = $"{prefix}{volgnr:d3}";

    //    var isUnique = await IsReferentiePromeetecUniqueAsnyc(organisatieId, referentiePromeetec);

    //    while (!isUnique)
    //    {
    //        volgnr++;
    //        referentiePromeetec = $"{prefix}{volgnr:d3}";
    //        isUnique = await IsReferentiePromeetecUniqueAsnyc(organisatieId, referentiePromeetec);
    //    }

    //    return referentiePromeetec;
    //}

    //public async Task<bool> IsMedewerkerEigenaarVanActiveAanleveringAsync(Guid medewerkerId)
    //{
    //    var isEigenaarVanActieveAanlevering = await Query()
    //        .AsNoTracking()
    //        .AnyAsync(x => x.EigenaarId == medewerkerId &&
    //                       x.AanleverStatus != AanleverStatus.Verwerkt &&
    //                       x.AanleverStatus != AanleverStatus.Afgekeurd);

    //    return isEigenaarVanActieveAanlevering;
    //}

    //public async Task<List<Aanlevering>> GetAanleveringenVanEigenaarAsync(Guid eigenaarId)
    //{
    //    var dbQuery = await Query()
    //        .Include(i => i.Aanleverbestanden)
    //        .Include(i => i.Overigebestanden)
    //        .AsNoTracking()
    //        .Where(x => x.EigenaarId == eigenaarId).ToListAsync();

    //    return dbQuery;
    //}

    //public async Task<int> GetAantalAanleveringenVanOrganisatieAsync(Guid organisatieId, bool actief, bool afgehandeld)
    //{
    //    var dbQuery = Query().AsNoTracking().Where(x => x.OrganisatieId == organisatieId);

    //    if (actief)
    //        dbQuery = dbQuery.Where(x => x.AanleverStatus != AanleverStatus.Afgekeurd && x.AanleverStatus != AanleverStatus.Verwerkt);

    //    if (afgehandeld)
    //        dbQuery = dbQuery.Where(x => x.AanleverStatus == AanleverStatus.Afgekeurd && x.AanleverStatus == AanleverStatus.Verwerkt);


    //    return await dbQuery.CountAsync();
    //}



    ///// <inheritdoc />
    //public List<string> GetAanleverbestandsnamen(Guid aanleveringId)
    //{
    //    var sql = @"SELECT 
    //                    B.FileName
    //                    FROM Aanlevering A
    //                    LEFT OUTER JOIN Aanleverbestand AB on AB.AanleveringId = A.Id
    //                    INNER JOIN Bestand B on B.Id = AB.Id
    //                    WHERE A.Id = @aanleveringId AND AB.WorkFlowState = '1'";

    //    return SqlQuery<string>(sql, new SqlParameter("@aanleveringId", aanleveringId)).ToList();
    //}

    ///// <inheritdoc />
    //public List<string> GetOverigebestandsnamen(Guid aanleveringId)
    //{
    //    var sql = @"SELECT 
    //                    B.FileName
    //                    FROM  Aanlevering A
    //                    LEFT OUTER JOIN Overigbestand OB on OB.AanleveringId = A.Id
    //                    INNER JOIN Bestand B on B.Id = OB.Id
    //                    WHERE A.Id = @aanleveringId";

    //    return SqlQuery<string>(sql, new SqlParameter("@aanleveringId", aanleveringId)).ToList();
    //}

    ///// <inheritdoc />
    //public List<string> GetAanleveringReferentiesPromeetec(Guid aanleveringId)
    //{
    //    var sql = @"SELECT
    //                    A.ReferentiePromeetec
    //                    FROM Aanlevering A
    //                    WHERE A.Id = @aanleveringId";

    //    return SqlQuery<string>(sql, new SqlParameter("@aanleveringId", aanleveringId)).ToList();
    //}

    ///// <inheritdoc />
    //public async Task<int> VerwijderAanleveringMetOnderliggendeRelaties(Guid aanleveringId)
    //{
    //    var sql = @"DECLARE @id  uniqueidentifier
    //                    SET @id = '" + aanleveringId + "'" + @"

    //                    -- // Events
    //                    DELETE DE
    //                    FROM [dbo].[DomainEvent] DE
    //                    LEFT OUTER JOIN [dbo].[Aanlevering] A on DE.[AggregateId] = A.[Id]
    //                    WHERE DE.[AggregateId] = @id

    //                    DELETE DC
    //                    FROM [dbo].[DomainCommand] DC
    //                    LEFT OUTER JOIN [dbo].[Aanlevering] A on DC.[AggregateId] = A.[Id]
    //                    WHERE DC.[AggregateId] = @id

    //                    DELETE DA
    //                    FROM [dbo].[DomainAggregate] DA
    //                    LEFT OUTER JOIN [dbo].[Aanlevering] A on DA.[Id] = A.[Id] 
    //                    WHERE DA.[Id] = @id


    //                    -- // Aanlevering (Overigbestand, aanleverbestand en aanleverbericht are cascase deleted)
    //                    DELETE  
    //                    FROM [dbo].[Aanlevering]
    //                    WHERE [Id] = @id
    //                ";

    //    return await RawSQLAsync(sql);
    //}

    //#region Private methods

    ///// <summary>
    /////     Maak uniek volgnummer voor huidige jaar voor aanlevering van organisatie.
    ///// </summary>
    //private int BepaalVolgNummer(Guid organisatieId)
    //{
    //    var result = Query().Count(x =>
    //        x.OrganisatieId == organisatieId &&
    //        x.Jaar == DateTime.Now.Year);

    //    return result + 1;
    //}

    //#endregion
    public Task<Aanlevering> GetAanleveringByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Aanlevering> GetAanleveringByIdAsync(Guid id, bool includeAanleverbestanden = false, bool includeOverigebestanden = false, bool includeBerichten = false)
    {
        throw new NotImplementedException();
    }

    public Task<Aanlevering> GetAanleveringForRemoveByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Aanlevering> GetAanleveringenVanOrganisatie(Guid organisatieId)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetReferentiePromeetecByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetReferentieByMedewerkerSoortAsync(Guid aanleveringId, UserPrincipal user)
    {
        throw new NotImplementedException();
    }

    public bool MagDocumentToevoegen(Guid aanleveringId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsReferentiePromeetecUniqueAsnyc(Guid organisatieId, string referentiePromeetec)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUniqueReferentiePromeetecAsync(Guid organisatieId, string organisatieNummer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsMedewerkerEigenaarVanActiveAanleveringAsync(Guid medewerkerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Aanlevering>> GetAanleveringenVanEigenaarAsync(Guid eigenaarId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetAantalAanleveringenVanOrganisatieAsync(Guid organisatieId, bool actief, bool afgehandeld)
    {
        throw new NotImplementedException();
    }

    public List<string> GetAanleverbestandsnamen(Guid aanleveringId)
    {
        throw new NotImplementedException();
    }

    public List<string> GetOverigebestandsnamen(Guid aanleveringId)
    {
        throw new NotImplementedException();
    }

    public List<string> GetAanleveringReferentiesPromeetec(Guid aanleveringId)
    {
        throw new NotImplementedException();
    }

    public Task<int> VerwijderAanleveringMetOnderliggendeRelaties(Guid aanleveringId)
    {
        throw new NotImplementedException();
    }
}