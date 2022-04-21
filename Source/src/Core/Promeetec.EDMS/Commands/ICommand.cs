namespace Promeetec.EDMS.Commands;

public interface ICommand
{
    Guid OrganisatieId { get; set; }
    Guid UserId { get; set; }
}
