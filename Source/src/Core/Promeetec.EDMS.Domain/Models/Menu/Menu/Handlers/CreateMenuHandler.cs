using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Core.Extensions;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Handlers
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
