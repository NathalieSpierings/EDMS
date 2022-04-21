namespace Promeetec.EDMS.Commands;

public abstract class CommandBase : ICommand
{
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// The unique identifier of the Organisatie whose the request belongs to.
    /// </summary>
    public Guid OrganisatieId { get; set; }

    /// <summary>
    /// The unique identifier of the User who initiated the request.
    /// </summary>
    public Guid UserId { get; set; }
}