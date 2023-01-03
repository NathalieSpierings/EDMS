using System;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Modules.Ketenzorg;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

public class MachtigingenListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string OrganisatieNummer { get; set; }
    public DateTime Geboortedatum { get; set; }
    public string Voorletters { get; set; }
    public string Tussenvoegsel { get; set; }
    public string Achternaam { get; set; }
    public string TussenvoegselPartner { get; set; }
    public string AchternaamPartner { get; set; }
    public string FormeleNaam => PersoonExtensions.SetFormeleNaamMetPartner(Voorletters, Tussenvoegsel, Achternaam, TussenvoegselPartner, AchternaamPartner);
    public DateTime Startdatum { get; set; }
    public DateTime? Einddatum { get; set; }
    public MachtigingStatus Status { get; set; }
    public string Naam { get; set; }
    public string ZdNummer { get; set; }
}