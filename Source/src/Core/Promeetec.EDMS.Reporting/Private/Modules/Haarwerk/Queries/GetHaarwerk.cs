using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Queries;

public class GetHaarwerk : IQuery<HaarwerkViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid HaarwerkId { get; set; }

}
