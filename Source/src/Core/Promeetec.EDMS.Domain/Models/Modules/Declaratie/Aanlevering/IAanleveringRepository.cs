using Promeetec.EDMS.Domain.Models.Identity;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

public interface IAanleveringRepository : IRepository<Aanlevering>
{
    /// <summary>
    /// Gets the aanlevering by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    Task<Aanlevering> GetAanleveringByIdAsync(Guid id);

    /// <summary>
    /// Gets the aanlevering by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="includeAanleverbestanden">if set to <c>true</c> [include aanleverbestanden].</param>
    /// <param name="includeOverigebestanden">if set to <c>true</c> [include overigebestanden].</param>
    /// <param name="includeBerichten">if set to <c>true</c> [include berichten].</param>
    Task<Aanlevering> GetAanleveringByIdAsync(Guid id, bool includeAanleverbestanden = false, bool includeOverigebestanden = false, bool includeBerichten = false);

    /// <summary>
    /// Gets the aanlevering for remove by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    Task<Aanlevering> GetAanleveringForRemoveByIdAsync(Guid id);

    /// <summary>
    /// Gets the aanleveringen van organisatie asynchronous.
    /// </summary>
    /// <param name="organisatieId">The organisatie identifier.</param>
    IQueryable<Aanlevering> GetAanleveringenVanOrganisatie(Guid organisatieId);

    /// <summary>
    /// Gets the referentie promeetec by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    Task<string> GetReferentiePromeetecByIdAsync(Guid id);

    /// <summary>
    /// Gets the referentie by medewerker asynchronous.
    /// </summary>
    /// <param name="aanleveringId">The aanlevering identifier.</param>
    /// <param name="user">The user.</param>
    /// <returns>Referentie promeetec voor internemedewerkers en referentie voor externe medewerkers.</returns>
    Task<string> GetReferentieByMedewerkerSoortAsync(Guid aanleveringId, UserPrincipal user);

    /// <summary>
    /// Bepaal of er documenten mogen worden toegevoegd aan de aanlevering.
    /// </summary>
    /// <param name="aanleveringId">The aanlevering identifier.</param>
    bool MagDocumentToevoegen(Guid aanleveringId);

    /// <summary>
    /// Bepaal of de opgegeven 'Referentie Promeetec' unique is.
    /// </summary>
    /// <param name="organisatieId">The organisatie identifier.</param>
    /// <param name="referentiePromeetec">The referentie promeetec.</param>
    /// <returns>
    ///   <c>true</c> if [is referentie promeetec unique] [the specified organisatie identifier]; otherwise, <c>false</c>.
    /// </returns>
    Task<bool> IsReferentiePromeetecUniqueAsnyc(Guid organisatieId, string referentiePromeetec);

    /// <summary>
    /// Maak een unique referentie Promeetec asynchroon op basis van het aantal aanleveringen in het huidige jaar
    /// en de uniciteit.
    /// Het nummer is opgebouwd als (OrganisatieNummer-YY-Volgnummer).
    /// </summary>
    /// <param name="organisatieId">The organisatie identifier.</param>
    /// <param name="organisatieNummer">The organisatie nummer.</param>
    Task<string> GetUniqueReferentiePromeetecAsync(Guid organisatieId, string organisatieNummer);

    /// <summary>
    /// Bepaal of de medewerker een eigenaar van actieve aanlevering(en) is.
    /// </summary>
    /// <param name="medewerkerId">The medewerker identifier.</param>
    Task<bool> IsMedewerkerEigenaarVanActiveAanleveringAsync(Guid medewerkerId);

    /// <summary>
    /// Gets the aanleveringen van eigenaar asynchronous.
    /// </summary>
    /// <param name="eigenaarId">The eigenaar identifier.</param>
    Task<List<Aanlevering>> GetAanleveringenVanEigenaarAsync(Guid eigenaarId);

    /// <summary>
    /// Gets the aantal aanleveringen van organisatie asynchronous.
    /// </summary>
    /// <param name="organisatieId">The organisatie identifier.</param>
    /// <param name="actief">if set to <c>true</c> [actief].</param>
    /// <param name="afgehandeld">if set to <c>true</c> [afgehandeld].</param>
    Task<int> GetAantalAanleveringenVanOrganisatieAsync(Guid organisatieId, bool actief, bool afgehandeld);




    /// <summary>
    /// Haal de lijst met aanleverbestandsnamen op.
    /// </summary>
    /// <param name="aanleveringId">The aanlevering identifier.</param>
    List<string> GetAanleverbestandsnamen(Guid aanleveringId);


    /// <summary>
    /// Haal de lijst met overige bestandsnamen op.
    /// </summary>
    /// <param name="aanleveringId">The aanlevering identifier.</param>

    List<string> GetOverigebestandsnamen(Guid aanleveringId);


    /// <summary>
    /// Haal de lijst met referentie promeetec van de aanleveringen.
    /// </summary>
    /// <param name="aanleveringId">The aanlevering identifier.</param>
    List<string> GetAanleveringReferentiesPromeetec(Guid aanleveringId);


    /// <summary>
    /// Verrwijderd de aanlevering met alle onderliggende relaties.
    /// </summary>
    /// <param name="aanleveringId">The aanlevering identifier.</param>
    Task<int> VerwijderAanleveringMetOnderliggendeRelaties(Guid aanleveringId);
}