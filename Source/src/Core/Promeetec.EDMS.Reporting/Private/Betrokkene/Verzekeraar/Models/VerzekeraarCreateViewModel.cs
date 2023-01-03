using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Models;

public class VerzekeraarCreateViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "UZOVI-code")]
    [Required(ErrorMessage = "UZOVI-code is verplicht.")]
    public short Uzovi { get; set; }

    [Display(Name = "Zorgverzekeraar")]
    [Required(ErrorMessage = "Naam verzekeraar is verplicht.")]
    [StringLength(256, ErrorMessage = "{0} bestaat uit maximaal {1} tekens.")]
    public string Naam { get; set; }

    public bool Actief { get; set; }
}