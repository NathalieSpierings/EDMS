using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

public class GetMedewerkerSelectList : IQuery<MedewerkerSelectList>
{
    public Guid? OrganisatieId { get; set; }
    public Guid? ExcludedMedewerkerId { get; set; }
    public bool FilterOpEigenaren { get; set; }
    public bool FilterOpContactpersonen { get; set; }
    public bool FilterOpBehandelaren { get; set; }
    public bool FilterOpAdresboekCollega { get; set; }
}