using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Bestand.Models;

public class BestandCreateViewModel : ModelBase
{
    public Guid Id { get; set; }


    [Display(Name = "Bestandsnaam")]
    public string FileName { get; set; }


    [Display(Name = "Bestand grootte")]
    public int FileSize { get; set; }


    [Display(Name = "Extensie")]
    public string Extension { get; set; }


    public string MimeType { get; set; }

    public byte[] Data { get; set; }


    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangemaakt op")]
    public DateTime AangemaaktOp { get; set; }


    [Display(Name = "Aangemaakt door")]
    public string AangemaaktDoorNaam { get; set; }

    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangepast op")]
    public DateTime? AangepastOp { get; set; }


    [Display(Name = "Aangepast door")]
    public string AangepastDoorNaam { get; set; }


    [Display(Name = "Eigenaar")]
    [Required(ErrorMessage = "Eigenaar is verplicht.")]
    public Guid EigenaarId { get; set; }

    [Display(Name = "Eigenaar")]
    public SelectList Eigenaren { get; set; }

    public OrganisatieViewModel Organisatie { get; set; }
}