using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

public class GetMedewerkerEdit : IQuery<MedewerkerEditViewModel>
{
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public Guid MedewerkerId { get; set; }
}