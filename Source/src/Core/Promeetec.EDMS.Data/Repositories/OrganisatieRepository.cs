using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class OrganisatieRepository : Repository<Organisatie>, IOrganisatieRepository
{
    public OrganisatieRepository(EDMSDbContext context)
        : base(context)
    {
    }

    ///// <inheritdoc/>
    //public Organisatie? GetPromeetec()
    //{
    //    var dbEntity = Query().FirstOrDefault(x => x.Nummer == "0000");
    //    return dbEntity;
    //}


    ///// <inheritdoc/>
    //public async Task<Guid> GetPromeetecIdAsync()
    //{
    //    var dbEntity = await Query().FirstOrDefaultAsync(x => x.Nummer == "0000");
    //    return dbEntity.Id;
    //}


    ///// <inheritdoc/>
    //public async Task<Organisatie?> GetOrganisatieByIdAsync(Guid organisatieId)
    //{
    //    var dbEntity = await Query().FirstOrDefaultAsync(x => x.Id == organisatieId);
    //    return dbEntity;
    //}


    ///// <inheritdoc />
    //public async Task<string> GetOrganisatieNaamByIdAsync(Guid id)
    //{
    //    var organisatie = await GetByIdAsync(id);
    //    return organisatie != null ? organisatie.Naam : string.Empty;
    //}


    ///// <inheritdoc />
    //public async Task<string> GetOrganisatieDisplayNameByIdAsync(Guid id)
    //{
    //    var organisatie = await GetByIdAsync(id);
    //    return organisatie != null ? organisatie.DisplayName : string.Empty;
    //}


    ///// <inheritdoc/>
    //public string? GetOrganisatieNummerById(Guid id)
    //{
    //    var dbQuery = Query()
    //        .Where(x => x.Id == id && x.Status != Status.Verwijderd)
    //        .Select(x => x.Nummer)
    //        .FirstOrDefault();

    //    return dbQuery;
    //}



    ///// <inheritdoc/>
    //public Adres? GetOrganisatieAddressById(Guid id)
    //{
    //    var dbQuery = Query()
    //        .Where(x => x.Id == id && x.Status != Status.Verwijderd)
    //        .Select(x => x.Adres)
    //        .FirstOrDefault();

    //    return dbQuery;
    //}

    ///// <inheritdoc />
    //public async Task<List<string>> GetAgbCodesOndernemingAsync(Guid id)
    //{
    //    var dbEntity = await Query().FirstOrDefaultAsync(x => x.Id == id);
    //    return dbEntity?.AgbCodeOnderneming?.Split(',').ToList() ?? new List<string>();
    //}


    ///// <inheritdoc/>
    //public async Task<bool> IsOrganisatieNummerUniqueAsync(string nummer, Guid? id = default)
    //{
    //    var organisatieId = await Query().Where(x => x.Nummer == nummer).Select(x => x.Id).FirstOrDefaultAsync();
    //    var result = organisatieId == Guid.Empty || id != Guid.Empty && organisatieId == id;
    //    return result;
    //}


    ///// <inheritdoc/>
    //public async Task<bool> IsOrganisatieInRole(Guid organisatieId, string roleName)
    //{
    //    var dbQuery = await Query().AsNoTracking()
    //        .Where(x => x.Id == organisatieId)
    //        .Select(x => x.Medewerkers.Where(y => y.Roles.Any(r => r.Role.Name == roleName)))
    //        .FirstOrDefaultAsync();

    //    if (dbQuery != null && dbQuery.Count() != 0)
    //        return true;
    //    return false;
    //}



    ///// <inheritdoc/>
    //public async Task<Organisatie?> GetMedewerkersVanOrganisatieAsync(Guid id)
    //{
    //    var dbEntity = await Query()
    //        .AsNoTracking()
    //        .Include(i => i.Medewerkers)
    //        .FirstOrDefaultAsync(x => x.Id == id);

    //    return dbEntity;
    //}


    ///// <inheritdoc/>
    //public async Task<Guid> GetAddressbookIdAsync(Guid id)
    //{
    //    var dbQuery = await Query().AsNoTracking()
    //        .Where(x => x.Id == id)
    //        .Select(x => new
    //        {
    //            AdresboekId = x.Adresboek.Id
    //        }).FirstOrDefaultAsync();

    //    var adresboekId = Guid.Parse(dbQuery.AdresboekId.ToString());
    //    return adresboekId;
    //}


    ///// <inheritdoc/>
    //public async Task<VerwijzerInAdresboekType> GetVerwijzerInAdresboekPreferenceAsync(Guid id)
    //{
    //    var dbQuery = await Query()
    //        .Where(x => x.Id == id && x.Status != Status.Verwijderd)
    //        .Select(x => x.VerwijzerInAdresboek)
    //        .FirstOrDefaultAsync();

    //    return dbQuery;
    //}



    ///// <inheritdoc/>
    //public async Task<OrganisatieSettings> GetOrganisatieSettingsAsync(Guid id)
    //{
    //    var dbQuery = await Query()
    //        .Where(x => x.Id == id && x.Status != Status.Verwijderd)
    //        .Select(x => new OrganisatieSettings
    //        {
    //            IONZoekoptie = x.IONZoekoptie,
    //            AanleverbestandLocatie = x.AanleverbestandLocatie,
    //            AanleverStatusNaSchrijvenAanleverbestanden = x.AanleverStatusNaSchrijvenAanleverbestanden,
    //            COVControleProcessType = x.COVControleProcessType,
    //            COVControleType = x.COVControleType,
    //            VerwijzerInAdresboek = x.VerwijzerInAdresboek,
    //            VoorraadId = x.Voorraad.Id,
    //            AdresboekId = x.Adresboek.Id
    //        })
    //        .FirstOrDefaultAsync();

    //    return dbQuery;
    //}


    ///// <inheritdoc/>
    //public async Task<bool> IsNummerUniqueAsync(string nummer, Guid? id = default)
    //{
    //    var organisatieId = await Query().Where(x => x.Nummer == nummer).Select(x => x.Id).FirstOrDefaultAsync();
    //    var result = organisatieId == Guid.Empty || id != Guid.Empty && organisatieId == id;
    //    return result;
    //}


    ///// <inheritdoc/>
    //public async Task<bool> IsZorggroepAsync(Guid id)
    //{
    //    var dbQuery = await Query()
    //        .Where(x => x.Id == id && x.Status != Status.Verwijderd)
    //        .Select(x => x.Zorggroep)
    //        .FirstOrDefaultAsync();

    //    return dbQuery;
    //}


    ///// <inheritdoc/>
    //public async Task<bool> IsMedewerkerContactpersoonAsync(Guid medewerkerId)
    //{
    //    var isContactpersoon = await Query().AnyAsync(x => x.ContactpersoonId == medewerkerId);
    //    return isContactpersoon;
    //}


    ///// <inheritdoc/>
    //public async Task<List<Organisatie>> GetOrganisatiesVanContactpersoonAsync(Guid medewerkerId)
    //{
    //    var dbQuery = await Query()
    //        .AsNoTracking()
    //        .Where(x => x.ContactpersoonId == medewerkerId)
    //        .ToListAsync();

    //    return dbQuery;
    //}


    ///// <inheritdoc />
    //public async Task<List<Organisatie>> GetGekoppeldeOrganisaties(Guid id)
    //{
    //    var dbQuery = Query()
    //        .AsNoTracking()
    //        .Where(x => x.ZorggroepRelatieId == id && x.Status == Status.Actief);

    //    return await dbQuery.ToListAsync();
    //}




    ///// <inheritdoc />
    //public List<string> GetVoorraadbestandsnamen(Guid organisatieId)
    //{
    //    var sql = @"SELECT
    //                    B.FileName
    //                    FROM Organisatie O
    //                    INNER JOIN Voorraad V on V.OrganisatieId = O.Id
    //                    INNER JOIN Aanleverbestand AB on AB.VoorraadId = V.Id
    //                    INNER JOIN Bestand B on B.Id = AB.Id
    //                    WHERE O.Id = @organisatieId AND AB.WorkFlowState = '0'";

    //    return SqlQuery<string>(sql, new SqlParameter("@organisatieId", organisatieId)).ToList();
    //}


    ///// <inheritdoc />
    //public List<string> GetRapportagebestandsnamen(Guid organisatieId)
    //{
    //    var sql = @"SELECT
    //                    B.FileName
    //                    FROM Organisatie O
    //                    LEFT OUTER JOIN Rapportage R on R.OrganisatieId = O.Id
    //                    LEFT OUTER JOIN Bestand B on B.Id = R.Id
    //                    WHERE O.Id = @organisatieId";

    //    return SqlQuery<string>(sql, new SqlParameter("@organisatieId", organisatieId)).ToList();
    //}


    ///// <inheritdoc />
    //public List<string> GetAanleverbestandsnamen(Guid organisatieId)
    //{
    //    var sql = @"SELECT 
    //                    B.FileName
    //                    FROM Aanlevering A
    //                    LEFT OUTER JOIN Aanleverbestand AB on AB.AanleveringId = A.Id
    //                    INNER JOIN Bestand B on B.Id = AB.Id
    //                    WHERE A.OrganisatieId = @organisatieId AND AB.WorkFlowState = '1'";

    //    return SqlQuery<string>(sql, new SqlParameter("@organisatieId", organisatieId)).ToList();
    //}


    ///// <inheritdoc />
    //public List<string> GetOverigebestandsnamen(Guid organisatieId)
    //{
    //    var sql = @"SELECT 
    //                    B.FileName
    //                    FROM  Aanlevering A
    //                    LEFT OUTER JOIN Overigbestand OB on OB.AanleveringId = A.Id
    //                    INNER JOIN Bestand B on B.Id = OB.Id
    //                    WHERE A.OrganisatieId = @organisatieId";

    //    return SqlQuery<string>(sql, new SqlParameter("@organisatieId", organisatieId)).ToList();
    //}


    ///// <inheritdoc />
    //public List<string> GetAanleveringReferentiesPromeetec(Guid organisatieId)
    //{
    //    var sql = @"SELECT
    //                    A.ReferentiePromeetec
    //                    FROM Aanlevering A
    //                    WHERE A.OrganisatieId = @organisatieId";

    //    return SqlQuery<string>(sql, new SqlParameter("@organisatieId", organisatieId)).ToList();
    //}


    ///// <inheritdoc />
    //public List<MedewerkerDeleteInfo> GetMedewerkersDeleteInfo(Guid organisatieId)
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
    //                    WHERE MDW.OrganisatieId = @organisatieId";

    //    return SqlQuery<MedewerkerDeleteInfo>(sql, new SqlParameter("@organisatieId", organisatieId)).ToList();
    //}

    ///// <inheritdoc />
    //public int GetAantalVerzekerdeVoorAdresboek(Guid organisatieId)
    //{
    //    //var sql = @"SELECT count(*) 
    //    //                FROM Organisatie O
    //    //                INNER JOIN Adresboek AB on AB.OrganisatieId = O.Id 
    //    //                LEFT OUTER JOIN Verzekerden V on V.AdresboekId = AB.Id 
    //    //                WHERE O.Id = @organisatieId AND V.AdresboekId = AB.Id";

    //    //return SqlQuery<int>(sql, new SqlParameter("@organisatieId", organisatieId)).FirstOrDefault();
    //    return 0; //TODO
    //}


    ///// <inheritdoc/>
    //public async Task<int> VerwijderOrganisatieMetOnderliggendeRelaties(Guid organisatieId)
    //{
    //    var sql = @"
    //                DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
    //                DECLARE @id  uniqueidentifier
    //                SET @id = '" + organisatieId + "'" + @"

    //                PRINT '======= Verzekerden ======='
    //                BEGIN TRANSACTION;
    //                BEGIN TRY
	   //                 DROP TABLE IF EXISTS #verzekerdeIds;
	   //                 DROP TABLE IF EXISTS #verzekerdeCommandIds;

	   //                 SELECT DISTINCT V.Id 
	   //                 INTO #verzekerdeIds
	   //                 FROM Verzekerden V
	   //                 WHERE AdresboekId in (
		  //                  SELECT  A.Id 
		  //                  FROM Adresboek A LEFT OUTER JOIN Organisatie O on O.AdresboekId = A.Id 
		  //                  WHERE A.OrganisatieId = @id
	   //                 )

	   //                 SELECT DISTINCT E.CommandId 
	   //                 INTO #verzekerdeCommandIds
	   //                 FROM DomainEvent E
	   //                 WHERE E.AggregateId in (
		  //                  SELECT X.Id
		  //                  FROM #verzekerdeIds X
	   //                 )
		
	   //                 PRINT 'Deleting DomainEvent'
	   //                 DELETE FROM DomainEvent
	   //                 WHERE AggregateId IN (
		  //                  SELECT X.Id
		  //                  FROM #verzekerdeIds X
	   //                 )

	   //                 PRINT 'Deleting DomainCommand'
	   //                 DELETE FROM DomainCommand
	   //                 WHERE Id IN (
		  //                  SELECT X.CommandId
		  //                  FROM #verzekerdeCommandIds X
	   //                 )

	   //                 PRINT 'Deleting DomainAggregate'
	   //                 DELETE FROM DomainAggregate
	   //                 WHERE Id IN (
		  //                  SELECT X.Id
		  //                  FROM #verzekerdeIds X
	   //                 )
	                       
	   //                 PRINT 'Deleting VerzekerdeToZorgverzekering'
	   //                 DELETE FROM VerzekerdeToZorgverzekering
	   //                 WHERE VerzekerdeId IN (
		  //                  SELECT X.Id
		  //                  FROM #verzekerdeIds X
	   //                 )

	   //                 PRINT 'Deleting VerzekerdeToZorgprofiel'
	   //                 DELETE FROM VerzekerdeToZorgprofiel
	   //                 WHERE VerzekerdeId IN (
		  //                  SELECT X.Id
		  //                  FROM #verzekerdeIds X
	   //                 )

	   //                 PRINT 'Deleting VerzekerdeToUser'
	   //                 DELETE FROM VerzekerdeToUser
	   //                 WHERE VerzekerdeId IN (
		  //                  SELECT X.Id
		  //                  FROM #verzekerdeIds X
	   //                 )
	                    
	   //                 PRINT 'Deleting VerzekerdeToAdres'
	   //                 DELETE FROM VerzekerdeToAdres
	   //                 WHERE VerzekerdeId IN (
		  //                  SELECT X.Id
		  //                  FROM #verzekerdeIds X
	   //                 )

	   //                 PRINT 'Deleting Verzekerden'
	   //                 DELETE V FROM Verzekerden V INNER JOIN #verzekerdeIds X ON V.Id = X.Id
	                    
	   //                 COMMIT TRANSACTION
    //                END TRY
    //                BEGIN CATCH
    //                    SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                    ROLLBACK TRANSACTION
    //                END CATCH


    //                PRINT '======= GLI ======='
    //                BEGIN TRANSACTION;
    //                BEGIN TRY
	   //                 DROP TABLE IF EXISTS #gliBehandelplanIds;
	   //                 DROP TABLE IF EXISTS #gliIntakeIds;
	   //                 DROP TABLE IF EXISTS #gliIntakeCommandIds;
	   //                 DROP TABLE IF EXISTS #gliBehandelplanCommandIds;

	   //                 SELECT DISTINCT GB.Id 
	   //                 INTO #gliBehandelplanIds
	   //                 FROM GliBehandelplan GB
	   //                 WHERE GB.OrganisatieId = @id

	   //                 SELECT DISTINCT GI.Id 
	   //                 INTO #gliIntakeIds
	   //                 FROM GliIntake GI
	   //                 WHERE GI.OrganisatieId = @id

	   //                 SELECT DISTINCT E.CommandId 
	   //                 INTO #gliIntakeCommandIds
	   //                 FROM DomainEvent E
	   //                 WHERE E.AggregateId in (
		  //                  SELECT X.Id
		  //                  FROM #gliIntakeIds X
	   //                 )
	                    
	   //                 SELECT DISTINCT E.CommandId 
	   //                 INTO #gliBehandelplanCommandIds
	   //                 FROM DomainEvent E
	   //                 WHERE E.AggregateId in (
		  //                  SELECT X.Id
		  //                  FROM #gliBehandelplanIds X
	   //                 )
	                    
	   //                 PRINT 'Deleting DomainEvent'
	   //                 DELETE FROM DomainEvent
	   //                 WHERE AggregateId IN (
		  //                  SELECT X.Id
		  //                  FROM #gliBehandelplanIds X
	   //                 ) OR AggregateId IN (
		  //                  SELECT X.Id
		  //                  FROM #gliIntakeIds X
	   //                 )

	   //                 PRINT 'Deleting DomainCommand'
	   //                 DELETE FROM DomainCommand
	   //                 WHERE Id IN (
		  //                  SELECT X.CommandId
		  //                  FROM #gliIntakeCommandIds X
	   //                 ) OR AggregateId IN (
		  //                  SELECT X.CommandId
		  //                  FROM #gliBehandelplanCommandIds X
	   //                 )

	   //                 PRINT 'Deleting DomainAggregate'
	   //                 DELETE FROM DomainAggregate
	   //                 WHERE Id IN (
		  //                  SELECT X.Id
		  //                  FROM #gliBehandelplanIds X
	   //                 ) OR Id IN (
		  //                  SELECT X.Id
		  //                  FROM #gliIntakeIds X
	   //                 )
	                    
	   //                 PRINT 'Deleting Gli Behandelplan'
	   //                 DELETE GB FROM GliBehandelplan GB INNER JOIN #gliBehandelplanIds X ON GB.Id = X.Id

	   //                 PRINT 'Deleting Gli Intake'
	   //                 DELETE GI FROM GliIntake GI INNER JOIN #gliIntakeIds X ON GI.Id = X.Id

	   //                 COMMIT TRANSACTION
    //                END TRY
    //                BEGIN CATCH
    //                    SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                    ROLLBACK TRANSACTION
    //                END CATCH


    //                PRINT '======= VerbruiksmiddelPrestaties ======='
    //                BEGIN TRANSACTION;
    //                BEGIN TRY	
	   //                 DROP TABLE IF EXISTS #verbruiksmiddelPrestatiesIds;
	   //                 DROP TABLE IF EXISTS #verbruiksmiddelCommandIds;

	   //                 SELECT DISTINCT V.Id 
	   //                 INTO #verbruiksmiddelPrestatiesIds
	   //                 FROM VerbruiksmiddelPrestaties V
	   //                 WHERE V.OrganisatieId = @id

	   //                 SELECT DISTINCT E.CommandId 
	   //                 INTO #verbruiksmiddelCommandIds
	   //                 FROM DomainEvent E
	   //                 WHERE E.AggregateId in (
		  //                  SELECT X.Id
		  //                  FROM #verbruiksmiddelPrestatiesIds X
	   //                 )

	   //                 PRINT 'Deleting DomainEvent'
	   //                 DELETE FROM DomainEvent
	   //                 WHERE AggregateId IN (
		  //                  SELECT X.Id
		  //                  FROM #verbruiksmiddelPrestatiesIds X
	   //                 )

	   //                 PRINT 'Deleting DomainCommand'
	   //                 DELETE FROM DomainCommand
	   //                 WHERE Id IN (
		  //                  SELECT X.CommandId
		  //                  FROM #verbruiksmiddelCommandIds X
	   //                 )

	   //                 PRINT 'Deleting DomainAggregate'
	   //                 DELETE FROM DomainAggregate
	   //                 WHERE Id IN (
		  //                  SELECT X.Id
		  //                  FROM #verbruiksmiddelPrestatiesIds X
	   //                 )
	                    
	   //                 PRINT 'Deleting VerbruiksmiddelPrestaties'
	   //                 DELETE V FROM VerbruiksmiddelPrestaties V INNER JOIN #verbruiksmiddelPrestatiesIds X ON V.Id = X.Id

  	 //                   COMMIT TRANSACTION
    //                END TRY
    //                BEGIN CATCH
    //                    SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                    ROLLBACK TRANSACTION
    //                END CATCH

    //                PRINT '======= ION ======='
    //                BEGIN TRANSACTION;
    //                BEGIN TRY
	   //                 DROP TABLE IF EXISTS #ionIds;
	   //                 DROP TABLE IF EXISTS #ionCommandIds;

	   //                 SELECT DISTINCT I.Id 
	   //                 INTO #ionIds
	   //                 FROM IONPatientRelatie I
	   //                 WHERE I.OrganisatieId = @id

	   //                 SELECT DISTINCT E.CommandId 
	   //                 INTO #ionCommandIds
	   //                 FROM DomainEvent E
	   //                 WHERE E.AggregateId in (
		  //                  SELECT X.Id
		  //                  FROM #ionIds X
	   //                 )

	   //                 PRINT 'Deleting DomainEvent'
	   //                 DELETE FROM DomainEvent
	   //                 WHERE AggregateId IN (
		  //                  SELECT X.Id
		  //                  FROM #ionIds X
	   //                 )

	   //                 PRINT 'Deleting DomainCommand'
	   //                 DELETE FROM DomainCommand
	   //                 WHERE Id IN (
		  //                  SELECT X.CommandId
		  //                  FROM #ionCommandIds X
	   //                 )

	   //                 PRINT 'Deleting DomainAggregate'
	   //                 DELETE FROM DomainAggregate
	   //                 WHERE Id IN (
		  //                  SELECT X.Id
		  //                  FROM #ionIds X
	   //                 )

	   //                 PRINT 'Deleting IONPatientRelatie'
	   //                 DELETE I FROM IONPatientRelatie I INNER JOIN #ionIds X ON I.Id = X.Id
	                    
	   //                 COMMIT TRANSACTION
    //                END TRY
    //                BEGIN CATCH
    //                    SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                    ROLLBACK TRANSACTION
    //                END CATCH


    //                PRINT '======= Bestand ======='
    //                BEGIN TRANSACTION;
    //                BEGIN TRY

	   //                 DROP TABLE IF EXISTS #bestandIds;
	   //                 DROP TABLE IF EXISTS #bestandCommandIds;

	   //                 SELECT DISTINCT B.Id 
	   //                 INTO #bestandIds
	   //                 FROM Bestand B
	   //                 WHERE B.EigenaarId in (
		  //                  SELECT M.UserId
		  //                  FROM Medewerker M
		  //                  WHERE M.OrganisatieId = @id
	   //                 )

	   //                 SELECT DISTINCT E.CommandId 
	   //                 INTO #bestandCommandIds
	   //                 FROM DomainEvent E
	   //                 WHERE E.AggregateId in (
		  //                  SELECT X.Id
		  //                  FROM #bestandIds X
	   //                 )
	                    
	   //                 PRINT 'Deleting DomainEvent'
	   //                 DELETE 
	   //                 FROM DomainEvent
	   //                 WHERE AggregateId IN (
		  //                  SELECT X.Id
		  //                  FROM #bestandIds X
	   //                 )

	   //                 PRINT 'Deleting DomainCommand'
	   //                 DELETE FROM DomainCommand
	   //                 WHERE Id IN (
		  //                  SELECT X.CommandId
		  //                  FROM #bestandCommandIds X
	   //                 )

	   //                 PRINT 'Deleting DomainAggregate'
	   //                 DELETE FROM DomainAggregate
	   //                 WHERE Id IN (
		  //                  SELECT X.Id
		  //                  FROM #bestandIds X
	   //                 )
	                    
	   //                 PRINT 'Deleting Aanleverbestand'
	   //                 DELETE AB FROM Aanleverbestand AB INNER JOIN #bestandIds X ON AB.Id = X.Id

	   //                 PRINT 'Deleting Overigbestand'
	   //                 DELETE OB FROM Overigbestand OB INNER JOIN #bestandIds X ON OB.Id = X.Id

	   //                 PRINT 'Deleting rapportage'
	   //                 DELETE R FROM Rapportage R INNER JOIN #bestandIds X ON R.Id = X.Id

	   //                 PRINT 'Deleting organisatie rapportage'
	   //                 DELETE FROM Rapportage WHERE OrganisatieId = @id

	   //                 PRINT 'Deleting Bestand'
	   //                 DELETE B FROM Bestand B INNER JOIN #bestandIds X ON B.Id = X.Id
	                       
    //                    COMMIT TRANSACTION
    //                END TRY
    //                BEGIN CATCH
    //                    SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                    ROLLBACK TRANSACTION
    //                END CATCH



    //                PRINT '======= Aanleverbericht ======='
    //                BEGIN TRANSACTION;
    //                BEGIN TRY
	   //                 DROP TABLE IF EXISTS #aanleverberichtIds;
	   //                 DROP TABLE IF EXISTS #aanleverberichtCommandIds;

	   //                 SELECT DISTINCT AB.Id 
	   //                 INTO #aanleverberichtIds
	   //                 FROM Aanleverbericht AB 
	   //                 WHERE AanleveringId in (
		  //                  SELECT  A.Id 
		  //                  FROM Aanlevering A
		  //                  WHERE A.OrganisatieId = @id
	   //                 )
                        
	   //                 SELECT DISTINCT E.CommandId 
	   //                 INTO #aanleverberichtCommandIds
	   //                 FROM DomainEvent E
	   //                 WHERE E.AggregateId in (
		  //                  SELECT X.Id
		  //                  FROM #aanleverberichtIds X
	   //                 )


	   //                 PRINT 'Deleting DomainEvent'
	   //                 DELETE FROM DomainEvent
	   //                 WHERE AggregateId IN (
		  //                  SELECT X.Id
		  //                  FROM #aanleverberichtIds X
	   //                 )

	   //                 PRINT 'Deleting DomainCommand'
	   //                 DELETE FROM DomainCommand
	   //                 WHERE Id IN (
		  //                  SELECT X.CommandId
		  //                  FROM #aanleverberichtCommandIds X
	   //                 )

	   //                 PRINT 'Deleting DomainAggregate'
	   //                 DELETE FROM DomainAggregate
	   //                 WHERE Id IN (
		  //                  SELECT X.Id
		  //                  FROM #aanleverberichtIds X
	   //                 )

	   //                 PRINT 'Deleting Aanleverbericht'
	   //                 DELETE AB FROM Aanleverbericht AB INNER JOIN #aanleverberichtIds X ON AB.Id = X.Id

    //                    COMMIT TRANSACTION
    //                END TRY
    //                BEGIN CATCH
    //                    SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                    ROLLBACK TRANSACTION
    //                END CATCH



    //                PRINT '======= Aanlevering ======='
    //                BEGIN TRANSACTION;
    //                BEGIN TRY

	   //                 DROP TABLE IF EXISTS #aanleveringIds;
	   //                 DROP TABLE IF EXISTS #aanleveringCommandIds;

	   //                 SELECT DISTINCT A.Id 
	   //                 INTO #aanleveringIds
	   //                 FROM Aanlevering A
	   //                 WHERE A.OrganisatieId = @id
	   //                 SELECT DISTINCT E.CommandId 
	   //                 INTO #aanleveringCommandIds
	   //                 FROM DomainEvent E
	   //                 WHERE E.AggregateId in (
		  //                  SELECT X.Id
		  //                  FROM #aanleveringIds X
	   //                 )


	   //                 PRINT 'Deleting DomainEvent'
	   //                 DELETE FROM DomainEvent
	   //                 WHERE AggregateId IN (
		  //                  SELECT X.Id
		  //                  FROM #aanleveringIds X
	   //                 )

	   //                 PRINT 'Deleting DomainCommand'
	   //                 DELETE FROM DomainCommand
	   //                 WHERE Id IN (
		  //                  SELECT X.CommandId
		  //                  FROM #aanleveringCommandIds X
	   //                 )

	   //                 PRINT 'Deleting DomainAggregate'
	   //                 DELETE FROM DomainAggregate
	   //                 WHERE Id IN (
		  //                  SELECT X.Id
		  //                  FROM #aanleveringIds X
	   //                 )
	                    
	   //                 PRINT 'Deleting Aanlevering'
	   //                 DELETE FROM Aanlevering WHERE OrganisatieId = @id

	   //                 COMMIT TRANSACTION
    //                END TRY
    //                BEGIN CATCH
    //                    SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                    ROLLBACK TRANSACTION
    //                END CATCH


    //                PRINT '======= Medewerker ======='
    //                BEGIN TRANSACTION;
    //                BEGIN TRY
	   //                 DROP TABLE IF EXISTS #medewerkersIds;
	   //                 DROP TABLE IF EXISTS #medewerkerAdressenIds;
	   //                 DROP TABLE IF EXISTS #medewerkerCommandIds;

	   //                 SELECT DISTINCT M.UserId 
	   //                 INTO #medewerkersIds
	   //                 FROM Medewerker M
	   //                 WHERE M.OrganisatieId = @id

	   //                 SELECT DISTINCT M.AdresId 
	   //                 INTO #medewerkerAdressenIds
	   //                 FROM Medewerker M
	   //                 WHERE M.OrganisatieId = @id

	   //                 SELECT DISTINCT E.CommandId 
	   //                 INTO #medewerkerCommandIds
	   //                 FROM DomainEvent E
	   //                 WHERE E.AggregateId in (
		  //                  SELECT X.UserId
		  //                  FROM #medewerkersIds X
	   //                 )

	   //                 PRINT 'Deleting DomainEvent'
	   //                 DELETE FROM DomainEvent
	   //                 WHERE AggregateId IN (
		  //                  SELECT X.UserId
		  //                  FROM #medewerkersIds X
	   //                 )

	   //                 PRINT 'Deleting DomainCommand'
	   //                 DELETE FROM DomainCommand
	   //                 WHERE Id IN (
		  //                  SELECT X.CommandId
		  //                  FROM #medewerkerCommandIds X
	   //                 )

	   //                 PRINT 'Deleting DomainAggregate'
	   //                 DELETE FROM DomainAggregate
	   //                 WHERE Id IN (
		  //                  SELECT X.UserId
		  //                  FROM #medewerkersIds X
	   //                 )
	                    
	   //                 PRINT 'Deleting Notificatie'
	   //                 DELETE FROM Notificatie
	   //                 WHERE MedewerkerId IN (
		  //                  SELECT X.UserId
		  //                  FROM #medewerkersIds X
	   //                 )

	   //                 PRINT 'Deleting Memos'
	   //                 DELETE FROM Memos
	   //                 WHERE MedewerkerId IN (
		  //                  SELECT X.UserId
		  //                  FROM #medewerkersIds X
	   //                 )

	   //                 PRINT 'Deleting DownloadActivity'
	   //                 DELETE FROM DownloadActivity
	   //                 WHERE MedewerkerId IN (
		  //                  SELECT X.UserId
		  //                  FROM #medewerkersIds X
	   //                 )

	                    
	   //                 PRINT 'Deleting UserRole'
	   //                 DELETE FROM UserRole
	   //                 WHERE UserId IN (
		  //                  SELECT X.UserId
		  //                  FROM #medewerkersIds X
	   //                 )

	   //                 PRINT 'Deleting GroupUser'
	   //                 DELETE FROM GroupUser
	   //                 WHERE UserId IN (
		  //                  SELECT X.UserId
		  //                  FROM #medewerkersIds X
	   //                 )
                        
	   //                 PRINT 'Deleting UserProfile'
	   //                 DELETE FROM UserProfile
	   //                 WHERE Id IN (
		  //                  SELECT X.UserId
		  //                  FROM #medewerkersIds X
	   //                 )
	                    
	   //                 PRINT 'Deleting Medewerker'
	   //                 DELETE M FROM Medewerker M INNER JOIN #medewerkersIds X ON M.UserId = X.UserId

	   //                 PRINT 'Deleting Adres medewerker'
	   //                 DELETE FROM Adres
	   //                 WHERE Id IN (
		  //                  SELECT X.AdresId
		  //                  FROM #medewerkerAdressenIds X
	   //                 )

	   //                 COMMIT TRANSACTION
    //                END TRY
    //                BEGIN CATCH
    //                    SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                    ROLLBACK TRANSACTION
    //                END CATCH


    //                PRINT '======= Organisatie ======='
    //                BEGIN TRANSACTION;
    //                BEGIN TRY
	   //                 DROP TABLE IF EXISTS #organisatieCommandIds;

	   //                 DECLARE @adresId uniqueidentifier;
    //                    SET @adresId = 
    //                    (
    //                        SELECT AdresId 
	   //                     FROM Organisatie
	   //                     WHERE Id = @id
    //                    ) 

	                    
	   //                 SELECT DISTINCT E.CommandId 
	   //                 INTO #organisatieCommandIds
	   //                 FROM DomainEvent E
	   //                 WHERE E.AggregateId = @id

	   //                 PRINT 'Deleting DomainEvent'   
	   //                 DELETE FROM DomainEvent
	   //                 WHERE AggregateId = @id

	   //                 PRINT 'Deleting DomainCommand'
	   //                 DELETE FROM DomainCommand
	   //                 WHERE Id IN (
		  //                  SELECT X.CommandId
		  //                  FROM #organisatieCommandIds X
	   //                 )

	   //                 PRINT 'Deleting DomainAggregate'
	   //                 DELETE FROM DomainAggregate
	   //                 WHERE Id = @id

	   //                 PRINT 'Deleting Organisatie'
	   //                 DELETE O FROM Organisatie O WHERE Id = @id	

	   //                 PRINT 'Deleting Adres'
	   //                 DELETE FROM Adres
	   //                 WHERE Id = @adresId

	   //                 COMMIT TRANSACTION
    //                END TRY
    //                BEGIN CATCH
    //                    SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
    //                    RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    //                    ROLLBACK TRANSACTION
    //                END CATCH

    //                ";

    //    return await RawSQLAsync(sql);

    //}


    ///// <inheritdoc/>
    //public async Task<int> VerwijderOrganisatieEventLog(Guid organisatieId)
    //{
    //    var sql = @"
    //                BEGIN TRANSACTION;
    //                BEGIN TRY                     
	   //                 -- Events
    //                    DELETE DE
    //                    FROM DomainEvent DE
    //                    LEFT OUTER JOIN Organisatie O on DE.AggregateId = O.Id 
    //                    WHERE DE.AggregateId = '" + organisatieId + "'" + @"

    //                    DELETE DC
    //                    FROM DomainCommand DC
    //                    LEFT OUTER JOIN Organisatie O on DC.AggregateId = O.Id 
    //                    WHERE DC.AggregateId = '" + organisatieId + "'" + @"

    //                    DELETE DA
    //                    FROM DomainAggregate DA
    //                    LEFT OUTER JOIN Organisatie O on DA.Id = O.Id 
    //                    WHERE DA.Id = '" + organisatieId + "'" + @"


    //                   COMMIT TRANSACTION;
    //                END TRY
    //                BEGIN CATCH
    //                  ROLLBACK TRANSACTION;
    //                END CATCH";

    //    return await RawSQLAsync(sql);

    //}

}