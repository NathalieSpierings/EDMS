using System;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Voorraad.Models;

public class VoorraadListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNummer { get; set; }
    public string OrganisatieNaam { get; set; }
    public int AantalVoorraadbestanden { get; set; }
}