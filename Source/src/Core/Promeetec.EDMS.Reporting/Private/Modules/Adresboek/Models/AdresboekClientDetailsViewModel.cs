using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Attributes;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Adresboek.Models;

public class AdresboekClientDetailsViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid AdresboekId { get; set; }
    public Geslacht Geslacht { get; set; }
    public string VolledigeNaam { get; set; }
    public Status Status { get; set; }
    public bool Shared { get; set; }
    public string VerzekeraarNaam { get; set; }
    public string Uzovi { get; set; }
    public string VerzekeraarDisplayName => string.Concat(VerzekeraarNaam, " [", Uzovi, "]");
    public string VerzekerdeNummer { get; set; }
    public string PatientNummer { get; set; }

    public bool HasZorgprofiel => ProfielCode != null && ProfielStartdatum != null;

    [Display(Name = "Lengte")]
    public double? Lengte { get; set; }

    public OrganisatieViewModel Organisatie { get; set; }

    [RequiredWhenVerwijzerInAdresboek]
    [Display(Name = "AGB-code verwijzer")]
    public string AgbCodeVerwijzer { get; set; }


    [Display(Name = "Naam verwijzer")]
    [StringLength(256)]
    public string NaamVerwijzer { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime? Verwijsdatum { get; set; }

    public ProfielCode? ProfielCode { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime ProfielStartdatum { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime? ProfielEinddatum { get; set; }


    public string Bsn { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime Geboortedatum { get; set; }

    public AdresViewModel Adres { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    public DateTime AangemaaktOp { get; set; }

    public Guid AangemaaktDoorId { get; set; }
    public string AangemaaktDoor { get; set; }

    public IList<Zorgprofiel> Zorgprofielen { get; set; } = new List<Zorgprofiel>();
}