using System;
using System.Collections.Generic;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Modules.Ketenzorg;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

/// <summary>
/// Represents a viewmodel based on the Invoice class.
/// </summary>
public class KetenzorgFactuurViewModel : ModelBase
{
    public string ApiError { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNummer { get; set; }
    public string OrganisatieNaam { get; set; }
    public string OrganisatieBankrekeningNummer { get; set; }

    public Guid Id { get; set; }
    public Guid FactuurPeriodeId { get; set; }

    public string ZorggroepNaam { get; set; }
    public string ZorggroepAgbcode { get; set; }
    public string Footer { get; set; }
    public string Logo { get; set; }
    public string Titel => $"Factuur {Factuurnummer}";

    public string Factuurnummer { get; set; }
    public decimal Totaalbedrag { get; set; }
    public string DebiteurNummer { get; set; }
    public DateTime AangemaaktOp { get; set; }
    public List<FactuurRegistratieViewModel> Registraties { get; set; } = new();

}

public class FactuurRegistratieViewModel : ModelBase
{
    public string Voorletters { get; set; }
    public string Tussenvoegsel { get; set; }
    public string Achternaam { get; set; }
    public string TussenvoegselPartner { get; set; }
    public string AchternaamPartner { get; set; }

    private string _formeleNaam;
    public string FormeleNaam
    {
        get
        {
            if (string.IsNullOrEmpty(_formeleNaam))
                _formeleNaam = PersoonExtensions.SetFormeleNaamMetPartner(Voorletters, Tussenvoegsel, Achternaam, TussenvoegselPartner, AchternaamPartner);

            return _formeleNaam;
        }
        set => _formeleNaam = value;
    }

    public DateTime Geboortedatum { get; set; }
    public string Bsn { get; set; }

    public decimal Subtotaal { get; set; }

    // Activiteit
    public Guid ActiviteitId { get; set; }
    public DateTime Behandeldatum { get; set; }
    public string Naam { get; set; }
    public int Aantal { get; set; }
    public ZorgproductEenheid Eenheid { get; set; }
    public decimal Tarief { get; set; }
}