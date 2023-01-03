using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

public class AanleveringDetailsViewModel : ModelBase
{
    public Guid Id { get; set; }

    public int Jaar { get; set; }


    [Display(Name = "Uw referentie")]
    public string Referentie { get; set; }


    [Display(Name = "Referentie Promeetec")]
    public string ReferentiePromeetec { get; set; }


    [Display(Name = "Opmerking")]
    [DataType(DataType.MultilineText)]
    public string Opmerking { get; set; }

    [Display(Name = "Toevoegen bestanden")]
    public bool ToevoegenBestand { get; set; }

    public Status Status { get; set; }

    [Display(Name = "Aanleverstatus")]
    public AanleverStatus AanleverStatus { get; set; }


    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Aanleverdatum")]
    public DateTime Aanleverdatum { get; set; }

    [Display(Name = "Aangeleverd door")]
    public string AangemaaktDoor { get; set; }
    public Guid? AangemaaktDoorId { get; set; }


    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangepast op")]
    public DateTime? AangepastOp { get; set; }

    [Display(Name = "Aangepast door")]
    public string AangepastDoor { get; set; }
    public Guid? AangepastDoorId { get; set; }



    public Guid EigenaarId { get; set; }

    [Display(Name = "Eigenaar")]
    public string EigenaarVolledigeNaam { get; set; }

    public Guid? BehandelaarId { get; set; }

    [Display(Name = "Behandelaar")]
    public string BehandelaarVolledigeNaam { get; set; }
    public OrganisatieViewModel Organisatie { get; set; }
}