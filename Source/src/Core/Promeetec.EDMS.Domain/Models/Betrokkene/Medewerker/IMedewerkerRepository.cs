using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile;
using System.Net.Mail;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;

public interface IMedewerkerRepository : IRepository<Medewerker>
{
    ///// <summary>
    /////     Gets the medewerker by identifier asynchronous.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Task<Medewerker> GetMedewerkerByIdAsync(Guid id);

    ///// <summary>
    /////     Gets the by user name asynchronous.
    ///// </summary>
    ///// <param name="userName">Name of the user.</param>
    //Task<Medewerker> GetByUserNameAsync(string userName);

    ///// <summary>
    ///// Gets the agb code zorgverlener.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //Task<List<string>> GetAgbCodesZorgverlenerAsync(Guid medewerkerId);

    ///// <summary>
    ///// Gets the agb codes onderneming.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //Task<List<string>> GetAgbCodesOndernemingAsync(Guid medewerkerId);

    ///// <summary>
    ///// Gets de vorige login op date asynchronous.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //Task<DateTime> GetVorigeLoginOpAsync(Guid medewerkerId);

    ///// <summary>
    /////     Lijsts van MailAddress van collegas.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    ///// <param name="emailSoort">The email soort identifier.</param>
    //Task<List<MailAddress>> CcMailAddressenVanCollegasAsync(Guid organisatieId, Guid medewerkerId, EmailSoort? emailSoort);

    ///// <summary>
    /////     Gets the volledige naam by identifier asynchronous.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Task<string> GetVolledigeNaamByIdAsync(Guid id);

    ///// <summary>
    ///// Gets the formele naam by identifier asynchronous.
    ///// </summary>
    ///// <param name="id">The identifier.</param>
    //Task<string> GetFormeleNaamByIdAsync(Guid id);

    ///// <summary>
    /////     Gets the medewerkers by organisatie identifier.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //Task<List<Medewerker>> GetMedewerkersByOrganisatieIdAsync(Guid organisatieId);

    ///// <summary>
    ///// Gets the level2 medewerkers by organisatie identifier asynchronous.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //Task<List<Medewerker>> GetLevel2MedewerkersByOrganisatieIdAsync(Guid organisatieId);

    ///// <summary>
    /////     Checks the username asynchronous.
    ///// </summary>
    ///// <param name="userName">Name of the user.</param>
    //Task<string> CheckUsernameAsync(string userName);

    ///// <summary>
    /////     Gets the medewerkers by a list of id's.
    ///// </summary>
    ///// <param name="medewerkerIds">The medewerker ids.</param>
    //IEnumerable<Medewerker> GetMedewerkers(IEnumerable<Guid> medewerkerIds);

    ///// <summary>
    ///// Gets the user profile.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //Task<UserProfile.UserProfile> GetUserProfile(Guid medewerkerId);


    ///// <summary>
    ///// Gets the medewerkers met ion toestemming verleend.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //Task<List<Medewerker>> GetMedewerkersMetIONToestemmingVerleend(Guid organisatieId);

    ///// <summary>
    ///// Gets the interne medewerker mag raadplegen namens.
    ///// </summary>
    ///// <param name="organisatieId">The organisatie identifier.</param>
    //bool GetInterneMedewerkerMagRaadplegenNamens(Guid organisatieId);



    ///// <summary>
    ///// Haal de lijst met rapportage bestandsnamen op.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //List<string> GetRapportagebestandsnamen(Guid medewerkerId);



    ///// <summary>
    ///// Haal de lijst met de volledige namen en emailadressen van medewerkers.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //List<MedewerkerDeleteInfo> GetMedewerkerDeleteInfo(Guid medewerkerId);


    ///// <summary>
    ///// Haal de lijst met aanleverbestandsnamen op.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //List<string> GetAanleverbestandsnamen(Guid medewerkerId);

    ///// <summary>
    ///// Haal de lijst met overige bestandsnamen op.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //List<string> GetOverigebestandsnamen(Guid medewerkerId);

    ///// <summary>
    ///// Haal de lijst met referentie promeetec van de aanleveringen.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //List<string> GetAanleveringReferentiesPromeetec(Guid medewerkerId);


    ///// <summary>
    ///// Verrwijderd de medewerker met alle onderliggende relaties.
    ///// </summary>
    ///// <param name="medewerkerId">The medewerker identifier.</param>
    //Task<int> VerwijderMedewerkerMetOnderliggendeRelaties(Guid medewerkerId);
}
