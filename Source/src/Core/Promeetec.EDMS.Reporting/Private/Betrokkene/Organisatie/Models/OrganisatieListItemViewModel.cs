using System;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class OrganisatieListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid AdresboekId { get; set; }
    public string Nummer { get; set; }
    public string Naam { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public bool Zorggroep { get; set; }
    public bool Beperkt { get; set; }
    public Status Status { get; set; }
    public Guid VoorraadId { get; set; }
    public MedewerkerViewModel Contactpersoon { get; set; }
    public bool IsPromeetec => Nummer == "0000";
    public int AantalMedewerkers { get; set; }
    public int AantalVoorraadbestanden { get; set; }
    public int AantalAanleveringen { get; set; }
    public int AantalRapportages { get; set; }
}