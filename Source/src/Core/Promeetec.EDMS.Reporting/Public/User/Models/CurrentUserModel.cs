namespace Promeetec.EDMS.Portaal.Reporting.Public.User.Models;

public class CurrentUserModel
{
    public Guid Id { get; set; }
    public string IdentityUserId { get; set; }
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public bool IsAuthenticated { get; set; }
    public bool IsActive { get; set; }
    public Guid OrganisatieId { get; set; }
    public string Organisatie { get; set; }
}
