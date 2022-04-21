namespace Promeetec.EDMS.Domain.Modules.Declaratie.Voorraad
{
    public interface IVoorraadRepository : IRepository<Voorraad>
    {
        Task<int> AantalVoorraadbestandenAsync(Guid voorraadId, bool level1Gebruiker, Guid userId);
        Task<int> AantalVoorraadbestandenVanEigenaarAsync(Guid medewerkerId);
    }
}