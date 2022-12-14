using System.Net.Mail;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Data.Repositories;

public class MedewerkerRepository : Repository<Medewerker>, IMedewerkerRepository
{
    public MedewerkerRepository(EDMSDbContext context)
        : base(context)
    {
    }



    ///// <inheritdoc />
    //public async Task<Medewerker> GetMedewerkerByIdAsync(Guid id)
    //{
    //    var dbEntity = await Query()
    //        .Include(i => i.Organisatie)
    //        .Include(i => i.UserProfile)
    //        .Include(i => i.Adres)
    //        .FirstOrDefaultAsync(x => x.Id == id && x.Status != Status.Verwijderd);
    //    return dbEntity;
    //}


    ///// <inheritdoc />
    //public async Task<List<string>> GetAgbCodesZorgverlenerAsync(Guid medewerkerId)
    //{
    //    var dbEntity = await Query().FirstOrDefaultAsync(x => x.Id == medewerkerId);
    //    return dbEntity?.AgbCodeZorgverlener?.Split(',').ToList() ?? new List<string>();
    //}

    ///// <inheritdoc />
    //public async Task<List<string>> GetAgbCodesOndernemingAsync(Guid medewerkerId)
    //{
    //    var dbEntity = await Query().FirstOrDefaultAsync(x => x.Id == medewerkerId);
    //    return dbEntity?.AgbCodeOnderneming?.Split(',').ToList() ?? new List<string>();
    //}


    ///// <inheritdoc />
    //public async Task<Medewerker> GetByUserNameAsync(string userName)
    //{
    //    var dbEntity = await Query().FirstOrDefaultAsync(x => x.UserName == userName && x.Status != Status.Verwijderd);
    //    return dbEntity;
    //}


    ///// <inheritdoc />
    //public async Task<DateTime> GetVorigeLoginOpAsync(Guid medewerkerId)
    //{
    //    var dbEntity = await Query().FirstOrDefaultAsync(x => x.Id == medewerkerId);
    //    return dbEntity?.VorigeLoginOp ?? DateTime.MinValue;
    //}


    ///// <inheritdoc />
    //public async Task<List<MailAddress>> CcMailAddressenVanCollegasAsync(Guid organisatieId, Guid medewerkerId, EmailSoort? emailSoort)
    //{
    //    var dbQuery = Query()
    //        .Include(i => i.UserProfile)
    //        .AsNoTracking()
    //        .Where(x => x.Id != medewerkerId &&
    //                    x.OrganisatieId == organisatieId &&
    //                    x.Status == Status.Actief);

    //    if (emailSoort != null)
    //    {
    //        switch (emailSoort)
    //        {
    //            case EmailSoort.EmailBijBericht:
    //                dbQuery = dbQuery.Where(x => x.UserProfile.EmailBijAanleverbericht == EmailOntvangenType.Alle);
    //                break;
    //            case EmailSoort.EmailBijDcumentToegevoegd:
    //                dbQuery = dbQuery.Where(x => x.UserProfile.EmailBijToevoegenDocument == EmailOntvangenType.Alle);
    //                break;
    //        }
    //    }

    //    var result = await dbQuery.ToListAsync();
    //    if (result.Any())
    //    {
    //        var list = result.Select(x => new MailAddress(x.Persoon.Email, x.Persoon.VolledigeNaam)).ToList();
    //        return list;
    //    }

    //    return new List<MailAddress>();
    //}

    ///// <inheritdoc />
    //public async Task<string> GetVolledigeNaamByIdAsync(Guid id)
    //{
    //    var medewerker = await GetByIdAsync(id);
    //    return medewerker != null ? medewerker.Persoon.VolledigeNaam : string.Empty;
    //}



    ///// <inheritdoc />
    //public async Task<string> GetFormeleNaamByIdAsync(Guid id)
    //{
    //    var medewerker = await GetByIdAsync(id);
    //    return medewerker != null ? medewerker.Persoon.FormeleNaam : string.Empty;
    //}

    ///// <inheritdoc />
    //public async Task<List<Medewerker>> GetMedewerkersByOrganisatieIdAsync(Guid organisatieId)
    //{
    //    var dbQuery = await Query()
    //        .Where(x => x.OrganisatieId == organisatieId)
    //        .OrderBy(o => o.Persoon.Achternaam)
    //        .ToListAsync();

    //    return dbQuery;
    //}


    ///// <inheritdoc />
    //public async Task<List<Medewerker>> GetLevel2MedewerkersByOrganisatieIdAsync(Guid organisatieId)
    //{
    //    var dbQuery = await Query()
    //            .AsNoTracking()
    //            .Include(i => i.UserProfile)
    //            .Include(i => i.Organisatie)
    //            .Where(x => x.OrganisatieId == organisatieId && x.UserProfile.EmailBijRapportage == true)
    //            .OrderBy(o => o.Persoon.Achternaam)
    //            .ToListAsync()
    //        ;

    //    return dbQuery;
    //}

    ///// <inheritdoc />
    //public async Task<string> CheckUsernameAsync(string userName)
    //{
    //    var isUnique = await IsUsernameUnique(userName);
    //    if (isUnique)
    //        return userName;


    //    var volgnr = await BepaalVolgNummerAsync(userName);
    //    var uniqueUserName = $"{userName}{volgnr:d2}";

    //    while (!isUnique)
    //    {
    //        volgnr++;
    //        uniqueUserName = $"{userName}{volgnr:d2}";
    //        isUnique = await IsUsernameUnique(uniqueUserName);
    //    }

    //    return uniqueUserName;
    //}

    //public IEnumerable<Medewerker> GetMedewerkers(IEnumerable<Guid> medewerkerIds)
    //{
    //    var result = new List<Medewerker>();
    //    var dbQuery = Query()
    //        .AsNoTracking()
    //        .Where(x => medewerkerIds.Contains(x.Id));

    //    result.AddRange(dbQuery);
    //    return result;
    //}

    ///// <inheritdoc />
    //public async Task<UserProfile> GetUserProfile(Guid medewerkerId)
    //{
    //    var medewerker = await GetMedewerkerByIdAsync(medewerkerId);
    //    return medewerker != null ? medewerker.UserProfile : new UserProfile();
    //}


    ///// <inheritdoc />
    //public async Task<List<Medewerker>> GetMedewerkersMetIONToestemmingVerleend(Guid organisatieId)
    //{
    //    var dbQuery = Query()
    //        .AsNoTracking()
    //        .Where(x => x.OrganisatieId == organisatieId && x.Status == Status.Actief
    //                                                     && x.UserProfile.IONVecozoToestemming
    //                                                     && x.UserProfile.IONToestemmingsverlaringGetekend
    //                                                     && x.UserProfile.IONToestemmingIngetrokken == false);
    //    return await dbQuery.ToListAsync();
    //}

    ///// <inheritdoc />
    //public bool GetInterneMedewerkerMagRaadplegenNamens(Guid organisatieId)
    //{
    //    var result = Query()
    //        .AsNoTracking()
    //        .Count(x => x.OrganisatieId == organisatieId && x.Status == Status.Actief
    //                                                     && x.UserProfile.IONVecozoToestemming
    //                                                     && x.UserProfile.IONToestemmingsverlaringGetekend
    //                                                     && x.UserProfile.IONToestemmingIngetrokken == false);
    //    return result > 0;
    //}




    ///// <inheritdoc />
    //public List<string> GetRapportagebestandsnamen(Guid medewerkerId)
    //{
    //    var sql = @"SELECT
    //                    B.FileName
    //                    FROM Rapportage R
    //                    LEFT OUTER JOIN Bestand B on B.Id = R.Id
    //                    WHERE B.EigenaarId = @medewerkerId";

    //    return SqlQuery<string>(sql, new SqlParameter("@medewerkerId", medewerkerId)).ToList();
    //}


    ///// <inheritdoc />
    //public List<string> GetAanleverbestandsnamen(Guid medewerkerId)
    //{
    //    var names = _context.Aanleverbestanden
    //        .FromSqlRaw("SELECT B.FileName FROM Aanleverbestand AB INNER JOIN Bestand B on B.Id = AB.Id  WHERE B.EigenaarId = @medewerkerId", medewerkerId)
    //        .ToList();
    //    return names;
    //    //var sql = @"SELECT 
    //    //                B.FileName
    //    //                FROM Aanleverbestand AB
    //    //                INNER JOIN Bestand B on B.Id = AB.Id
    //    //                WHERE B.EigenaarId = @medewerkerId";

    //    //var param = new SqlParameter("@medewerkerId", medewerkerId);
    //    //return _context.Database.ExecuteSqlRaw(sql, new SqlParameter("@medewerkerId", medewerkerId));

    //    //return SqlQuery<string>(sql, new SqlParameter("@medewerkerId", medewerkerId)).ToList();
    //}


    ///// <inheritdoc />
    //public List<string> GetOverigebestandsnamen(Guid medewerkerId)
    //{
    //    var sql = @"SELECT 
    //                    B.FileName
    //                    FROM  Overigbestand OB
    //                    INNER JOIN Bestand B on B.Id = OB.Id
    //                    WHERE B.EigenaarId = @medewerkerId";

    //    return SqlQuery<string>(sql, new SqlParameter("@medewerkerId", medewerkerId)).ToList();
    //}


    ///// <inheritdoc />
    //public List<string> GetAanleveringReferentiesPromeetec(Guid medewerkerId)
    //{
    //    var sql = @"SELECT
    //                    A.ReferentiePromeetec
    //                    FROM Aanlevering A
    //                    WHERE A.EigenaarId =  @medewerkerId";

    //    return SqlQuery<string>(sql, new SqlParameter("@medewerkerId", medewerkerId)).ToList();
    //}


    ///// <inheritdoc />
    //public List<MedewerkerDeleteInfo> GetMedewerkerDeleteInfo(Guid medewerkerId)
    //{
    //    var sql = @"SELECT 
    //                    MDW.VolledigeNaam,
    //                    MDW.Email,
    //                    (  
	   //                     SELECT count(*) 
    //                        FROM Memos MO
    //                        WHERE MO.MedewerkerId = MDW.UserId
    //                    ) As AantalMemos,
    //                    (  
	   //                     SELECT count(*) 
    //                        FROM Notificatie NOTI
    //                        WHERE NOTI.MedewerkerId = MDW.UserId
    //                    ) As AantalNotificaties
    //                    FROM  Medewerker MDW 
    //                    WHERE MDW.UserId = @medewerkerId";

    //    return SqlQuery<MedewerkerDeleteInfo>(sql, new SqlParameter("@medewerkerId", medewerkerId)).ToList();
    //}

    ///// <inheritdoc />
    //public async Task<int> VerwijderMedewerkerMetOnderliggendeRelaties(Guid medewerkerId)
    //{
    //    var sql = @"DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
    //                    DECLARE @id  uniqueidentifier
    //                    SET @id = '" + medewerkerId + "'" + @"

    //                    PRINT '======= GLI ======='
    //                    BEGIN TRANSACTION;
    //                    BEGIN TRY
	   //                     DROP TABLE IF EXISTS #gliBehandelplanIds;
	   //                     DROP TABLE IF EXISTS #gliIntakeIds;
	   //                     DROP TABLE IF EXISTS #gliIntakeCommandIds;
	   //                     DROP TABLE IF EXISTS #gliBehandelplanCommandIds;

	   //                     SELECT DISTINCT GB.Id 
	   //                     INTO #gliBehandelplanIds
	   //                     FROM GliBehandelplan GB
	   //                     WHERE GB.BehandelaarId = @id

	   //                     SELECT DISTINCT GI.Id 
	   //                     INTO #gliIntakeIds
	   //                     FROM GliIntake GI
	   //                     WHERE GI.BehandelaarId = @id

	   //                     SELECT DISTINCT E.CommandId 
	   //                     INTO #gliIntakeCommandIds
	   //                     FROM DomainEvent E
	   //                     WHERE E.AggregateId in (
		  //                      SELECT X.Id
		  //                      FROM #gliIntakeIds X
	   //                     )
	                                            
	   //                     SELECT DISTINCT E.CommandId 
	   //                     INTO #gliBehandelplanCommandIds
	   //                     FROM DomainEvent E
	   //                     WHERE E.AggregateId in (
		  //                      SELECT X.Id
		  //                      FROM #gliBehandelplanIds X
	   //                     )
	                                            
	   //                     PRINT 'Deleting DomainEvent'
	   //                     DELETE FROM DomainEvent
	   //                     WHERE AggregateId IN (
		  //                      SELECT X.Id
		  //                      FROM #gliBehandelplanIds X
	   //                     ) OR AggregateId IN (
		  //                      SELECT X.Id
		  //                      FROM #gliIntakeIds X
	   //                     )

	   //                     PRINT 'Deleting DomainCommand'
	   //                     DELETE FROM DomainCommand
	   //                     WHERE Id IN (
		  //                      SELECT X.CommandId
		  //                      FROM #gliIntakeCommandIds X
	   //                     ) OR AggregateId IN (
		  //                      SELECT X.CommandId
		  //                      FROM #gliBehandelplanCommandIds X
	   //                     )

	   //                     PRINT 'Deleting DomainAggregate'
	   //                     DELETE FROM DomainAggregate
	   //                     WHERE Id IN (
		  //                      SELECT X.Id
		  //                      FROM #gliBehandelplanIds X
	   //                     ) OR Id IN (
		  //                      SELECT X.Id
		  //                      FROM #gliIntakeIds X
	   //                     )
	                                            
	   //                     PRINT 'Deleting Gli Behandelplan'
	   //                     DELETE GB FROM GliBehandelplan GB INNER JOIN #gliBehandelplanIds X ON GB.Id = X.Id

	   //                     PRINT 'Deleting Gli Intake'
	   //                     DELETE GI FROM GliIntake GI INNER JOIN #gliIntakeIds X ON GI.Id = X.Id

	   //                     COMMIT TRANSACTION
    //                    END TRY
    //                    BEGIN CATCH
    //                        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                        ROLLBACK TRANSACTION
    //                    END CATCH


    //                    PRINT '======= ION ======='
    //                    BEGIN TRANSACTION;
    //                    BEGIN TRY
	   //                     DROP TABLE IF EXISTS #ionIds;
	   //                     DROP TABLE IF EXISTS #ionCommandIds;

	   //                     SELECT DISTINCT I.Id 
	   //                     INTO #ionIds
	   //                     FROM IONPatientRelatie I
	   //                     WHERE I.MedewerkerId = @id

	   //                     SELECT DISTINCT E.CommandId 
	   //                     INTO #ionCommandIds
	   //                     FROM DomainEvent E
	   //                     WHERE E.AggregateId in (
		  //                      SELECT X.Id
		  //                      FROM #ionIds X
	   //                     )

	   //                     PRINT 'Deleting DomainEvent'
	   //                     DELETE FROM DomainEvent
	   //                     WHERE AggregateId IN (
		  //                      SELECT X.Id
		  //                      FROM #ionIds X
	   //                     )

	   //                     PRINT 'Deleting DomainCommand'
	   //                     DELETE FROM DomainCommand
	   //                     WHERE Id IN (
		  //                      SELECT X.CommandId
		  //                      FROM #ionCommandIds X
	   //                     )

	   //                     PRINT 'Deleting DomainAggregate'
	   //                     DELETE FROM DomainAggregate
	   //                     WHERE Id IN (
		  //                      SELECT X.Id
		  //                      FROM #ionIds X
	   //                     )

	   //                     PRINT 'Deleting IONPatientRelatie'
	   //                     DELETE I FROM IONPatientRelatie I INNER JOIN #ionIds X ON I.Id = X.Id
	                                            
	   //                     COMMIT TRANSACTION
    //                    END TRY
    //                    BEGIN CATCH
    //                        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                        ROLLBACK TRANSACTION
    //                    END CATCH


    //                    PRINT '======= Bestand ======='
    //                    BEGIN TRANSACTION;
    //                    BEGIN TRY

	   //                     DROP TABLE IF EXISTS #bestandIds;
	   //                     DROP TABLE IF EXISTS #bestandCommandIds;

	   //                     SELECT DISTINCT B.Id 
	   //                     INTO #bestandIds
	   //                     FROM Bestand B
	   //                     WHERE B.EigenaarId = @id

	   //                     SELECT DISTINCT E.CommandId 
	   //                     INTO #bestandCommandIds
	   //                     FROM DomainEvent E
	   //                     WHERE E.AggregateId in (
		  //                      SELECT X.Id
		  //                      FROM #bestandIds X
	   //                     )
	                                            
	   //                     PRINT 'Deleting DomainEvent'
	   //                     DELETE FROM DomainEvent
	   //                     WHERE AggregateId IN (
		  //                      SELECT X.Id
		  //                      FROM #bestandIds X
	   //                     )

	   //                     PRINT 'Deleting DomainCommand'
	   //                     DELETE FROM DomainCommand
	   //                     WHERE Id IN (
		  //                      SELECT X.CommandId
		  //                      FROM #bestandCommandIds X
	   //                     )

	   //                     PRINT 'Deleting DomainAggregate'
	   //                     DELETE FROM DomainAggregate
	   //                     WHERE Id IN (
		  //                      SELECT X.Id
		  //                      FROM #bestandIds X
	   //                     )
	                                            
	   //                     PRINT 'Deleting Aanleverbestand'
	   //                     DELETE AB FROM Aanleverbestand AB INNER JOIN #bestandIds X ON AB.Id = X.Id

	   //                     PRINT 'Deleting Overigbestand'
	   //                     DELETE OB FROM Overigbestand OB INNER JOIN #bestandIds X ON OB.Id = X.Id

	   //                     PRINT 'Deleting rapportage'
	   //                     DELETE R FROM Rapportage R INNER JOIN #bestandIds X ON R.Id = X.Id

	   //                     PRINT 'Deleting Bestand'
	   //                     DELETE B FROM Bestand B INNER JOIN #bestandIds X ON B.Id = X.Id
	                                               
    //                        COMMIT TRANSACTION
    //                    END TRY
    //                    BEGIN CATCH
    //                        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                        ROLLBACK TRANSACTION
    //                    END CATCH



    //                    PRINT '======= Aanleverbericht ======='
    //                    BEGIN TRANSACTION;
    //                    BEGIN TRY
	   //                     DROP TABLE IF EXISTS #aanleverberichtIds;
	   //                     DROP TABLE IF EXISTS #aanleverberichtCommandIds;

	   //                     SELECT DISTINCT AB.Id 
	   //                     INTO #aanleverberichtIds
	   //                     FROM Aanleverbericht AB 
	   //                     WHERE AanleveringId in (
		  //                      SELECT  A.Id 
		  //                      FROM Aanlevering A
		  //                      WHERE A.EigenaarId = @id
	   //                     ) OR AB.LaatsteLezerId = @id OR AB.OntvangerId = @id OR AB.AfzenderId = @id

                                               
	   //                     SELECT DISTINCT E.CommandId 
	   //                     INTO #aanleverberichtCommandIds
	   //                     FROM DomainEvent E
	   //                     WHERE E.AggregateId in (
		  //                      SELECT X.Id
		  //                      FROM #aanleverberichtIds X
	   //                     )


	   //                     PRINT 'Deleting DomainEvent'
	   //                     DELETE FROM DomainEvent
	   //                     WHERE AggregateId IN (
		  //                      SELECT X.Id
		  //                      FROM #aanleverberichtIds X
	   //                     )

	   //                     PRINT 'Deleting DomainCommand'
	   //                     DELETE FROM DomainCommand
	   //                     WHERE Id IN (
		  //                      SELECT X.CommandId
		  //                      FROM #aanleverberichtCommandIds X
	   //                     )

	   //                     PRINT 'Deleting DomainAggregate'
	   //                     DELETE FROM DomainAggregate
	   //                     WHERE Id IN (
		  //                      SELECT X.Id
		  //                      FROM #aanleverberichtIds X
	   //                     )

	   //                     PRINT 'Deleting Aanleverbericht'
	   //                     DELETE AB FROM Aanleverbericht AB INNER JOIN #aanleverberichtIds X ON AB.Id = X.Id

    //                        COMMIT TRANSACTION
    //                    END TRY
    //                    BEGIN CATCH
    //                        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                        ROLLBACK TRANSACTION
    //                    END CATCH



    //                    PRINT '======= Aanlevering ======='
    //                    BEGIN TRANSACTION;
    //                    BEGIN TRY

	   //                     DROP TABLE IF EXISTS #aanleveringIds;
	   //                     DROP TABLE IF EXISTS #aanleveringCommandIds;

	   //                     SELECT DISTINCT A.Id 
	   //                     INTO #aanleveringIds
	   //                     FROM Aanlevering A
	   //                     WHERE A.EigenaarId = @id

	   //                     SELECT DISTINCT E.CommandId 
	   //                     INTO #aanleveringCommandIds
	   //                     FROM DomainEvent E
	   //                     WHERE E.AggregateId in (
		  //                      SELECT X.Id
		  //                      FROM #aanleveringIds X
	   //                     )


	   //                     PRINT 'Deleting DomainEvent'
	   //                     DELETE FROM DomainEvent
	   //                     WHERE AggregateId IN (
		  //                      SELECT X.Id
		  //                      FROM #aanleveringIds X
	   //                     )

	   //                     PRINT 'Deleting DomainCommand'
	   //                     DELETE FROM DomainCommand
	   //                     WHERE Id IN (
		  //                      SELECT X.CommandId
		  //                      FROM #aanleveringCommandIds X
	   //                     )

	   //                     PRINT 'Deleting DomainAggregate'
	   //                     DELETE FROM DomainAggregate
	   //                     WHERE Id IN (
		  //                      SELECT X.Id
		  //                      FROM #aanleveringIds X
	   //                     )
	                                            
	   //                     PRINT 'Deleting Aanlevering'
	   //                     DELETE FROM Aanlevering WHERE EigenaarId = @id

	   //                     COMMIT TRANSACTION
    //                    END TRY
    //                    BEGIN CATCH
    //                        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                        ROLLBACK TRANSACTION
    //                    END CATCH


    //                    PRINT '======= Medewerker ======='
    //                    BEGIN TRANSACTION;
    //                    BEGIN TRY
	   //                     DROP TABLE IF EXISTS #medewerkersIds;
	   //                     DROP TABLE IF EXISTS #medewerkerAdressenIds;
	   //                     DROP TABLE IF EXISTS #medewerkerCommandIds;

	   //                     SELECT DISTINCT M.UserId 
	   //                     INTO #medewerkersIds
	   //                     FROM Medewerker M
	   //                     WHERE M.UserId = @id

	   //                     SELECT DISTINCT M.AdresId 
	   //                     INTO #medewerkerAdressenIds
	   //                     FROM Medewerker M
	   //                     WHERE M.UserId = @id

	   //                     SELECT DISTINCT E.CommandId 
	   //                     INTO #medewerkerCommandIds
	   //                     FROM DomainEvent E
	   //                     WHERE E.AggregateId in (
		  //                      SELECT X.UserId
		  //                      FROM #medewerkersIds X
	   //                     )

	   //                     PRINT 'Deleting DomainEvent'
	   //                     DELETE FROM DomainEvent
	   //                     WHERE AggregateId IN (
		  //                      SELECT X.UserId
		  //                      FROM #medewerkersIds X
	   //                     )

	   //                     PRINT 'Deleting DomainCommand'
	   //                     DELETE FROM DomainCommand
	   //                     WHERE Id IN (
		  //                      SELECT X.CommandId
		  //                      FROM #medewerkerCommandIds X
	   //                     )

	   //                     PRINT 'Deleting DomainAggregate'
	   //                     DELETE FROM DomainAggregate
	   //                     WHERE Id IN (
		  //                      SELECT X.UserId
		  //                      FROM #medewerkersIds X
	   //                     )
	                                            
	   //                     PRINT 'Deleting Notificatie'
	   //                     DELETE FROM Notificatie
	   //                     WHERE MedewerkerId IN (
		  //                      SELECT X.UserId
		  //                      FROM #medewerkersIds X
	   //                     )

	   //                     PRINT 'Deleting Memos'
	   //                     DELETE FROM Memos
	   //                     WHERE MedewerkerId IN (
		  //                      SELECT X.UserId
		  //                      FROM #medewerkersIds X
	   //                     )

	   //                     PRINT 'Deleting DownloadActivity'
	   //                     DELETE FROM DownloadActivity
	   //                     WHERE MedewerkerId IN (
		  //                      SELECT X.UserId
		  //                      FROM #medewerkersIds X
	   //                     )

	                                            
	   //                     PRINT 'Deleting UserRole'
	   //                     DELETE FROM UserRole
	   //                     WHERE UserId IN (
		  //                      SELECT X.UserId
		  //                      FROM #medewerkersIds X
	   //                     )

	   //                     PRINT 'Deleting GroupUser'
	   //                     DELETE FROM GroupUser
	   //                     WHERE UserId IN (
		  //                      SELECT X.UserId
		  //                      FROM #medewerkersIds X
	   //                     )
                                                
	   //                     PRINT 'Deleting UserProfile'
	   //                     DELETE FROM UserProfile
	   //                     WHERE Id IN (
		  //                      SELECT X.UserId
		  //                      FROM #medewerkersIds X
	   //                     )
	                                            
	   //                     PRINT 'Deleting Medewerker'
	   //                     DELETE M FROM Medewerker M INNER JOIN #medewerkersIds X ON M.UserId = X.UserId

	   //                     PRINT 'Deleting Adres medewerker'
	   //                     DELETE FROM Adres
	   //                     WHERE Id IN (
		  //                      SELECT X.AdresId
		  //                      FROM #medewerkerAdressenIds X
	   //                     )

	   //                     COMMIT TRANSACTION
    //                    END TRY
    //                    BEGIN CATCH
    //                        SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                        ROLLBACK TRANSACTION
    //                    END CATCH

                        

    //                    ";

    //    return await RawSQLAsync(sql);
    //}

    //#region Private methods

    ///// <summary>
    /////     Bepaal of de opgegeven 'userName' unique is.
    ///// </summary>
    ///// <param name="userName">Name of the user.</param>
    ///// <returns>
    /////     <c>true</c> if [is userName unique] [the specified name of the user identifier]; otherwise, <c>false</c>.
    ///// </returns>
    //private async Task<bool> IsUsernameUnique(string userName)
    //{
    //    var dbQuery = await Query().CountAsync(x => x.UserName == userName);
    //    return dbQuery == 0;
    //}

    ///// <summary>
    /////     Maak uniek volgnummer asynchroon.
    ///// </summary>
    ///// <param name="userName">Name of the user.</param>
    //private async Task<int> BepaalVolgNummerAsync(string userName)
    //{
    //    var result = await Query().CountAsync(x => x.UserName == userName);
    //    return result + 1;
    //}

    //#endregion
}