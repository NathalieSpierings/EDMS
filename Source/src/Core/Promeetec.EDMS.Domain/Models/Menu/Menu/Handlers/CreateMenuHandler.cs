using FluentValidation;
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
    public class CreateMenuHandler : ICommandHandler<CreateMenu>
    {
        private readonly IMenuRepository _repository;
        private readonly IEventRepository _eventRepository;
        private readonly IValidator<CreateMenu> _validator;

        public CreateMenuHandler(IMenuRepository repository,
            IEventRepository eventRepository,
            IValidator<CreateMenu> validator)
        {
            _repository = repository;
            _eventRepository = eventRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<IEvent>> Handle(CreateMenu command)
        {
            await _validator.ValidateCommand(command);

            var menu = new Menu(command);

            var @event = new MenuAangemaakt
            {
                TargetId = menu.Id,
                TargetType = nameof(Menu),
                OrganisatieId = command.OrganisatieId,
                UserId = command.UserId,
                UserDisplayName = command.UserDisplayName,

                Status = Status.Actief.ToString(),
                Naam = command.Name,
                Soort = command.MenuType.GetDisplayName()
            };

            await _repository.AddAsync(menu);
            await _eventRepository.AddAsync(@event.ToDbEntity());

            return new IEvent[] { @event };
        }
    }
}
