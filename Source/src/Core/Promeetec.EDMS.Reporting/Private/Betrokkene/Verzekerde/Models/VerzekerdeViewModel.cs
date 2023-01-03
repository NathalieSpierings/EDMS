using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

public class VerzekerdeViewModel : ModelBase
{
    public Guid AdresboekId { get; set; }
    public OrganisatieModel Organisatie { get; set; }

    public Status Status { get; set; }
    public bool Shared { get; set; }

    public Geslacht Geslacht { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Geboortedatum { get; set; }

    public string FormeleNaam { get; set; }
    public string VolledigeNaam { get; set; }
    public string Achternaam { get; set; }


    [Display(Name = "Burgerservicenummer")]
    public string Bsn { get; set; }

    public double? Lengte { get; set; }


    [Display(Name = "AGB-code verwijzer")]
    public string AgbCodeVerwijzer { get; set; }


    [Display(Name = "Naam verwijzer")]
    public string NaamVerwijzer { get; set; }

    [DataType(DataType.Date)]
    public DateTime? Verwijsdatum { get; set; }

    public string VerzekeraarNaam { get; set; }
    public string Uzovi { get; set; }
    public string VerzekeraarDisplayName => string.Concat(VerzekeraarNaam, " [", Uzovi, "]");
    public string VerzekerdeNummer { get; set; }
    public string PatientNummer { get; set; }

    public bool HasZorgprofiel => ProfielCode != null && ProfielStartdatum != null;

    public ProfielCode? ProfielCode { get; set; }

    [DataType(DataType.Date)]
    public DateTime? ProfielStartdatum { get; set; }

    [DataType(DataType.Date)]
    public DateTime? ProfielEinddatum { get; set; }

    public AdresModel Adres { get; set; }

    [DataType(DataType.Date)]
    public DateTime AangemaaktOp { get; set; }

    public Guid AangemaaktDoorId { get; set; }
    public string AangemaaktDoor { get; set; }

    public List<Guid> CollegaIds { get; set; }
    public IList<Zorgprofiel> Zorgprofielen { get; set; } = new List<Zorgprofiel>();

    public IEnumerable<VerzekerdeToUser> Users { get; set; } = new List<VerzekerdeToUser>();
    public IEnumerable<WeegMoment> WeegMomenten { get; set; } = new List<WeegMoment>();
}