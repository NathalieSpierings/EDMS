using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land.Handlers;

public class UpdateLandHandler : ICommandHandler<UpdateLand>
{
    private readonly ILandRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateLand> _validator;

    public UpdateLandHandler(ILandRepository repository,
        IEventRepository eventRepository,
        IValidator<UpdateLand> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }


    public async Task<IEnumerable<IEvent>> Handle(UpdateLand command)
    {
        await _validator.ValidateCommand(command);

        var land = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (land == null)
            throw new DataException($"Land met Id {command.Id} niet gevonden.");

        land.Update(command);

        var @event = new LandGewijzigd
        {
            TargetId = land.Id,
            TargetType = nameof(Land),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            CultureCode = command.CultureCode,
            NativeName = command.NativeName
        };

        await _repository.UpdateAsync(land);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}