using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Commands
{
    public class CreateMenu : CommandBase
    {
        public string Name { get; set; }
        public MenuType MenuType { get; set; }
    }
}
