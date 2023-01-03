using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Adresboek.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Adresboek.Queries;

public class GetAdresboekClientDetails : IQuery<AdresboekClientDetailsViewModel>
{
    public Guid VerzekerdeId { get; set; }
}