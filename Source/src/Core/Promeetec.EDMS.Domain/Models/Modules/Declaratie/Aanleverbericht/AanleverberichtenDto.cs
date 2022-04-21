using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht
{
    public class AanleverberichtenDto
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public int Volgorde { get; set; }
        public bool Gelezen { get; set; }
        public string Onderwerp { get; set; }
        public string Bericht { get; set; }
        public AanleverberichtStatus AanleverberichtStatus { get; set; }
        public DateTime GeplaatstOp { get; set; }
        public DateTime LaatstGelezenOp { get; set; }


        // Aanlevering
        public Guid AanleveringId { get; set; }
        public string ReferentiePromeetec { get; set; }




        // Eigenaar van bericht
        public Guid AfzenderId { get; set; }
        public Guid AfzenderOrganisatieId { get; set; }
        public string AfzenderVolledigeNaam { get; set; }
        public string AfzenderFormeleNaam { get; set; }
        public byte[] AfzenderAvatar { get; set; }
        public Geslacht AfzenderGeslacht { get; set; }


        // Ontvanger van bericht
        public Guid OntvangerId { get; set; }
        public Guid OntvangerOrganisatieId { get; set; }
        public string OntvangerVolledigeNaam { get; set; }
        public string OntvangerFormeleNaam { get; set; }
        public byte[] OntvangerAvatar { get; set; }
        public Geslacht OntvangerGeslacht { get; set; }



        public Guid? LaatsteLezerId { get; set; }
        public string LaatsteLezerVolledigeNaam { get; set; }
        public Guid? LaatsteLezerOrganisatieId { get; set; }


        // Eigenaar van aanlevering
        public Guid EigenaarId { get; set; }
        public Guid EigenaarOrganisatieId { get; set; }
        public string EigenaarVolledigeNaam { get; set; }
        public string EigenaarFormeleNaam { get; set; }


        // Behandelaar van aanlevering
        public Guid? BehandelaarId { get; set; }
        public Guid BehandelaarOrganisatieId { get; set; }
        public string BehandelaarVolledigeNaam { get; set; }
        public string BehandelaarFormeleNaam { get; set; }


        // Organisatie van aanlevering
        public Guid OrganisatieId { get; set; }
        public string OrganisatieNummer { get; set; }
        public string OrganisatieNaam { get; set; }
    }
}