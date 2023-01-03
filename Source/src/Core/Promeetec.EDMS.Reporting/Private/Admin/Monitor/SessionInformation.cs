namespace Promeetec.EDMS.Reporting.Private.Admin.Monitor;

[Serializable]
public class SessionInformation
{
    public string SessionId { get; set; }
    public string MachineId { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string UserAgent { get; set; }
    public string UserHostAddress { get; set; }
    public string ForwardedFor { get; set; }
    public bool Locked { get; set; }
    public bool Connected { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastActivity { get; set; }
}