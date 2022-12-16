using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage;

public class PushMessage : AggregateRoot
{
    /// <summary>
    /// The title of the Message.
    /// </summary>
    [Required, MaxLength(450)]
    public string Title { get; set; }

    /// <summary>
    /// The content of the Message.
    /// </summary>
    [Required, MaxLength(15000)]
    public string Message { get; set; }

    /// <summary>
    /// The date of the Message.
    /// </summary>
    [Required]
    public DateTime Date { get; set; }

    /// <summary>
    /// The status of the Message.
    /// </summary>
    public PushMessageStatus Status { get; set; }

    /// <summary>
    /// The commaseparated string of group id's.
    /// </summary>
    public string? GroupIds { get; set; }

    #region Navigation properties

    public virtual List<PushMessageToUser> Users { get; set; } = new();

    #endregion


    /// <summary>
    /// Creates an empty push message.
    /// </summary>
    public PushMessage() { }


    /// <summary>
    /// Creates a push message.
    /// </summary>
    /// <param name="cmd">The create push message command.</param>
    public PushMessage(CreatePushMessage cmd)
    {
        Date = DateTime.Now;
        Status = PushMessageStatus.Concept;
        Title = cmd.Title;
        Message = cmd.Message;
        GroupIds = string.Join(",", cmd.SelectedGroupIds.ToArray());
    }

    /// <summary>
    /// Removes a user from the push message.
    /// </summary>
    /// <param name="cmd">The remove user from push message command.</param>
    public void RemoveUser(RemoveUserFromPushMessage cmd)
    {
        var user = Users.FirstOrDefault(x => x.UserId == cmd.MedewerkerId);
        if (user == null)
            throw new Exception("Gebruiker voor bericht niet gevonden");

        user.RemoveUser(cmd);
    }

    /// <summary>
    /// Publishes the push message.
    /// </summary>
    public void Publish()
    {
        Status = PushMessageStatus.Gepubliceerd;
    }
}