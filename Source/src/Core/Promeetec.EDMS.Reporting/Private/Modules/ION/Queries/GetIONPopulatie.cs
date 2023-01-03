using System;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.ION.Models;
using Promeetec.EDMS.Vecozo.ION;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.Queries;

public class GetIONPopulatie : IQuery<IONPopulatieViewModel>
{
    public IONOmgeving Omgeving { get; set; }
    public IONZoekOptie IONZoekOptie { get; set; }

    public string SearchTerm { get; set; }
    public Guid MedewerkerId { get; set; }
    public Guid OrganisatieId { get; set; }
    public string Periode { get; set; }
    public string AgbCodeZorgverlener { get; set; }
    public string AgbCodeOnderneming { get; set; }
}