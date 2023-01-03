using System;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

public class AanleveringListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public int AantalBerichten { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public Guid? ContactpersoonId { get; set; }
    public string FormeleNaamContactpersoon { get; set; }
    public Guid OrganisatieIdContactpersoon { get; set; }
    public string Referentie { get; set; }
    public string ReferentiePromeetec { get; set; }
    public AanleverStatus AanleverStatus { get; set; }
    public bool ToevoegenBestand { get; set; }
    public DateTime? AangepastOp { get; set; }
    public string Opmerking { get; set; }
    public DateTime Aanleverdatum { get; set; }
    public int AantalAanleverbestanden { get; set; }
    public int AantalOverigebestanden { get; set; }
    public Status Status { get; set; }

    public Guid? EigenaarId { get; set; }
    public string EigenaarFormeleNaam { get; set; }

    public Guid? BehandelaarId { get; set; }
    public string BehandelaarFormeleNaam { get; set; }
    public Guid? BehandelaarOrganisatieId { get; set; }
}