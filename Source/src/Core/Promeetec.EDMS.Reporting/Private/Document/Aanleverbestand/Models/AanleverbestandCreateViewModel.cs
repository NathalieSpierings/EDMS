using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand;
using Promeetec.EDMS.Reporting.Private.Document.Bestand.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

public class AanleverbestandCreateViewModel : BestandCreateViewModel
{
    public AanleverbestandWorkflowState WorkFlowState { get; set; }

    [UIHint("Boolean")]
    public bool Gecontroleerd { get; set; }

    [Display(Name = "EI-standaard")]
    public string Vektisstandaard { get; set; }


    [Display(Name = "Aantal verzekerden")]
    public int? AantalVerzekerderecords { get; set; }


    [Display(Name = "Aantal prestaties")]
    public int? AantalPrestatierecords { get; set; }

    public decimal? Totaalbedrag { get; set; }


    public Guid? VoorraadId { get; set; }
    public Guid? AanleveringId { get; set; }


    [Display(Name = "Zorgstraat")]
    [Required(ErrorMessage = "Zorgstraat is verplicht.")]
    public Guid? ZorgstraatId { get; set; }

    [Display(Name = "Zorgstraat")]
    public SelectList Zorgstraten { get; set; }


    [Display(Name = "Periodes")]
    [Required(ErrorMessage = "Periode is verplicht.")]
    public string Periode { get; set; }

    [Display(Name = "Periodes")]
    public SelectList Periodes { get; set; }


    public FilesViewModel Files { get; set; } = new();
}