using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

public class ZorgverzekeringViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "Verzekerdenummer")]
    public string VerzekerdeNummer { get; set; }


    [Display(Name = "Patientnummer")]
    public string PatientNummer { get; set; }


    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    public DateTime VerzekerdOp { get; set; }


    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    public DateTime? VerzekerdTot { get; set; }


    [Display(Name = "Verzekeraar")]
    public Guid VerzekeraarId { get; set; }

    public VerzekeraarViewModel Verzekeraar { get; set; }
}