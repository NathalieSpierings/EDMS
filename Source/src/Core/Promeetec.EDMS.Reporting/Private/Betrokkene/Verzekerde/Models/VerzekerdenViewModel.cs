using System;
using System.Linq;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

public class VerzekerdenViewModel : ModelBase
{
    public Guid OrganisatieId { get; set; }
    public IOrderedEnumerable<VerzekerdeViewModel> Verzekerden { get; set; }
}