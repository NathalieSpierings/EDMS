using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Bestand.Models;

public class BestandViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Bestandsnaam")]
    public string FileName { get; set; }


    [Display(Name = "Bestand grootte")]
    public int FileSize { get; set; }


    [Display(Name = "Extensie")]
    public string Extension { get; set; }

    public string MimeType { get; set; }


    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangemaakt op")]
    public DateTime AangemaaktOp { get; set; }


    [Display(Name = "Aangemaakt door")]
    public string AangemaaktDoor { get; set; }
    public Guid? AangemaaktDoorId { get; set; }

    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangepast op")]
    public DateTime? AangepastOp { get; set; }

    [Display(Name = "Aangepast door")]
    public string AangepastDoor { get; set; }
    public Guid? AangepastDoorId { get; set; }

    public MedewerkerViewModel Eigenaar { get; set; }
    public OrganisatieViewModel Organisatie { get; set; }
}