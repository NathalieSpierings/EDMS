using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanleverbericht;

public interface IAanleverberichtRepository : IRepository<Aanleverbericht>
{
    AanleverberichtDto GetAanleverbericht(Guid id, Guid aanleveringId);
    List<AanleverberichtDto> GetReplies(Guid hoofdberichtId);

    List<AanleverberichtenDto> GetAlleAanleverberichtenVanAanlevering(Guid aanleveringId);
    List<AanleverberichtenDto> GetAlleAanleverberichtenVanBehandelaar(Guid behandelaarId);
    List<AanleverberichtenDto> GetAlleAanleverberichten();
    int GetAantalHoofdberichten();
    int GetAantalHoofdberichtenVanAanlevering(Guid aanleveringId);
}