namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Commands
{
    public class CreateAanleverbericht : DomainCommand<Aanleverbericht>
    {
        public string Onderwerp { get; set; }
        public string Bericht { get; set; }
        public string Afzender { get; set; }
        public string Ontvanger { get; set; }
        public int SortOrder { get; set; }
        public bool Read { get; set; }
        public AanleverberichtStatus AanleverberichtStatus { get; set; }
        public Guid? ParentId { get; set; }
        public Guid AfzenderId { get; set; }
        public Guid OntvangerId { get; set; }
        public Guid AanleveringId { get; set; }
    }
}