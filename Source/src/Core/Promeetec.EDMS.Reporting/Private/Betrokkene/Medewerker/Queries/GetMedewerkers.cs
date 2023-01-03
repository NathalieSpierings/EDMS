using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

public class GetMedewerkers : IQuery<MedewerkersViewModel>
{
    public Guid? OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string SearchTerm { get; set; }
    public bool IncludeDelete { get; set; }
}