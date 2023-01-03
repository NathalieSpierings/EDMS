using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Models;

public class VerzekeraarViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "UZOVI-code")]
    public short Uzovi { get; set; }

    [Display(Name = "Zorgverzekeraar")]
    public string Naam { get; set; }

    public bool Actief { get; set; }
}