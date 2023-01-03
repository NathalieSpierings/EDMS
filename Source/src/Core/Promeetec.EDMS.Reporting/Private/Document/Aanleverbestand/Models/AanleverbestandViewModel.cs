using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand;
using Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Models;
using Promeetec.EDMS.Reporting.Private.Document.Bestand.Models;
using Promeetec.EDMS.Reporting.Vektis.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Aanleverbestand.Models;

public class AanleverbestandViewModel : BestandViewModel
{
    public string Periode { get; set; }

    [UIHint("Boolean")]
    public bool Gecontroleerd { get; set; }


    [Display(Name = "Soort bestand")]
    public AanleverbestandWorkflowState WorkFlowState { get; set; }

    public AanleverbestandSamenvattingViewModel Samenvatting { get; set; }

    public Guid? VoorraadId { get; set; }
    public Guid? AanleveringId { get; set; }

    public Guid? ZorgstraatId { get; set; }
    public ZorgstraatViewModel Zorgstraat { get; set; }

    public AgbViewModel Agb { get; set; }
}