using System;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Models;

public class HaarwerkListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public string Naam { get; set; }
    public DateTime? Geboortedatum { get; set; }
    public string Bsn { get; set; }
    public HaarwerkTypeHulpmiddel TypeHulpmiddel { get; set; }
    public DateTime Afleverdatum { get; set; }
    public decimal EigenBijdrage { get; set; }
    public decimal BedragTeOntvangen { get; set; }
    public HaarwerkStatus Status { get; set; }
    public HaarwerkCreditType CreditType { get; set; }
}