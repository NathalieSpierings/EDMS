using System;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Admin.Mededeling;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Admin.Mededeling.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Dashboard.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Monitor;

namespace Promeetec.EDMS.Reporting.Private.Admin.Dashboard.Queries;

public class GetAdminDashboard : IQuery<AdminDashboardViewModel>
{
}
public class GetAdminDashboardHandler : IQueryHandlerAsync<GetAdminDashboard, AdminDashboardViewModel>
{
    private readonly IOrganisatieRepository _organisatieRepository;
    private readonly IMedewerkerRepository _medewerkerRepository;
    private readonly IMededelingRepository _mededelingRepository;

    public GetAdminDashboardHandler(IOrganisatieRepository organisatieRepository, IMedewerkerRepository medewerkerRepository, IMededelingRepository mededelingRepository)
    {
        _organisatieRepository = organisatieRepository;
        _medewerkerRepository = medewerkerRepository;
        _mededelingRepository = mededelingRepository;
    }

    public async Task<AdminDashboardViewModel> HandleAsync(GetAdminDashboard query)
    {
        await Task.CompletedTask;

        var aantalActieveOrganisaties = _organisatieRepository.Query().Count(x => x.Status == Status.Actief);
        var aantalBeperkteOrganisaties = _organisatieRepository.Query().Count(x => x.Beperkt);
        var aantalActieveMedewerkers = _medewerkerRepository.Query().Count(x => x.Status == Status.Actief);
        var mededeling = _mededelingRepository.Query().FirstOrDefault();

        return new AdminDashboardViewModel
        {
            AantalActieveOrganisaties = aantalActieveOrganisaties,
            AantalBeperkteOrganisaties = aantalBeperkteOrganisaties,
            AantalActieveMedewerkers = aantalActieveMedewerkers,
            AantalOnlineUsers = ApplicationState.OnlineUsers(),
            Mededeling = new MededelingViewModel
            {
                Id = mededeling != null ? mededeling.Id != Guid.Empty ? mededeling.Id : Guid.Empty : Guid.Empty,
                Content = mededeling?.Content
            }
        };
    }
}