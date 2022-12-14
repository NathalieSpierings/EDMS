using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;

public class CreateAanleverbericht : CommandBase
{
    public int SortOrder { get; set; }
    public AanleverberichtStatus AanleverberichtStatus { get; set; }
    public string Onderwerp { get; set; }
    public string Bericht { get; set; }
    public bool Read { get; set; }
    public string AfzenderVolledigeNaam { get; set; }
    public string OntvangerVolledigeNaam { get; set; }

    public Guid? ParentId { get; set; }
    public Guid AfzenderId { get; set; }
    public Guid OntvangerId { get; set; }
    public Guid AanleveringId { get; set; }
}