using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Events;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land.Handlers;

public class UpdateLandHandler : ICommandHandler<UpdateLand>
{
    private readonly ILandRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateLand> _validator;

    public UpdateLandHandler(ILandRepository repository)
    {
        _repository = repository;
    }


    public async Task<IEnumerable<IEvent>> Handle(UpdateLand command)
    {
        await _validator.ValidateCommand(command);

        var country = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (country == null)
            throw new DataException($"Land met Id {command.Id} niet gevonden.");

        country.Update(command);

        var @event = new LandGewijzigd
        {
            TargetId = country.Id,
            TargetType = nameof(Land),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,

           CultureCode = country.CultureCode,
           NativeName = country.NativeName
        };

        await _repository.UpdateAsync(country);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}