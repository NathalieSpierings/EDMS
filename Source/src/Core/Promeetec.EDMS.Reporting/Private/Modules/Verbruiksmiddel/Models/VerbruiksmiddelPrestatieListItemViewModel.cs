using System;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;

public class VerbruiksmiddelPrestatieListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid VerzekerdeId { get; set; }
    public Guid EigenaarId { get; set; }
    public string VerzekerdeFormeleNaam { get; set; }
    public DateTime? Geboortedatum { get; set; }
    public ProfielCode? ProfielCode { get; set; }
    public DateTime? ProfielStartdatum { get; set; }
    public DateTime? ProfielEinddatum { get; set; }
    public int? ZIndex { get; set; }
    public DateTime? PrestatieStartdatum { get; set; }

    public HulpmiddelenSoort HulpmiddelenSoort { get; set; }
    public VerbruiksmiddelPrestatieStatus Status { get; set; }

}