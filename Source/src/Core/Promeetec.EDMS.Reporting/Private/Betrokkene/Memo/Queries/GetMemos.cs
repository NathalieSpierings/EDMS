using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Memo.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Memo.Queries;

public class GetMemos : IQuery<MemosViewModel>
{
    public Guid MedewerkerId { get; set; }
    public Guid OrganisatieId { get; set; }

}