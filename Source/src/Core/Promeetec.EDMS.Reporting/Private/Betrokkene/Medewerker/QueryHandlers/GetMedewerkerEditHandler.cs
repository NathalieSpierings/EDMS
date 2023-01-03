using System.Data.Entity;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Betrokkene.User.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.QueryHandlers;

public class GetMedewerkerEditHandler : IQueryHandlerAsync<GetMedewerkerEdit, MedewerkerEditViewModel>
{
    private readonly IMedewerkerRepository _repository;
    private readonly IDispatcher _dispatcher;

    public GetMedewerkerEditHandler(IMedewerkerRepository repository, IDispatcher dispatcher)
    {
        _repository = repository;
        _dispatcher = dispatcher;
    }

    public async Task<MedewerkerEditViewModel> HandleAsync(GetMedewerkerEdit query)
    {
        var dbQuery = await _repository
            .Query()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.MedewerkerId && x.OrganisatieId == query.OrganisatieId);

        var model = new MedewerkerEditViewModel
        {
            Id = dbQuery.Id,
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam,
            MedewerkerSoort = dbQuery.MedewerkerSoort,
            Geslacht = dbQuery.Persoon.Geslacht,
            Geboortedatum = dbQuery.Persoon.Geboortedatum,
            Voorletters = dbQuery.Persoon.Voorletters,
            Tussenvoegsel = dbQuery.Persoon.Tussenvoegsel,
            Voornaam = dbQuery.Persoon.Voornaam,
            Achternaam = dbQuery.Persoon.Achternaam,
            VolledigeNaam = dbQuery.Persoon.VolledigeNaam,
            Telefoon = dbQuery.Persoon.Telefoon,
            Telefoon1 = dbQuery.Persoon.Telefoon1,
            Doorkiesnummer = dbQuery.Persoon.Doorkiesnummer,
            Email = dbQuery.Persoon.Email,
            Functie = dbQuery.Functie,
            AgbCodeZorgverlener = dbQuery.AgbCodeZorgverlener,
            AgbCodeOnderneming = dbQuery.AgbCodeOnderneming,
            Avatar = dbQuery.Avatar,
            UserName = dbQuery.UserName,
            LaatstIngelogdOp = dbQuery.LaatstIngelogdOp,
            AccountState = dbQuery.AccountState,
            EmailConfirmed = dbQuery.EmailConfirmed,
            TwoFactorEnabled = dbQuery.TwoFactorEnabled,
            GoogleAuthenticatorEnabled = dbQuery.GoogleAuthenticatorEnabled,
            GoogleAuthenticatorSecretKey = dbQuery.GoogleAuthenticatorSecretKey,
            PukCode = dbQuery.PukCode,
            TempCode = dbQuery.TempCode,
            ActivationMailSend = dbQuery.ActivationMailSend,
            ActivationMailSendOn = dbQuery.ActivationMailSendOn,
            ActivationMailSendById = dbQuery.ActivationMailSendById,
            ActivationMailSendBy = dbQuery.ActivationMailSendBy,
            IONToestemmingsverklaringActivatieLink = dbQuery.IONToestemmingsverklaringActivatieLink,
            Groups = dbQuery.Groups,
            Roles = dbQuery.Roles,
            Adres = dbQuery.Adres != null ?
                new AdresViewModel
                {
                    Id = dbQuery.Adres.Id,
                    Straat = dbQuery.Adres?.Straat,
                    Huisnummer = dbQuery.Adres?.Huisnummer,
                    HuisnummerToevoeging = dbQuery.Adres?.Huisnummertoevoeging,
                    Postcode = dbQuery.Adres?.Postcode,
                    Woonplaats = dbQuery.Adres?.Woonplaats,
                    LandNaam = dbQuery.Adres?.LandNaam,
                    LandId = dbQuery.Adres?.LandId,
                    Land = dbQuery.Adres?.Land != null ?
                        new LandViewModel
                        {
                            Id = dbQuery.Adres.Land.Id,
                            NativeName = dbQuery.Adres.Land.NativeName
                        }
                        : null
                }
                : new AdresViewModel()
        };

        var userProfile = await _dispatcher.GetResultAsync(new GetUserProfile
        {
            MedewerkerId = query.MedewerkerId,
            OrganisatieId = query.OrganisatieId
        });

        model.UserProfile = userProfile;

        return model;
    }
}