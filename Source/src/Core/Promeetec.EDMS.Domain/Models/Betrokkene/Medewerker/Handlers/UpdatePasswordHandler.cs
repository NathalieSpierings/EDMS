using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Handlers;

public class UpdatePasswordHandler : ICommandHandler<UpdatePassword>
{
    private readonly IMedewerkerRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdatePassword> _validator;

    public UpdatePasswordHandler(IMedewerkerRepository repository,
        IEventRepository eventRepository,
        IValidator<UpdatePassword> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdatePassword command)
    {
        await _validator.ValidateCommand(command);

        var medewerker = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (medewerker == null)
            throw new DataException($"Medewerker met Id {command.Id} niet gevonden.");

        medewerker.UpdatePassword(command);

        var @event = new WachtwoordGewijzigd
        {
            TargetId = medewerker.Id,
            TargetType = nameof(Medewerker),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Password = "******"
        };

        await _repository.UpdateAsync(medewerker);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}
