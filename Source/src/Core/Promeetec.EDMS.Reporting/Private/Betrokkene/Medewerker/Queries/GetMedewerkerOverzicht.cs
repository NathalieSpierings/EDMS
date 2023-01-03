using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

public class GetMedewerkerOverzicht : IQuery<MedewerkerOverzichtViewModel>
{
    public Guid MedewerkerId { get; set; }
    public Guid OrganisatieId { get; set; }
}