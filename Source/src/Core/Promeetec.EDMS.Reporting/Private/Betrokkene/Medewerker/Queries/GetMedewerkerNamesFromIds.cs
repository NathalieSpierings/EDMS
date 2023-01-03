using System;
using System.Collections.Generic;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

public class GetMedewerkerNamesFromIds : IQuery<IEnumerable<string>>
{
    public List<Guid> Ids { get; set; }
}