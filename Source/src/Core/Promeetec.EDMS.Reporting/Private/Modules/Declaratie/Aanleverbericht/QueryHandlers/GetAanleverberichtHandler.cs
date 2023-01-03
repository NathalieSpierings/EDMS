using System;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.User.Models;
using Promeetec.EDMS.Reporting.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.QueryHandlers;

/// <summary>
/// Haalt een enkel bericht met bijbehorede replies op.
/// </summary>
public class GetAanleverberichtHandler : IQueryHandlerAsync<GetAanleverbericht, AanleverberichtViewModel>
{
    private readonly IAanleverberichtRepository _repository;

    public GetAanleverberichtHandler(IAanleverberichtRepository repository)
    {
        _repository = repository;
    }

    public async Task<AanleverberichtViewModel> HandleAsync(GetAanleverbericht query)
    {
        await Task.CompletedTask;

        var hoofdbericht = _repository.GetAanleverbericht(query.AanleverberichtId, query.AanleveringId);
        var replies = _repository.GetReplies(hoofdbericht.Id);

        var model = new AanleverberichtViewModel
        {
            Id = hoofdbericht.Id,
            ParentId = hoofdbericht.ParentId ?? Guid.Empty,
            AanleverberichtType = AanleverberichtType.Hoofdbericht,
            AanleverberichtStatus = hoofdbericht.AanleverberichtStatus,
            Gelezen = hoofdbericht.Gelezen,
            GeplaatstOp = hoofdbericht.GeplaatstOp,
            Onderwerp = hoofdbericht.Onderwerp,
            Bericht = hoofdbericht.Bericht,
            OntvangerId = hoofdbericht.OntvangerId,
            Ontvanger = new MedewerkerViewModel
            {
                Id = hoofdbericht.OntvangerId,
                Status = hoofdbericht.OntvangerStatus,
                Avatar = hoofdbericht.OntvangerAvatar,
                MedewerkerSoort = hoofdbericht.OntvangerMedewerkerSoort,
                VolledigeNaam = hoofdbericht.OntvangerNaam,
                Email = hoofdbericht.OntvangerEmail,
                Telefoon = hoofdbericht.OntvangerTelefoon,
                Geslacht = hoofdbericht.OntvangerGeslacht,
                UserProfile = new UserProfileViewModel
                {
                    EmailBijAanleverbericht = hoofdbericht.OntvangerEmailBijAanleverbericht,
                    CarbonCopyAdressen = hoofdbericht.OntvangerCarbonCopyAdressen,
                },
                Organisatie = new OrganisatieViewModel
                {
                    Id = hoofdbericht.OrganisatieId,
                    Nummer = hoofdbericht.OntvangerOrganisatieNummer,
                    Naam = hoofdbericht.OntvangerOrganisatieNaam,
                    Status = hoofdbericht.OntvangerOrganisatieStatus
                }
            },
            AfzenderId = hoofdbericht.AfzenderId,
            Afzender = new MedewerkerViewModel
            {
                Id = hoofdbericht.AfzenderId,
                Status = hoofdbericht.AfzenderStatus,
                Avatar = hoofdbericht.AfzenderAvatar,
                MedewerkerSoort = hoofdbericht.AfzenderMedewerkerSoort,
                VolledigeNaam = hoofdbericht.AfzenderNaam,
                Email = hoofdbericht.AfzenderEmail,
                Telefoon = hoofdbericht.AfzenderTelefoon,
                Geslacht = hoofdbericht.AfzenderGeslacht,
                UserProfile = new UserProfileViewModel
                {
                    EmailBijAanleverbericht = hoofdbericht.AfzenderEmailBijAanleverbericht,
                    CarbonCopyAdressen = hoofdbericht.AfzenderCarbonCopyAdressen,
                },
                Organisatie = new OrganisatieViewModel
                {
                    Id = hoofdbericht.AfzenderOrganisatieId,
                    Nummer = hoofdbericht.AfzenderOrganisatieNummer,
                    Naam = hoofdbericht.AfzenderOrganisatieNaam,
                    Status = hoofdbericht.AfzenderOrganisatieStatus
                }
            },
            Aanlevering = new AanleveringViewModel
            {
                Id = hoofdbericht.AanleveringId,
                Referentie = hoofdbericht.Referentie,
                ReferentiePromeetec = hoofdbericht.ReferentiePromeetec,
                Eigenaar = new MedewerkerViewModel
                {
                    Id = hoofdbericht.EigenaarId,
                    Status = hoofdbericht.EigenaarStatus,
                    Avatar = hoofdbericht.EigenaarAvatar,
                    MedewerkerSoort = hoofdbericht.EigenaarMedewerkerSoort,
                    VolledigeNaam = hoofdbericht.EigenaarNaam,
                    Email = hoofdbericht.EigenaarEmail,
                    Telefoon = hoofdbericht.EigenaarTelefoon,
                    Geslacht = hoofdbericht.EigenaarGeslacht,
                    UserProfile = new UserProfileViewModel
                    {
                        EmailBijAanleverbericht = hoofdbericht.EigenaarEmailBijAanleverbericht,
                        CarbonCopyAdressen = hoofdbericht.EigenaarCarbonCopyAdressen,
                    },
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = hoofdbericht.EigenaarOrganisatieId,
                        Nummer = hoofdbericht.EigenaarOrganisatieNummer,
                        Naam = hoofdbericht.EigenaarOrganisatieNaam,
                        Status = hoofdbericht.EigenaarOrganisatieStatus
                    }
                },
                BehandelaarId = hoofdbericht.BehandelaarId,
                Behandelaar = new MedewerkerViewModel
                {
                    Id = hoofdbericht.BehandelaarId.Value,
                    Status = hoofdbericht.BehandelaarStatus,
                    Avatar = hoofdbericht.BehandelaarAvatar,
                    MedewerkerSoort = hoofdbericht.BehandelaarMedewerkerSoort,
                    VolledigeNaam = hoofdbericht.BehandelaarNaam,
                    Email = hoofdbericht.BehandelaarEmail,
                    Telefoon = hoofdbericht.BehandelaarTelefoon,
                    Geslacht = hoofdbericht.BehandelaarGeslacht,
                    UserProfile = new UserProfileViewModel
                    {
                        EmailBijAanleverbericht = hoofdbericht.BehandelaarEmailBijAanleverbericht,
                        CarbonCopyAdressen = hoofdbericht.BehandelaarCarbonCopyAdressen,
                    },
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = hoofdbericht.BehandelaarOrganisatieId,
                        Nummer = hoofdbericht.BehandelaarOrganisatieNummer,
                        Naam = hoofdbericht.BehandelaarOrganisatieNaam,
                        Status = hoofdbericht.BehandelaarOrganisatieStatus
                    }
                },
                Organisatie = new OrganisatieViewModel
                {
                    Id = hoofdbericht.OrganisatieId,
                    Nummer = hoofdbericht.OrganisatieNummer,
                    Naam = hoofdbericht.OrganisatieNaam,
                    Status = hoofdbericht.OrganisatieStatus
                }
            },
            Replies = replies.Select(x => new AanleverberichtViewModel
            {
                Id = x.Id,
                ParentId = x.ParentId ?? Guid.Empty,
                AanleverberichtType = AanleverberichtType.Reply,
                AanleverberichtStatus = x.AanleverberichtStatus,
                Gelezen = x.Gelezen,
                GeplaatstOp = x.GeplaatstOp,
                Onderwerp = x.Onderwerp,
                Bericht = x.Bericht,
                OntvangerId = x.OntvangerId,
                Ontvanger = new MedewerkerViewModel
                {
                    Id = x.OntvangerId,
                    Status = x.OntvangerStatus,
                    Avatar = x.OntvangerAvatar,
                    MedewerkerSoort = x.OntvangerMedewerkerSoort,
                    VolledigeNaam = x.OntvangerNaam,
                    Email = x.OntvangerEmail,
                    Telefoon = x.OntvangerTelefoon,
                    Geslacht = x.OntvangerGeslacht,
                    UserProfile = new UserProfileViewModel
                    {
                        EmailBijAanleverbericht = x.OntvangerEmailBijAanleverbericht,
                        CarbonCopyAdressen = x.OntvangerCarbonCopyAdressen,
                    },
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = x.OrganisatieId,
                        Nummer = x.OntvangerOrganisatieNummer,
                        Naam = x.OntvangerOrganisatieNaam,
                        Status = x.OntvangerOrganisatieStatus
                    }
                },
                AfzenderId = hoofdbericht.AfzenderId,
                Afzender = new MedewerkerViewModel
                {
                    Id = x.AfzenderId,
                    Status = x.AfzenderStatus,
                    Avatar = x.AfzenderAvatar,
                    MedewerkerSoort = x.AfzenderMedewerkerSoort,
                    VolledigeNaam = x.AfzenderNaam,
                    Email = x.AfzenderEmail,
                    Telefoon = x.AfzenderTelefoon,
                    Geslacht = x.AfzenderGeslacht,
                    UserProfile = new UserProfileViewModel
                    {
                        EmailBijAanleverbericht = x.AfzenderEmailBijAanleverbericht,
                        CarbonCopyAdressen = x.AfzenderCarbonCopyAdressen,
                    },
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = x.AfzenderOrganisatieId,
                        Nummer = x.AfzenderOrganisatieNummer,
                        Naam = x.AfzenderOrganisatieNaam,
                        Status = x.AfzenderOrganisatieStatus
                    }
                },
                Aanlevering = new AanleveringViewModel
                {
                    Id = x.AanleveringId,
                    Referentie = x.Referentie,
                    ReferentiePromeetec = x.ReferentiePromeetec,
                    Eigenaar = new MedewerkerViewModel
                    {
                        Id = x.EigenaarId,
                        Status = x.EigenaarStatus,
                        Avatar = x.EigenaarAvatar,
                        MedewerkerSoort = x.EigenaarMedewerkerSoort,
                        VolledigeNaam = x.EigenaarNaam,
                        Email = x.EigenaarEmail,
                        Telefoon = x.EigenaarTelefoon,
                        Geslacht = x.EigenaarGeslacht,
                        UserProfile = new UserProfileViewModel
                        {
                            EmailBijAanleverbericht = x.EigenaarEmailBijAanleverbericht,
                            CarbonCopyAdressen = x.EigenaarCarbonCopyAdressen,
                        },
                        Organisatie = new OrganisatieViewModel
                        {
                            Id = x.EigenaarOrganisatieId,
                            Nummer = x.EigenaarOrganisatieNummer,
                            Naam = x.EigenaarOrganisatieNaam,
                            Status = x.EigenaarOrganisatieStatus
                        }
                    },
                    BehandelaarId = x.BehandelaarId,
                    Behandelaar = new MedewerkerViewModel
                    {
                        Id = x.BehandelaarId.Value,
                        Status = x.BehandelaarStatus,
                        Avatar = x.BehandelaarAvatar,
                        MedewerkerSoort = x.BehandelaarMedewerkerSoort,
                        VolledigeNaam = x.BehandelaarNaam,
                        Email = x.BehandelaarEmail,
                        Telefoon = x.BehandelaarTelefoon,
                        Geslacht = x.BehandelaarGeslacht,
                        UserProfile = new UserProfileViewModel
                        {
                            EmailBijAanleverbericht = x.BehandelaarEmailBijAanleverbericht,
                            CarbonCopyAdressen = x.BehandelaarCarbonCopyAdressen,
                        },
                        Organisatie = new OrganisatieViewModel
                        {
                            Id = x.BehandelaarOrganisatieId,
                            Nummer = x.BehandelaarOrganisatieNummer,
                            Naam = x.BehandelaarOrganisatieNaam,
                            Status = x.BehandelaarOrganisatieStatus
                        }
                    },
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = x.OrganisatieId,
                        Nummer = x.OrganisatieNummer,
                        Naam = x.OrganisatieNaam,
                        Status = x.OrganisatieStatus
                    }
                }
            }).ToList()
        };

        return model;
    }
}