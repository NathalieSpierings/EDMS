using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.Settings.Handlers;

public class UpdateSettingsHandler : ICommandHandler<UpdateSettings>
{
    private readonly ISettingsRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateSettings> _validator;

    public UpdateSettingsHandler(ISettingsRepository repository, IEventRepository eventRepository, IValidator<UpdateSettings> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }


    public async Task<IEnumerable<IEvent>> Handle(UpdateSettings command)
    {
        await _validator.ValidateCommand(command);

        var settings = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (settings == null)
            throw new DataException($"Instellingen met Id {command.Id} niet gevonden.");

        settings.Update(command);

        var @event = new SettingsGewijzigd
        {
            TargetId = settings.Id,
            TargetType = nameof(Settings),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Straat = settings.Straat,
            Huisnummer = settings.Huisnummer,
            Huisnummertoevoeging = settings.Huisnummertoevoeging,
            Postcode = settings.Postcode,
            Woonplaats = settings.Woonplaats,
            Telefoon = settings.Telefoon,
            Email = settings.Email,
            BedragBasisVerzekering = settings.Haarwerk.BedragBasisVerzekeringHaarwerk,
        };

        await _repository.UpdateAsync(settings);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}