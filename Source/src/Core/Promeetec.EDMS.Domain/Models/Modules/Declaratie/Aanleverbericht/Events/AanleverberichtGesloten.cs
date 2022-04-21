namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Events
{
    public class AanleverberichtGesloten : DomainEvent
    {
        public string AanleverberichtStatus { get; set; }
    }
}