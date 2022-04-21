namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Events
{
    public class AanleverberichtGeopend : DomainEvent
    {
        public string AanleverberichtStatus { get; set; }
    }
}