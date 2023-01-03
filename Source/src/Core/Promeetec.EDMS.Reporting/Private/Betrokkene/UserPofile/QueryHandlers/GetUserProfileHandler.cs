using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Extensions;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.User.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.User.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.User.QueryHandlers;

public class GetUserProfileHandler : IQueryHandlerAsync<GetUserProfile, UserProfileViewModel>
{
    private readonly IMedewerkerRepository _repository;

    public GetUserProfileHandler(IMedewerkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserProfileViewModel> HandleAsync(GetUserProfile query)
    {
        var model = await _repository
            .Query()
            .Include(i => i.UserProfile)
            .Where(x => x.Id == query.MedewerkerId && x.OrganisatieId == query.OrganisatieId && x.Status != Status.Verwijderd)

            .Select(x => new UserProfileViewModel
            {
                Id = x.Id,
                OrganisatieId = x.OrganisatieId,
                IONToestemmingsverlaringGetekend = x.UserProfile.IONToestemmingsverlaringGetekend,
                IONToestemmingIngetrokken = x.UserProfile.IONToestemmingIngetrokken,
                IONVecozoToestemming = x.UserProfile.IONVecozoToestemming,
                PageSize = x.UserProfile.PageSize,
                TableLayout = x.UserProfile.TableLayout,
                SidebarLayout = x.UserProfile.SidebarLayout,
                AanleverstatusIds = x.UserProfile.AanleverstatusIds,
                EmailBijAanleverbericht = x.UserProfile.EmailBijAanleverbericht,
                EmailBijToevoegenDocument = x.UserProfile.EmailBijToevoegenDocument,
                EmailBijRapportage = x.UserProfile.EmailBijRapportage,
                CarbonCopyAdressen = x.UserProfile.CarbonCopyAdressen
            }).FirstOrDefaultAsync();

        // Create selectlistitem for each enum value and check if selectlistitem is selected
        var aanleverStatusen = new List<AanleverStatusSelectViewModel>();
        foreach (AanleverStatus item in Enum.GetValues(typeof(AanleverStatus)))
        {
            var selectItem = new AanleverStatusSelectViewModel
            {
                Id = (int)item,
                Name = item.GetDisplayName()
            };

            if (!string.IsNullOrWhiteSpace(model.AanleverstatusIds))
            {
                var statussen = model.AanleverstatusIds.Split(',').Select(int.Parse).ToList();
                var exsists = statussen.Contains((int)item);
                selectItem.Selected = exsists;
            }

            aanleverStatusen.Add(selectItem);
        }

        model.AanleverStatusen = aanleverStatusen;

        return model;
    }
}