using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Events;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Extensions;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Handlers
{
    public class UpdateMenuHandler : ICommandHandler<UpdateMenu>
    {
        private readonly IMenuRepository _repository;
        private readonly IEventRepository _eventRepository;
        private readonly IValidator<UpdateMenu> _validator;

        public UpdateMenuHandler(IMenuRepository repository,
            IEventRepository eventRepository,
            IValidator<UpdateMenu> validator)
        {
            _repository = repository;
            _eventRepository = eventRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<IEvent>> Handle(UpdateMenu command)
        {
            await _validator.ValidateCommand(command);

            var menu = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
            if (menu == null)
                throw new DataException($"Menu met Id {command.Id} niet gevonden.");


            menu.Update(command);

            var @event = new MenuGewijzigd
            {
                TargetId = menu.Id,
                TargetType = nameof(Menu),
                OrganisatieId = command.OrganisatieId,
                UserId = command.UserId,
                UserDisplayName = command.UserDisplayName,

                Naam = command.Name,
                Soort = command.MenuType.GetDisplayName()
            };

            await _repository.UpdateAsync(menu);
            await _eventRepository.AddAsync(@event.ToDbEntity());

            return new IEvent[] { @event };
        }
    }
}
