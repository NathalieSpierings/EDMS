using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Modules.Ketenzorg;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

/// <summary>
/// Represents a viewmodel based on the Authorization class.
/// </summary>
public class MachtigingViewModel : ModelBase
{
    public string ApiError { get; set; }

    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string OrganisatieNummer { get; set; }


    [DisplayName("ZD-nummer")]
    public string ZDNummer { get; set; }


    [DisplayName("AGB-code verwijzer")]
    public string AgbcodeVerwijzer { get; set; }


    [DisplayName("Naam verwijzer")]
    public string NaamVerwijzer { get; set; }


    public string Voorletters { get; set; }
    public string Tussenvoegsel { get; set; }
    public string Achternaam { get; set; }
    public string TussenvoegselPartner { get; set; }
    public string AchternaamPartner { get; set; }


    private string _volledigeNaam;

    [DisplayName("Naam")]
    public string VolledigeNaam
    {
        get
        {
            if (string.IsNullOrEmpty(_volledigeNaam))
                _volledigeNaam = PersoonExtensions.SetVolledigeNaamMetPartner(Voorletters, Tussenvoegsel, Achternaam, TussenvoegselPartner, AchternaamPartner);

            return _volledigeNaam;
        }
        set => _volledigeNaam = value;
    }


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


    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime Geboortedatum { get; set; }


    [DisplayName("BSN")]
    public string Bsn { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime Startdatum { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime? Einddatum { get; set; }

    public MachtigingStatus Status { get; set; }

    public int MaxRegistrationRetroPeriodDays { get; set; }

    public MachtigingProductViewModel Product { get; set; }
    public List<MachtigingRegistratieViewModel> Registraties { get; set; } = new();
}


/// <summary>
/// Represents a viewmodel based on the AuthorizationProduct class.
/// </summary>
public class MachtigingProductViewModel : ModelBase
{
    public Guid Id { get; set; }

    [DisplayName("Zorgproduct")]
    public string Naam { get; set; }

    public IList<MachtigingActiviteitGroepViewModel> ActiviteitGroepen { get; set; }
}

/// <summary>
/// Represents a viewmodel based on the ActivityGroup class.
/// </summary>
public class MachtigingActiviteitGroepViewModel : ModelBase
{
    public int Id { get; set; }
    public int MaxAantal { get; set; }
    public int ResterendAantal { get; set; }

    public List<MachtigingProductActiviteitViewModel> Activiteiten { get; set; }
}

/// <summary>
/// Represents a viewmodel based on the ProductActivity class.
/// </summary>
public class MachtigingProductActiviteitViewModel : ModelBase
{
    public Guid Id { get; set; }
    public ZorgproductEenheid Eenheid { get; set; }

    [DisplayName("Zorgproduct")]
    public string Naam { get; set; }
    public decimal Tarief { get; set; }
    public string Opmerking { get; set; }

    /// <summary>
    /// De Selectlist wordt opgebouwd uit alle Id's en Namen van de activiteiten binnen de activitygroups van het product.
    /// Als de gebruiker een activiteit kies waarvan de MaxAantal 0 is, wordt er een remark getoond waarin aangegeven wordt waarom deze activiteit niet meer gekozen kan worden.
    /// </summary>
    [Display(Name = "Activiteit")]
    public Guid ActiviteitId { get; set; }
    public SelectList Activiteiten { get; set; }
}