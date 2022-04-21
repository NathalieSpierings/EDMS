namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Commands
{
    public class MarkAanleverberichtAsRead : DomainCommand<Aanleverbericht>
    {
        public DateTime? LaastGelezenOp { get; set; }
        public Guid LaatsteLezerId { get; set; }
    }
}
