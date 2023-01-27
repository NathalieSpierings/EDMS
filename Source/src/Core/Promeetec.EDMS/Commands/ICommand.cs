namespace Promeetec.EDMS.Portaal.Core.Commands;

public interface ICommand
{
    Guid OrganisatieId { get; set; }
    Guid UserId { get; set; }
}
