using Microsoft.Data.SqlClient;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;


namespace Promeetec.EDMS.Data.Repositories;

public class AanleverberichtRepository : Repository<Aanleverbericht>, IAanleverberichtRepository
{
    public AanleverberichtRepository(EDMSDbContext context)
        : base(context)
    {
    }

    public AanleverberichtDto GetAanleverbericht(Guid id, Guid aanleveringId)
    {
        var sql = @"SELECT
                        AB.Id,
                        AB.ParentId,
                        AB.AanleverberichtStatus,
                        AB.Gelezen,
                        AB.GeplaatstOp,
                        AB.Volgorde,
                        AB.Onderwerp,
                        AB.Bericht,
                        Ontvanger.UserId AS OntvangerId,
                        Ontvanger.Status AS OntvangerStatus,
                        Ontvanger.MedewerkerSoort AS OntvangerMedewerkerSoort,
                        Ontvanger.Avatar AS OntvangerAvatar,
                        Ontvanger.VolledigeNaam AS OntvangerNaam,
                        Ontvanger.Email AS OntvangerEmail,
                        Ontvanger.[Telefoon zakelijk] AS OntvangerTelefoon,
                        Ontvanger.Geslacht AS OntvangerGeslacht,
                        OntvangerProfiel.EmailBijAanleverbericht AS OntvangerEmailBijAanleverbericht,
                        OntvangerProfiel.CarbonCopyAdressen AS OntvangerCarbonCopyAdressen,
                        OntvangerOrganisatie.Id AS OntvangerOrganisatieId,
                        OntvangerOrganisatie.Nummer AS OntvangerOrganisatieNummer,
                        OntvangerOrganisatie.Naam AS OntvangerOrganisatieNaam,
                        OntvangerOrganisatie.Status AS OntvangerOrganisatieStatus,
                        Afzender.UserId AS AfzenderId,
                        Afzender.Status AS AfzenderStatus,
                        Afzender.MedewerkerSoort AS AfzenderMedewerkerSoort,
                        Afzender.Avatar AS AfzenderAvatar,
                        Afzender.VolledigeNaam AS AfzenderNaam,
                        Afzender.Email AS AfzenderEmail,
                        Afzender.[Telefoon zakelijk] AS AfzenderTelefoon,
                        Afzender.Geslacht AS AfzenderGeslacht,
                        AfzenderProfiel.EmailBijAanleverbericht AS AfzenderEmailBijAanleverbericht,
                        AfzenderProfiel.CarbonCopyAdressen AS AfzenderCarbonCopyAdressen,
                        AfzenderOrganisatie.Id AS AfzenderOrganisatieId,
                        AfzenderOrganisatie.Nummer AS AfzenderOrganisatieNummer,
                        AfzenderOrganisatie.Naam AS AfzenderOrganisatieNaam,
                        AfzenderOrganisatie.Status AS AfzenderOrganisatieStatus,
                        A.Id AS AanleveringId,
                        A.Referentie,
                        A.ReferentiePromeetec,
                        Eigenaar.UserId AS EigenaarId,
                        Eigenaar.Status AS EigenaarStatus,
                        Eigenaar.MedewerkerSoort AS EigenaarMedewerkerSoort,
                        Eigenaar.Avatar AS EigenaarAvatar,
                        Eigenaar.VolledigeNaam AS EigenaarNaam,
                        Eigenaar.Email AS EigenaarEmail,
                        Eigenaar.[Telefoon zakelijk] AS EigenaarTelefoon,
                        Eigenaar.Geslacht AS EigenaarGeslacht,
                        EigenaarProfiel.EmailBijAanleverbericht AS EigenaarEmailBijAanleverbericht,
                        EigenaarProfiel.CarbonCopyAdressen AS EigenaarCarbonCopyAdressen,
                        EigenaarOrganisatie.Id AS EigenaarOrganisatieId,
                        EigenaarOrganisatie.Nummer AS EigenaarOrganisatieNummer,
                        EigenaarOrganisatie.Naam AS EigenaarOrganisatieNaam,
                        EigenaarOrganisatie.Status AS EigenaarOrganisatieStatus,
                        Behandelaar.UserId AS BehandelaarId,
                        Behandelaar.Status AS BehandelaarStatus,
                        Behandelaar.MedewerkerSoort AS BehandelaarMedewerkerSoort,
                        Behandelaar.Avatar AS BehandelaarAvatar,
                        Behandelaar.VolledigeNaam AS BehandelaarNaam,
                        Behandelaar.Email AS BehandelaarEmail,
                        Behandelaar.[Telefoon zakelijk] AS BehandelaarTelefoon,
                        Behandelaar.Geslacht AS BehandelaarGeslacht,
                        BehandelaarProfiel.EmailBijAanleverbericht AS BehandelaarEmailBijAanleverbericht,
                        BehandelaarProfiel.CarbonCopyAdressen AS BehandelaarrCarbonCopyAdressen,
                        BehandelaarOrganisatie.Id AS BehandelaarOrganisatieId,
                        BehandelaarOrganisatie.Nummer AS BehandelaarOrganisatieNummer,
                        BehandelaarOrganisatie.Naam AS BehandelaarOrganisatieNaam,
                        BehandelaarOrganisatie.Status AS BehandelaarOrganisatieStatus,
                        Organisatie.Id AS OrganisatieId,
                        Organisatie.Nummer AS OrganisatieNummer,
                        Organisatie.Naam AS OrganisatieNaam,
                        Organisatie.Status AS OrganisatieStatus

                        FROM Aanleverbericht AS AB
                        INNER JOIN Aanlevering AS A on A.Id = AB.AanleveringId
                        INNER JOIN Medewerker AS Ontvanger ON AB.OntvangerId = Ontvanger.UserId
                        INNER JOIN UserProfile AS OntvangerProfiel ON Ontvanger.UserId = OntvangerProfiel.Id
                        INNER JOIN Organisatie AS OntvangerOrganisatie on Ontvanger.OrganisatieId = OntvangerOrganisatie.Id
                        INNER JOIN Medewerker AS Afzender ON AB.AfzenderId = Afzender.UserId
                        INNER JOIN UserProfile AS AfzenderProfiel ON Afzender.UserId = AfzenderProfiel.Id
                        INNER JOIN Organisatie AS AfzenderOrganisatie on Afzender.OrganisatieId = AfzenderOrganisatie.Id
                        INNER JOIN Medewerker AS Eigenaar ON A.EigenaarId = Eigenaar.UserId
                        INNER JOIN UserProfile AS EigenaarProfiel ON Eigenaar.UserId = EigenaarProfiel.Id
                        INNER JOIN Organisatie AS EigenaarOrganisatie on Eigenaar.OrganisatieId = EigenaarOrganisatie.Id
                        INNER JOIN Medewerker AS Behandelaar ON A.BehandelaarId = Behandelaar.UserId
                        INNER JOIN UserProfile AS BehandelaarProfiel ON Behandelaar.UserId = BehandelaarProfiel.Id
                        INNER JOIN Organisatie AS BehandelaarOrganisatie on Behandelaar.OrganisatieId = BehandelaarOrganisatie.Id
                        INNER JOIN Organisatie AS Organisatie on A.OrganisatieId = Organisatie.Id
                        WHERE AB.Id = @id AND AB.AanleveringId = @aanleveringId
                    ";

        var result = SqlQueryRaw<AanleverberichtDto>(sql, new SqlParameter("@id", id), new SqlParameter("@aanleveringId", aanleveringId)).FirstOrDefault();
        return result;

       // return SqlQuery<AanleverberichtDto>(sql, new SqlParameter("@id", id), new SqlParameter("@aanleveringId", aanleveringId)).FirstOrDefault();
    }

    //public List<AanleverberichtDto> GetReplies(Guid hoofdberichtId)
    //{
    //    var sql = @"SELECT
    //                    AB.Id,
    //                    AB.ParentId,
    //                    AB.AanleverberichtStatus,
    //                    AB.Gelezen,
    //                    AB.GeplaatstOp,
    //                    AB.Volgorde,
    //                    AB.Onderwerp,
    //                    AB.Bericht,
    //                    Ontvanger.UserId AS OntvangerId,
    //                    Ontvanger.Status AS OntvangerStatus,
    //                    Ontvanger.MedewerkerSoort AS OntvangerMedewerkerSoort,
    //                    Ontvanger.Avatar AS OntvangerAvatar,
    //                    Ontvanger.VolledigeNaam AS OntvangerNaam,
    //                    Ontvanger.Email AS OntvangerEmail,
    //                    Ontvanger.[Telefoon zakelijk] AS OntvangerTelefoon,
    //                    Ontvanger.Geslacht AS OntvangerGeslacht,
    //                    OntvangerProfiel.EmailBijAanleverbericht AS OntvangerEmailBijAanleverbericht,
    //                    OntvangerProfiel.CarbonCopyAdressen AS OntvangerCarbonCopyAdressen,
    //                    OntvangerOrganisatie.Id AS OntvangerOrganisatieId,
    //                    OntvangerOrganisatie.Nummer AS OntvangerOrganisatieNummer,
    //                    OntvangerOrganisatie.Naam AS OntvangerOrganisatieNaam,
    //                    OntvangerOrganisatie.Status AS OntvangerOrganisatieStatus,
    //                    Afzender.UserId AS AfzenderId,
    //                    Afzender.Status AS AfzenderStatus,
    //                    Afzender.MedewerkerSoort AS AfzenderMedewerkerSoort,
    //                    Afzender.Avatar AS AfzenderAvatar,
    //                    Afzender.VolledigeNaam AS AfzenderNaam,
    //                    Afzender.Email AS AfzenderEmail,
    //                    Afzender.[Telefoon zakelijk] AS AfzenderTelefoon,
    //                    Afzender.Geslacht AS AfzenderGeslacht,
    //                    AfzenderProfiel.EmailBijAanleverbericht AS AfzenderEmailBijAanleverbericht,
    //                    AfzenderProfiel.CarbonCopyAdressen AS AfzenderCarbonCopyAdressen,
    //                    AfzenderOrganisatie.Id AS AfzenderOrganisatieId,
    //                    AfzenderOrganisatie.Nummer AS AfzenderOrganisatieNummer,
    //                    AfzenderOrganisatie.Naam AS AfzenderOrganisatieNaam,
    //                    AfzenderOrganisatie.Status AS AfzenderOrganisatieStatus,
    //                    A.Id AS AanleveringId,
    //                    A.Referentie,
    //                    A.ReferentiePromeetec,
    //                    Eigenaar.UserId AS EigenaarId,
    //                    Eigenaar.Status AS EigenaarStatus,
    //                    Eigenaar.MedewerkerSoort AS EigenaarMedewerkerSoort,
    //                    Eigenaar.Avatar AS EigenaarAvatar,
    //                    Eigenaar.VolledigeNaam AS EigenaarNaam,
    //                    Eigenaar.Email AS EigenaarEmail,
    //                    Eigenaar.[Telefoon zakelijk] AS EigenaarTelefoon,
    //                    Eigenaar.Geslacht AS EigenaarGeslacht,
    //                    EigenaarProfiel.EmailBijAanleverbericht AS EigenaarEmailBijAanleverbericht,
    //                    EigenaarProfiel.CarbonCopyAdressen AS EigenaarCarbonCopyAdressen,
    //                    EigenaarOrganisatie.Id AS EigenaarOrganisatieId,
    //                    EigenaarOrganisatie.Nummer AS EigenaarOrganisatieNummer,
    //                    EigenaarOrganisatie.Naam AS EigenaarOrganisatieNaam,
    //                    EigenaarOrganisatie.Status AS EigenaarOrganisatieStatus,
    //                    Behandelaar.UserId AS BehandelaarId,
    //                    Behandelaar.Status AS BehandelaarStatus,
    //                    Behandelaar.MedewerkerSoort AS BehandelaarMedewerkerSoort,
    //                    Behandelaar.Avatar AS BehandelaarAvatar,
    //                    Behandelaar.VolledigeNaam AS BehandelaarNaam,
    //                    Behandelaar.Email AS BehandelaarEmail,
    //                    Behandelaar.[Telefoon zakelijk] AS BehandelaarTelefoon,
    //                    Behandelaar.Geslacht AS BehandelaarGeslacht,
    //                    BehandelaarProfiel.EmailBijAanleverbericht AS BehandelaarEmailBijAanleverbericht,
    //                    BehandelaarProfiel.CarbonCopyAdressen AS BehandelaarrCarbonCopyAdressen,
    //                    BehandelaarOrganisatie.Id AS BehandelaarOrganisatieId,
    //                    BehandelaarOrganisatie.Nummer AS BehandelaarOrganisatieNummer,
    //                    BehandelaarOrganisatie.Naam AS BehandelaarOrganisatieNaam,
    //                    BehandelaarOrganisatie.Status AS BehandelaarOrganisatieStatus,
    //                    Organisatie.Id AS OrganisatieId,
    //                    Organisatie.Nummer AS OrganisatieNummer,
    //                    Organisatie.Naam AS OrganisatieNaam,
    //                    Organisatie.Status AS OrganisatieStatus

    //                    FROM 
    //                    Aanleverbericht AS AB
    //                    INNER JOIN Aanlevering AS A on A.Id = AB.AanleveringId
    //                    INNER JOIN Medewerker AS Ontvanger ON AB.OntvangerId = Ontvanger.UserId
    //                    INNER JOIN UserProfile AS OntvangerProfiel ON Ontvanger.UserId = OntvangerProfiel.Id
    //                    INNER JOIN Organisatie AS OntvangerOrganisatie on Ontvanger.OrganisatieId = OntvangerOrganisatie.Id
    //                    INNER JOIN Medewerker AS Afzender ON AB.AfzenderId = Afzender.UserId
    //                    INNER JOIN UserProfile AS AfzenderProfiel ON Afzender.UserId = AfzenderProfiel.Id
    //                    INNER JOIN Organisatie AS AfzenderOrganisatie on Afzender.OrganisatieId = AfzenderOrganisatie.Id
    //                    INNER JOIN Medewerker AS Eigenaar ON A.EigenaarId = Eigenaar.UserId
    //                    INNER JOIN UserProfile AS EigenaarProfiel ON Eigenaar.UserId = EigenaarProfiel.Id
    //                    INNER JOIN Organisatie AS EigenaarOrganisatie on Eigenaar.OrganisatieId = EigenaarOrganisatie.Id
    //                    INNER JOIN Medewerker AS Behandelaar ON A.BehandelaarId = Behandelaar.UserId
    //                    INNER JOIN UserProfile AS BehandelaarProfiel ON Behandelaar.UserId = BehandelaarProfiel.Id
    //                    INNER JOIN Organisatie AS BehandelaarOrganisatie on Behandelaar.OrganisatieId = BehandelaarOrganisatie.Id
    //                    INNER JOIN Organisatie AS Organisatie on A.OrganisatieId = Organisatie.Id
    //                    WHERE AB.ParentId = @hoofdberichtId
    //                    ORDER BY AB.GeplaatstOp DESC
    //                ";

    //    return SqlQuery<AanleverberichtDto>(sql, new SqlParameter("@hoofdberichtId", hoofdberichtId)).ToList();
    //}


    //public List<AanleverberichtenDto> GetAlleAanleverberichtenVanAanlevering(Guid aanleveringId)
    //{
    //    var sql = @"SELECT
    //                    AB.Id,
    //                    AB.ParentId,
    //                    AB.Volgorde,
    //                    AB.Gelezen,
    //                    AB.Onderwerp,
    //                    AB.Bericht,
    //                    AB.LaastGelezenOp,
    //                    AB.GeplaatstOp,
    //                    AB.AanleverberichtStatus,
    //                    A.Id AS AanleveringId,
    //                    A.Referentie,
    //                    A.ReferentiePromeetec,
    //                    Organisatie.Id AS OrganisatieId,
    //                    Organisatie.Nummer AS OrganisatieNummer,
    //                    Organisatie.Naam AS OrganisatieNaam,
    //                    Eigenaar.UserId AS EigenaarId,
    //                    Eigenaar.OrganisatieId AS EigenaarOrganisatieId,
    //                    Eigenaar.VolledigeNaam AS EigenaarVolledigeNaam,
    //                    Eigenaar.FormeleNaam AS EigenaarFormeleNaam,
    //                    Behandelaar.UserId AS BehandelaarId,
    //                    Behandelaar.OrganisatieId AS BehandelaarOrganisatieId,
    //                    Behandelaar.VolledigeNaam AS BehandelaarVolledigeNaam,
    //                    Behandelaar.FormeleNaam AS BehandelaarFormeleNaam,
    //                    Afzender.UserId AS AfzenderId,
    //                    Afzender.OrganisatieId AS AfzenderOrganisatieId,
    //                    Afzender.VolledigeNaam AS AfzenderVolledigeNaam,
    //                    Afzender.FormeleNaam AS AfzenderFormeleNaam,
    //                    Afzender.Avatar AS AfzenderAvatar,
    //                    Afzender.Geslacht AS AfzenderGeslacht,
    //                    Ontvanger.UserId AS OntvangerId,                        
    //                    Ontvanger.OrganisatieId AS OntvangerOrganisatieId,   
    //                    Ontvanger.VolledigeNaam AS OntvangerVolledigeNaam,
    //                    Ontvanger.FormeleNaam AS OntvangerFormeleNaam,
    //                    Ontvanger.Avatar AS OntvangerAvatar,
    //                    Ontvanger.Geslacht AS OntvangerGeslacht,
    //                    LaatsteLezer.UserId  AS LaatsteLezerId,
    //                    LaatsteLezer.VolledigeNaam AS LaatsteLezerVolledigeNaam,
    //                    LaatsteLezer.OrganisatieId AS LaatsteLezerOrganisatieId      

    //                    FROM Aanleverbericht AS AB			
    //                    INNER JOIN Aanlevering AS A on AB.AanleveringId = A.Id
    //                    INNER JOIN Organisatie AS Organisatie on A.OrganisatieId = Organisatie.Id		  
    //                    INNER JOIN Medewerker AS Eigenaar ON A.EigenaarId = Eigenaar.UserId
    //                    INNER JOIN Medewerker AS Behandelaar ON A.BehandelaarId = Behandelaar.UserId
    //                    INNER JOIN Medewerker AS Afzender ON AB.AfzenderId = Afzender.UserId
    //                    INNER JOIN Medewerker AS Ontvanger ON AB.OntvangerId = Ontvanger.UserId
    //                    LEFT JOIN Medewerker AS LaatsteLezer ON AB.LaatsteLezerId = LaatsteLezer.UserId   
    //                    WHERE A.Id = @aanleveringId
    //                ";

    //    return SqlQuery<AanleverberichtenDto>(sql, new SqlParameter("@aanleveringId", aanleveringId)).ToList();
    //}

    //public List<AanleverberichtenDto> GetAlleAanleverberichtenVanBehandelaar(Guid behandelaarId)
    //{
    //    var sql = @"SELECT
    //                    AB.Id,
    //                    AB.ParentId,
    //                    AB.Volgorde,
    //                    AB.Gelezen,
    //                    AB.Onderwerp,
    //                    AB.Bericht,
    //                    AB.LaastGelezenOp,
    //                    AB.GeplaatstOp,
    //                    AB.AanleverberichtStatus,
    //                    A.Id AS AanleveringId,
    //                    A.Referentie,
    //                    A.ReferentiePromeetec,
    //                    Organisatie.Id AS OrganisatieId,
    //                    Organisatie.Nummer AS OrganisatieNummer,
    //                    Organisatie.Naam AS OrganisatieNaam,
    //                    Eigenaar.UserId AS EigenaarId,
    //                    Eigenaar.OrganisatieId AS EigenaarOrganisatieId,
    //                    Eigenaar.VolledigeNaam AS EigenaarVolledigeNaam,
    //                    Eigenaar.FormeleNaam AS EigenaarFormeleNaam,
    //                    Behandelaar.UserId AS BehandelaarId,
    //                    Behandelaar.OrganisatieId AS BehandelaarOrganisatieId,
    //                    Behandelaar.VolledigeNaam AS BehandelaarVolledigeNaam,
    //                    Behandelaar.FormeleNaam AS BehandelaarFormeleNaam,
    //                    Afzender.UserId AS AfzenderId,
    //                    Afzender.OrganisatieId AS AfzenderOrganisatieId,
    //                    Afzender.VolledigeNaam AS AfzenderVolledigeNaam,
    //                    Afzender.FormeleNaam AS AfzenderFormeleNaam,
    //                    Afzender.Avatar AS AfzenderAvatar,
    //                    Afzender.Geslacht AS AfzenderGeslacht,
    //                    Ontvanger.UserId AS OntvangerId,                        
    //                    Ontvanger.OrganisatieId AS OntvangerOrganisatieId,   
    //                    Ontvanger.VolledigeNaam AS OntvangerVolledigeNaam,
    //                    Ontvanger.FormeleNaam AS OntvangerFormeleNaam,
    //                    Ontvanger.Avatar AS OntvangerAvatar,
    //                    Ontvanger.Geslacht AS OntvangerGeslacht,
    //                    LaatsteLezer.UserId  AS LaatsteLezerId,
    //                    LaatsteLezer.VolledigeNaam AS LaatsteLezerVolledigeNaam,
    //                    LaatsteLezer.OrganisatieId AS LaatsteLezerOrganisatieId      

    //                    FROM Aanleverbericht AS AB			
    //                    INNER JOIN Aanlevering AS A on AB.AanleveringId = A.Id
    //                    INNER JOIN Organisatie AS Organisatie on A.OrganisatieId = Organisatie.Id		  
    //                    INNER JOIN Medewerker AS Eigenaar ON A.EigenaarId = Eigenaar.UserId
    //                    INNER JOIN Medewerker AS Behandelaar ON A.BehandelaarId = Behandelaar.UserId
    //                    INNER JOIN Medewerker AS Afzender ON AB.AfzenderId = Afzender.UserId
    //                    INNER JOIN Medewerker AS Ontvanger ON AB.OntvangerId = Ontvanger.UserId
    //                    LEFT JOIN Medewerker AS LaatsteLezer ON AB.LaatsteLezerId = LaatsteLezer.UserId   
    //                    WHERE A.BehandelaarId = @behandelaarId
    //                ";

    //    return SqlQuery<AanleverberichtenDto>(sql, new SqlParameter("@behandelaarId", behandelaarId)).ToList();
    //}

    //public List<AanleverberichtenDto> GetAlleAanleverberichten()
    //{
    //    var sql = @"SELECT
    //                    AB.Id,
    //                    AB.ParentId,
    //                    AB.Volgorde,
    //                    AB.Gelezen,
    //                    AB.Onderwerp,
    //                    AB.Bericht,
    //                    AB.LaastGelezenOp,
    //                    AB.GeplaatstOp,
    //                    AB.AanleverberichtStatus,
    //                    A.Id AS AanleveringId,
    //                    A.Referentie,
    //                    A.ReferentiePromeetec,
    //                    Organisatie.Id AS OrganisatieId,
    //                    Organisatie.Nummer AS OrganisatieNummer,
    //                    Organisatie.Naam AS OrganisatieNaam,
    //                    Eigenaar.UserId AS EigenaarId,
    //                    Eigenaar.OrganisatieId AS EigenaarOrganisatieId,
    //                    Eigenaar.VolledigeNaam AS EigenaarVolledigeNaam,
    //                    Eigenaar.FormeleNaam AS EigenaarFormeleNaam,
    //                    Behandelaar.UserId AS BehandelaarId,
    //                    Behandelaar.OrganisatieId AS BehandelaarOrganisatieId,
    //                    Behandelaar.VolledigeNaam AS BehandelaarVolledigeNaam,
    //                    Behandelaar.FormeleNaam AS BehandelaarFormeleNaam,
    //                    Afzender.UserId AS AfzenderId,
    //                    Afzender.OrganisatieId AS AfzenderOrganisatieId,
    //                    Afzender.VolledigeNaam AS AfzenderVolledigeNaam,
    //                    Afzender.FormeleNaam AS AfzenderFormeleNaam,
    //                    Afzender.Avatar AS AfzenderAvatar,
    //                    Afzender.Geslacht AS AfzenderGeslacht,
    //                    Ontvanger.UserId AS OntvangerId,                        
    //                    Ontvanger.OrganisatieId AS OntvangerOrganisatieId,   
    //                    Ontvanger.VolledigeNaam AS OntvangerVolledigeNaam,
    //                    Ontvanger.FormeleNaam AS OntvangerFormeleNaam,
    //                    Ontvanger.Avatar AS OntvangerAvatar,
    //                    Ontvanger.Geslacht AS OntvangerGeslacht,
    //                    LaatsteLezer.UserId  AS LaatsteLezerId,
    //                    LaatsteLezer.VolledigeNaam AS LaatsteLezerVolledigeNaam,
    //                    LaatsteLezer.OrganisatieId AS LaatsteLezerOrganisatieId      

    //                    FROM Aanleverbericht AS AB			
    //                    INNER JOIN Aanlevering AS A on AB.AanleveringId = A.Id
    //                    INNER JOIN Organisatie AS Organisatie on A.OrganisatieId = Organisatie.Id		  
    //                    INNER JOIN Medewerker AS Eigenaar ON A.EigenaarId = Eigenaar.UserId
    //                    INNER JOIN Medewerker AS Behandelaar ON A.BehandelaarId = Behandelaar.UserId
    //                    INNER JOIN Medewerker AS Afzender ON AB.AfzenderId = Afzender.UserId
    //                    INNER JOIN Medewerker AS Ontvanger ON AB.OntvangerId = Ontvanger.UserId
    //                    LEFT JOIN Medewerker AS LaatsteLezer ON AB.LaatsteLezerId = LaatsteLezer.UserId                    ";

    //    return SqlQuery<AanleverberichtenDto>(sql).ToList();
    //}

    //public int GetAantalHoofdberichten()
    //{
    //    var sql = @"SELECT COUNT(Id) FROM Aanleverbericht WHERE ParentId IS NULL";
    //    var result = SqlQuery<int>(sql).First();
    //    return result;
    //}

    //public int GetAantalHoofdberichtenVanAanlevering(Guid aanleveringId)
    //{
    //    var sql = $@"SELECT COUNT(Id) FROM Aanleverbericht WHERE ParentId IS NULL AND AanleveringId = '{aanleveringId}'";
    //    var result = SqlQuery<int>(sql).First();
    //    return result;
    //}
 

    public List<AanleverberichtDto> GetReplies(Guid hoofdberichtId)
    {
        throw new NotImplementedException();
    }

    public List<AanleverberichtenDto> GetAlleAanleverberichtenVanAanlevering(Guid aanleveringId)
    {
        throw new NotImplementedException();
    }

    public List<AanleverberichtenDto> GetAlleAanleverberichtenVanBehandelaar(Guid behandelaarId)
    {
        throw new NotImplementedException();
    }

    public List<AanleverberichtenDto> GetAlleAanleverberichten()
    {
        throw new NotImplementedException();
    }

    public int GetAantalHoofdberichten()
    {
        throw new NotImplementedException();
    }

    public int GetAantalHoofdberichtenVanAanlevering(Guid aanleveringId)
    {
        throw new NotImplementedException();
    }
}