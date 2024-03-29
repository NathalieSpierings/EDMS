﻿using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Handlers
{
    public class ReinstateVerzekerdeHandler : ICommandHandler<ReinstateVerzekerde>
    {
        private readonly IVerzekerdeRepository _repository;
        private readonly IEventRepository _eventRepository;

        public ReinstateVerzekerdeHandler(IVerzekerdeRepository repository, IEventRepository eventRepository)
        {
            _repository = repository;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<IEvent>> Handle(ReinstateVerzekerde command)
        {
            var verzekerde = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
            if (verzekerde == null)
                throw new DataException($"Verzekerde met Id {command.Id} niet gevonden.");

            verzekerde.Reinstate();

            var @event = new VerzekerdeGeactiveerd
            {
                TargetId = verzekerde.Id,
                TargetType = nameof(Verzekerde),
                OrganisatieId = command.OrganisatieId,
                UserId = command.UserId,
                UserDisplayName = command.UserDisplayName,

                Status = Status.Actief.ToString()
            };
            await _repository.UpdateAsync(verzekerde);
            await _eventRepository.AddAsync(@event.ToDbEntity());

            return new IEvent[] { @event };
        }
    }
}