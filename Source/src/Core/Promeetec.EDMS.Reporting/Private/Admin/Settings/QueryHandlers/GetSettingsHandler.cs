using System.Data.Entity;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Admin.Settings;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Settings.Models;
using Promeetec.EDMS.Reporting.Private.Admin.Settings.Queries;

namespace Promeetec.EDMS.Reporting.Private.Admin.Settings.QueryHandlers;

public class GetSettingsHandler : IQueryHandlerAsync<GetSettings, SettingsViewModel>
{
    private readonly ISettingsRepository _repository;

    public GetSettingsHandler(ISettingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<SettingsViewModel> HandleAsync(GetSettings query)
    {
        var dbQuery = await _repository.Query().AsNoTracking().FirstOrDefaultAsync();
        if (dbQuery == null)
            return new SettingsViewModel();

        var model = new SettingsViewModel
        {
            Id = dbQuery.Id,
            Straat = dbQuery.Straat,
            Huisnummer = dbQuery.Huisnummer,
            HuisnummerToevoeging = dbQuery.Huisnummertoevoeging,
            Postcode = dbQuery.Postcode,
            Woonplaats = dbQuery.Woonplaats,
            Telefoon = dbQuery.Telefoon,
            Email = dbQuery.Email,
            Haarwerk = new SettingsHaarwerkViewModel
            {
                BedragBasisVerzekering = dbQuery.Haarwerk.BedragBasisVerzekeringHaarwerk
            }
        };

        return model;
    }
}