using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht
{
    public class AanleverberichtDto
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public AanleverberichtStatus AanleverberichtStatus { get; set; }
        public bool Gelezen { get; set; }
        public DateTime GeplaatstOp { get; set; }
        public int Volgorde { get; set; }
        public string Onderwerp { get; set; }
        public string Bericht { get; set; }

        public Guid OntvangerId { get; set; }
        public Status OntvangerStatus { get; set; }
        public byte[] OntvangerAvatar { get; set; }
        public MedewerkerSoort OntvangerMedewerkerSoort { get; set; }
        public string OntvangerNaam { get; set; }
        public string OntvangerEmail { get; set; }
        public string OntvangerTelefoon { get; set; }
        public Geslacht OntvangerGeslacht { get; set; }
        public EmailOntvangenType OntvangerEmailBijAanleverbericht { get; set; }
        public string OntvangerCarbonCopyAdressen { get; set; }
        public Guid OntvangerOrganisatieId { get; set; }
        public string OntvangerOrganisatieNummer { get; set; }
        public string OntvangerOrganisatieNaam { get; set; }
        public Status OntvangerOrganisatieStatus { get; set; }


        public Guid AfzenderId { get; set; }
        public Status AfzenderStatus { get; set; }
        public byte[] AfzenderAvatar { get; set; }
        public MedewerkerSoort AfzenderMedewerkerSoort { get; set; }
        public string AfzenderNaam { get; set; }
        public string AfzenderEmail { get; set; }
        public string AfzenderTelefoon { get; set; }
        public Geslacht AfzenderGeslacht { get; set; }
        public EmailOntvangenType AfzenderEmailBijAanleverbericht { get; set; }
        public string AfzenderCarbonCopyAdressen { get; set; }
        public Guid AfzenderOrganisatieId { get; set; }
        public string AfzenderOrganisatieNummer { get; set; }
        public string AfzenderOrganisatieNaam { get; set; }
        public Status AfzenderOrganisatieStatus { get; set; }


        public Guid AanleveringId { get; set; }
        public string Referentie { get; set; }
        public string ReferentiePromeetec { get; set; }


        // Eigenaar van aanlevering
        public Guid EigenaarId { get; set; }
        public Status EigenaarStatus { get; set; }
        public MedewerkerSoort EigenaarMedewerkerSoort { get; set; }
        public byte[] EigenaarAvatar { get; set; }
        public string EigenaarNaam { get; set; }
        public string EigenaarEmail { get; set; }
        public string EigenaarTelefoon { get; set; }
        public Geslacht EigenaarGeslacht { get; set; }
        public EmailOntvangenType EigenaarEmailBijAanleverbericht { get; set; }
        public string EigenaarCarbonCopyAdressen { get; set; }
        public Guid EigenaarOrganisatieId { get; set; }
        public string EigenaarOrganisatieNummer { get; set; }
        public string EigenaarOrganisatieNaam { get; set; }
        public Status EigenaarOrganisatieStatus { get; set; }

        // Behandelaar van aanlevering
        public Guid? BehandelaarId { get; set; }
        public Status BehandelaarStatus { get; set; }
        public MedewerkerSoort BehandelaarMedewerkerSoort { get; set; }
        public byte[] BehandelaarAvatar { get; set; }
        public string BehandelaarNaam { get; set; }
        public string BehandelaarEmail { get; set; }
        public string BehandelaarTelefoon { get; set; }
        public Geslacht BehandelaarGeslacht { get; set; }
        public EmailOntvangenType BehandelaarEmailBijAanleverbericht { get; set; }
        public string BehandelaarCarbonCopyAdressen { get; set; }
        public Guid BehandelaarOrganisatieId { get; set; }
        public string BehandelaarOrganisatieNummer { get; set; }
        public string BehandelaarOrganisatieNaam { get; set; }
        public Status BehandelaarOrganisatieStatus { get; set; }

        public Guid OrganisatieId { get; set; }
        public string OrganisatieNummer { get; set; }
        public string OrganisatieNaam { get; set; }
        public Status OrganisatieStatus { get; set; }

    }
}