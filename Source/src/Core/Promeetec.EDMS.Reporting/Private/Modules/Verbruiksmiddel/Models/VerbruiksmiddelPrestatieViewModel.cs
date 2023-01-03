using System;
using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;

public class VerbruiksmiddelPrestatieViewModel : ModelBase
{
    public Guid Id { get; set; }

    [Display(Name = "AGB-code onderneming/vestiging")]
    public string AgbCodeOnderneming { get; set; }

    [Display(Name = "Hulpmiddelen soort")]
    public HulpmiddelenSoort HulpmiddelenSoort { get; set; }
    public VerbruiksmiddelPrestatieStatus Status { get; set; }

    [UIHint("Date")]
    [DataType(DataType.Date)]
    [Display(Name = "Aangemaakt op")]
    public DateTime AangemaaktOp { get; set; }

    public Guid AangemaaktDoorId { get; set; }

    [Display(Name = "Aangemaakt door")]
    public string AangemaaktDoor { get; set; }

    public ZorgprofielViewModel Zorgprofiel { get; set; }
    public VerbruiksmiddelHulpmiddelViewModel Hulpmiddel { get; set; }

    public MedewerkerViewModel Eigenaar { get; set; }
    public VerzekerdeViewModel Verzekerde { get; set; }
    public OrganisatieViewModel Organisatie { get; set; }
}