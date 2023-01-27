using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanleverbericht.Events;

public class AanleverberichtGeplaatst : EventBase
{
    public string GeplaatstOp { get; set; }
    public string Onderwerp { get; set; }
    public string Bericht { get; set; }
    public string Afzender { get; set; }
    public string Ontvanger { get; set; }
    public string Gelezen { get; set; }
    public string AanleverberichtStatus { get; set; }
    public Guid? ParentId { get; set; }
    public Guid AfzenderId { get; set; }
    public Guid OntvangerId { get; set; }
    public Guid AanleveringId { get; set; }
}