using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

public class AanleverbestandSamenvattingViewModel : ModelBase
{
    public Guid Id { get; set; }


    [Display(Name = "EI-standaard")]
    public string EiStandaard { get; set; }


    [Display(Name = "Aantal verzekerden")]
    public int? AantalVerzekerdeRecords { get; set; }


    [Display(Name = "Aantal prestaties")]
    public int? AantalPrestatierecords { get; set; }

    [UIHint("Numeric")]
    [Display(Name = "Totaal declaratiebedrag")]
    public decimal? Totaalbedrag { get; set; }


    [Display(Name = "AGB-code zorgverlener")]
    public int? AgbCodeZorgverlener { get; set; }


    [Display(Name = "AGB-code praktijk")]
    public int? AgbCodePraktijk { get; set; }


    [Display(Name = "AGB-code onderneming/vestiging")]
    public int? AgbCodeOnderneming { get; set; }


    [Display(Name = "Aantal overgeslagen regels")]
    public int OvergeslagenRows { get; set; }

    public bool Processed { get; set; }

    public Guid AanleverbestandId { get; set; }
}