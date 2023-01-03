using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;
using Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

public class AanleveringViewModel : ModelBase
{
    public Guid Id { get; set; }

    public int Jaar { get; set; }

    [Display(Name = "Uw referentie")]
    public string Referentie { get; set; }


    [Display(Name = "Referentie Promeetec")]
    public string ReferentiePromeetec { get; set; }


    [Display(Name = "Aanleverstatus")]
    public AanleverStatus AanleverStatus { get; set; }


    [AllowHtml]
    [Display(Name = "Opmerking")]
    [DataType(DataType.MultilineText)]
    public string Opmerking { get; set; }


    [Display(Name = "Toevoegen documenten")]
    public bool ToevoegenBestand { get; set; }


    public Status Status { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    [Display(Name = "Aanleverdatum")]
    public DateTime Aanleverdatum { get; set; }


    [Display(Name = "Aangemaakt door")]
    public string AangemaaktDoor { get; set; }
    public Guid? AangemaaktDoorId { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangepast op")]
    public DateTime? AangepastOp { get; set; }

    [Display(Name = "Aangepast door")]
    public string AangepastDoor { get; set; }

    public Guid? AangepastDoorId { get; set; }


    [Display(Name = "Behandelaar")]
    public Guid? BehandelaarId { get; set; }

    public MedewerkerViewModel Behandelaar { get; set; }

    public MedewerkerViewModel Eigenaar { get; set; }

    public OrganisatieViewModel Organisatie { get; set; }

    public AanleverbestandenViewModel Aanleverbestanden { get; set; }
    public OverigbestandenViewModel Overigebestanden { get; set; }

    public int AantalBerichten { get; set; }
    public int AantalAanleverbestanden { get; set; }
    public int AantalOverigebestanden { get; set; }
}