using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Modules.Ketenzorg;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

/// <summary>
/// Represents a viewmodel based on the Registration class.
/// </summary>
public class MachtigingRegistratieViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid MachtigingId { get; set; }
    public int ActiviteitGroepId { get; set; }
    public Guid ActiviteitId { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    [DisplayName("Behandeldatum")]
    public DateTime Behandeldatum { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime Registratiedatum { get; set; }

    public int MaxAantal { get; set; }
    public int ResterendAantal { get; set; }
    public ZorgproductEenheid Eenheid { get; set; }
    public int Aantal { get; set; }
    public decimal Tarief { get; set; }
    public string Naam { get; set; }
    public string Opmerking { get; set; }
    public bool Verwerkt { get; set; }
    public MachtigingRegistratieViewModel Credit { get; set; }
}