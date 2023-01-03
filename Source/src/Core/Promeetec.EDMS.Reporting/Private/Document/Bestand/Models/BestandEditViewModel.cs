using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Bestand.Models;

public class BestandEditViewModel : ModelBase
{
    public Guid Id { get; set; }


    [Display(Name = "Bestandsnaam")]
    public string FileName { get; set; }

    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangepast op")]
    public DateTime? AangepastOp { get; set; }


    [Display(Name = "Aangepast door")]
    public string AangepastDoorNaam { get; set; }


    [Required(ErrorMessage = "Eigenaar is verplicht.")]
    public Guid EigenaarId { get; set; }
    public SelectList Eigenaren { get; set; }

}