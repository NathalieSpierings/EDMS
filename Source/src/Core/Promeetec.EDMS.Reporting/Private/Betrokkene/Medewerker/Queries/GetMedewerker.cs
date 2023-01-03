using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

public class GetMedewerker : IQuery<MedewerkerViewModel>
{
    public Guid MedewerkerId { get; set; }
    public Guid? OrganisatieId { get; set; }
    public bool? IncludeAvatar { get; set; }
    public bool? IncludeProfile { get; set; }
}