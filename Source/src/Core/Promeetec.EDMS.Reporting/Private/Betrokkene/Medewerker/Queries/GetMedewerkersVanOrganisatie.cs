using System;
using System.Collections.Generic;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

public class GetMedewerkersVanOrganisatie : IQuery<List<MedewerkerViewModel>>
{
    public Guid OrganisatieId { get; set; }
    public bool Level2Only { get; set; }
}