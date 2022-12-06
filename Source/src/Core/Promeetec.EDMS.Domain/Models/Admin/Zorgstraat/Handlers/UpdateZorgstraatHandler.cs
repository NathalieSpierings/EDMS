using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Handlers;

public class UpdateZorgstraatHandler : ICommandHandler<UpdateZorgstraat>
{
    private readonly IZorgstraatRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateZorgstraat> _validator;

    public UpdateZorgstraatHandler(IZorgstraatRepository repository, IEventRepository eventRepository, IValidator<UpdateZorgstraat> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }


    public async Task<IEnumerable<IEvent>> Handle(UpdateZorgstraat command)
    {
        await _validator.ValidateCommand(command);

        var zorgstraat = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (zorgstraat == null)
            throw new DataException($"Zorgstraat met Id {command.Id} niet gevonden.");

        zorgstraat.Update(command);

        var @event = new ZorgstraatGewijzigd
        {
            TargetId = zorgstraat.Id,
            TargetType = nameof(Zorgstraat),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,

            Naam = command.Naam
        };

        await _repository.UpdateAsync(zorgstraat);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}