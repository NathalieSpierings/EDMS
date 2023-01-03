using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Extensions;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.User.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.User.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.QueryHandlers;

public class GetMedewerkerHandler : IQueryHandlerAsync<GetMedewerker, MedewerkerViewModel>
{
    private readonly IMedewerkerRepository _repository;

    public GetMedewerkerHandler(IMedewerkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<MedewerkerViewModel> HandleAsync(GetMedewerker query)
    {
        Domain.Models.Betrokkene.Medewerker.Medewerker dbQuery;

        if (query.OrganisatieId != null && query.OrganisatieId != Guid.Empty)
        {
            dbQuery = await _repository
                .Query()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == query.MedewerkerId && x.OrganisatieId == query.OrganisatieId);
        }
        else
        {
            dbQuery = await _repository
                .Query()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == query.MedewerkerId);
        }

        var model = new MedewerkerViewModel
        {
            Id = dbQuery.Id,
            Organisatie = new OrganisatieViewModel
            {
                Id = dbQuery.OrganisatieId,
                VoorraadId = dbQuery.Organisatie.Voorraad.Id,
                Nummer = dbQuery.Organisatie.Nummer,
                Naam = dbQuery.Organisatie.Naam,
                Zorggroep = dbQuery.Organisatie.Zorggroep,
                IONZoekoptie = dbQuery.Organisatie.IONZoekoptie,
                Status = dbQuery.Status
            },
            MedewerkerSoort = dbQuery.MedewerkerSoort,
            Geslacht = dbQuery.Persoon.Geslacht,
            Geboortedatum = dbQuery.Persoon.Geboortedatum,
            Voorletters = dbQuery.Persoon.Voorletters,
            Voornaam = dbQuery.Persoon.Voornaam,
            Tussenvoegsel = dbQuery.Persoon.Tussenvoegsel,
            Achternaam = dbQuery.Persoon.Achternaam,
            FormeleNaam = dbQuery.Persoon.FormeleNaam,
            VolledigeNaam = dbQuery.Persoon.VolledigeNaam,
            Telefoon = dbQuery.Persoon.Telefoon,
            Telefoon1 = dbQuery.Persoon.Telefoon1,
            Doorkiesnummer = dbQuery.Persoon.Doorkiesnummer,
            Email = dbQuery.Persoon.Email,
            AgbCodeZorgverlener = dbQuery.AgbCodeZorgverlener,
            AgbCodeOnderneming = dbQuery.AgbCodeOnderneming,
            Functie = dbQuery.Functie,
            Status = dbQuery.Status,
            DeactivatieReden = dbQuery.DeactivatieReden,
            AccountState = dbQuery.AccountState,
            ActivationMailSend = dbQuery.ActivationMailSend,
            ActivationMailSendOn = dbQuery.ActivationMailSendOn,
            ActivationMailSendById = dbQuery.ActivationMailSendById,
            ActivationMailSendBy = dbQuery.ActivationMailSendBy,
            UserName = dbQuery.UserName,
            LaatstIngelogdOp = dbQuery.LaatstIngelogdOp,
            EmailConfirmed = dbQuery.EmailConfirmed,
            PhoneNumberConfirmed = dbQuery.PhoneNumberConfirmed,
            TwoFactorEnabled = dbQuery.TwoFactorEnabled,
            GoogleAuthenticatorEnabled = dbQuery.GoogleAuthenticatorEnabled,
            GoogleAuthenticatorSecretKey = dbQuery.GoogleAuthenticatorSecretKey,
            PukCode = dbQuery.PukCode,
            TempCode = dbQuery.TempCode,
            IONToestemmingsverklaringActivatieLink = dbQuery.IONToestemmingsverklaringActivatieLink,
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
                    Land = dbQuery.Adres?.Land != null ? new LandViewModel
                    {
                        Id = dbQuery.Adres.Land.Id,
                        NativeName = dbQuery.Adres.Land.NativeName
                    }
                        : null
                }
                : new AdresViewModel(),
            Roles = dbQuery.Roles,
            Groups = dbQuery.Groups
        };

        if (query.IncludeAvatar != null && query.IncludeAvatar.Value)
            model.Avatar = dbQuery.Avatar;

        if (query.IncludeProfile != null && query.IncludeProfile.Value)
        {
            var userProfile = new UserProfileViewModel
            {
                IONToestemmingsverlaringGetekend = dbQuery.UserProfile.IONToestemmingsverlaringGetekend,
                IONToestemmingIngetrokken = dbQuery.UserProfile.IONToestemmingIngetrokken,
                IONVecozoToestemming = dbQuery.UserProfile.IONVecozoToestemming,

                PageSize = dbQuery.UserProfile.PageSize,
                TableLayout = dbQuery.UserProfile.TableLayout,
                SidebarLayout = dbQuery.UserProfile.SidebarLayout,
                AanleverstatusIds = dbQuery.UserProfile.AanleverstatusIds,
                EmailBijAanleverbericht = dbQuery.UserProfile.EmailBijAanleverbericht,
                EmailBijToevoegenDocument = dbQuery.UserProfile.EmailBijToevoegenDocument,
                EmailBijRapportage = dbQuery.UserProfile.EmailBijRapportage,
                CarbonCopyAdressen = dbQuery.UserProfile.CarbonCopyAdressen,
            };

            var aanleverStatusen = new List<AanleverStatusSelectViewModel>();
            foreach (AanleverStatus item in Enum.GetValues(typeof(AanleverStatus)))
            {
                var selectItem = new AanleverStatusSelectViewModel
                {
                    Id = (int)item,
                    Name = item.GetDisplayName()
                };

                if (!string.IsNullOrWhiteSpace(userProfile.AanleverstatusIds))
                {
                    var statussen = userProfile.AanleverstatusIds.Split(',').Select(int.Parse).ToList();
                    var exsists = statussen.Contains((int)item);
                    selectItem.Selected = exsists;
                }

                aanleverStatusen.Add(selectItem);
            }

            userProfile.AanleverStatusen = aanleverStatusen;

            model.UserProfile = userProfile;
        }

        return model;
    }
}