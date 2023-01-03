using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

public class GetMedewerkerSoortSelectList : IQuery<MedewerkerSoortSelectList>
{
    public MedewerkerSoort MedewerkerSoort { get; set; }
}