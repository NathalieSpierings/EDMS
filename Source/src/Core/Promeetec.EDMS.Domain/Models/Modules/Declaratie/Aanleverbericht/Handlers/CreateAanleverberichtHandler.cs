using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Events;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Extensions;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Handlers;

public class CreateAanleverberichtHandler : ICommandHandler<CreateAanleverbericht>
{
    private readonly IAanleverberichtRepository _repository;
    private readonly IAanleveringRepository _aanleveringRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateAanleverbericht> _validator;


    public CreateAanleverberichtHandler(IAanleverberichtRepository repository,
        IAanleveringRepository aanleveringRepository, IEventRepository eventRepository,
        IValidator<CreateAanleverbericht> validator)
    {
        _repository = repository;
        _aanleveringRepository = aanleveringRepository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateAanleverbericht command)
    {
        await _validator.ValidateCommand(command);

        var aanlevering = await _aanleveringRepository
            .Query()
            .Include(i => i.Aanleverberichten)
            .FirstOrDefaultAsync(x => x.Id == command.AanleveringId && x.Status != Status.Verwijderd);
        if (aanlevering == null)
            throw new DataException($"Aanlevering met Id {command.Id} niet gevonden.");

        var order = aanlevering.BerichtSortOrder(command);
        var aanleverbericht = new Aanleverbericht(command, order);

        var @event = new AanleverberichtGeplaatst
        {
            TargetId = aanleverbericht.Id,
            TargetType = nameof(Aanleverbericht),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,
            AanleverberichtStatus = command.AanleverberichtStatus.GetDisplayName(),
            GeplaatstOp = DateTime.Now.ToString("dd-MM-yyyy"),
            Onderwerp = command.Onderwerp,
            Bericht = command.Bericht,
            Afzender = command.AfzenderVolledigeNaam,
            Ontvanger = command.OntvangerVolledigeNaam,
            Gelezen = "Nee",
            ParentId = command.ParentId,
            AfzenderId = command.AfzenderId,
            OntvangerId = command.OntvangerId,
            AanleveringId = command.AanleveringId,
        };

        await _repository.AddAsync(aanleverbericht);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}