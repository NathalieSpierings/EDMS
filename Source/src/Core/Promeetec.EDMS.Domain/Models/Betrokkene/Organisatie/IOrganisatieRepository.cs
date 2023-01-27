using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;

public interface IOrganisatieRepository : IRepository<Organisatie>
{
    ///// <summary>
    ///// Gets the promeetec.
    ///// </summary>
    //Organisatie? GetPromeetec();

    ///// <summary>
    ///// Gets the promeetec identifier asynchronous.
    ///// </summary>
    //Task<Guid> GetPromeetecIdAsync();

    ///// <summary>
    ///// Gets the organisatie by identifier asynchronous.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    ///// <returns>The organisatie.</returns>
    //Task<Organisatie?> GetOrganisatieByIdAsync(Guid organisatieId);

    ///// <summary>
    ///// Gets the organisatie naam by identifier asynchronous.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Task<string> GetOrganisatieNaamByIdAsync(Guid id);

    ///// <summary>
    ///// Gets the organisatie display name by identifier asynchronous.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    ///// <returns>The display name of the organisatie.</returns>
    //Task<string> GetOrganisatieDisplayNameByIdAsync(Guid id);

    ///// <summary>
    ///// Gets the organisatie nummer by identifier.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //string? GetOrganisatieNummerById(Guid id);

    ///// <summary>
    ///// Gets the address of the organisatie.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Adres.Adres? GetOrganisatieAddressById(Guid id);

    ///// <summary>
    ///// Get if the vewijzer is visible in the adresboek of the organisatie.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Task<VerwijzerInAdresboekType> GetVerwijzerInAdresboekPreferenceAsync(Guid id);

    ///// <summary>
    ///// Gets the organisatie settings.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Task<OrganisatieSettings> GetOrganisatieSettingsAsync(Guid id);


    ///// <summary>
    ///// Gets the agb codes onderneming.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Task<List<string>> GetAgbCodesOndernemingAsync(Guid id);

    ///// <summary>
    ///// Determines whether [is organisatie nummer unique asynchronous] [the specified nummer].
    ///// </summary>
    ///// <param name="nummer">The nummer.</param>
    ///// <param name="id">The identifier.</param>
    //Task<bool> IsOrganisatieNummerUniqueAsync(string nummer, Guid? id = default);


    ///// <summary>
    ///// Determines whether the organisatie has a medewerker with the given role.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    ///// <param name="roleName">Name of the role.</param>
    //Task<bool> IsOrganisatieInRole(Guid organisatieId, string roleName);

    ///// <summary>
    ///// Gets the organisatie voorraad identifier by identifier.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Guid GetOrganisatieVoorraadIdById(Guid id);


    ///// <summary>
    ///// Haal de medewerkers voor de gegeven organisatie op.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    ///// <returns>Organisatie met medewerkers.</returns>
    //Task<Organisatie?> GetMedewerkersVanOrganisatieAsync(Guid id);

    ///// <summary>
    ///// Gets the organisatie addressbook identifier asynchronous.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Task<Guid> GetAddressbookIdAsync(Guid id);


    ///// <summary>
    ///// Determines whether [is nummer unique asynchronous] [the specified nummer].
    ///// </summary>
    ///// <param name="nummer">The nummer.</param>
    ///// <param name="id">The identifier.</param>
    //Task<bool> IsNummerUniqueAsync(string nummer, Guid? id = default);

    ///// <summary>
    ///// Determines whether [is zorggroep asynchronous] [the specified identifier].
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    ///// <returns>
    /////   <c>true</c> if [is zorggroep asynchronous] [the specified identifier]; otherwise, <c>false</c>.
    ///// </returns>
    //Task<bool> IsZorggroepAsync(Guid id);

    ///// <summary>
    ///// Determines whether specified medewerker is a contactpersoon.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //Task<bool> IsMedewerkerContactpersoonAsync(Guid medewerkerId);

    ///// <summary>
    ///// Gets the organisaties van contactpersoon asynchronous.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //Task<List<Organisatie>> GetOrganisatiesVanContactpersoonAsync(Guid medewerkerId);

    ///// <summary>
    ///// Gets the gekoppelde organisaties.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Task<List<Organisatie>> GetGekoppeldeOrganisaties(Guid id);

    
    ///// <summary>
    ///// Haal de lijst met voorraadbestandsnamen op.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //List<string> GetVoorraadbestandsnamen(Guid organisatieId);


    ///// <summary>
    ///// Haal de lijst met rapportage bestandsnamen op.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //List<string> GetRapportagebestandsnamen(Guid organisatieId);


    ///// <summary>
    ///// Haal de lijst met aanleverbestandsnamen op.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //List<string> GetAanleverbestandsnamen(Guid organisatieId);


    ///// <summary>
    ///// Haal de lijst met overige bestandsnamen op.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //List<string> GetOverigebestandsnamen(Guid organisatieId);


    ///// <summary>
    ///// Haal de lijst met referentie promeetec van de aanleveringen.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //List<string> GetAanleveringReferentiesPromeetec(Guid organisatieId);


    ///// <summary>
    ///// Haal de lijst met de volledige namen en emailadressen van medewerkers.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //List<MedewerkerDeleteInfo> GetMedewerkersDeleteInfo(Guid organisatieId);


    ///// <summary>
    ///// Haalt het aantal verzekerden van het adresboek op.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //int GetAantalVerzekerdeVoorAdresboek(Guid organisatieId);


    ///// <summary>
    ///// Verrwijderd de organisatie met alle onderliggende relaties.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //Task<int> VerwijderOrganisatieMetOnderliggendeRelaties(Guid organisatieId);

    ///// <summary>
    ///// Verwijder de events van de gegeven organisatie.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //Task<int> VerwijderOrganisatieEventLog(Guid organisatieId);
}