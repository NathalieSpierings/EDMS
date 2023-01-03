using System;
using Promeetec.EDMS.Domain.Models.Identity.Users;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

public class MedewerkerListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public Status Status { get; set; }
    public UserAccountState AccountState { get; set; }
    public string FormeleNaam { get; set; }
    public string Achternaam { get; set; }
    public string Email { get; set; }
    public string Telefoon { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public bool IsUserAuthorized { get; set; }
    public bool IsAdminAccount => Achternaam == "Admin";
}