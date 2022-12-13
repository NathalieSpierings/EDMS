using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Commands
{
    public class UpdateMenu : CommandBase
    {
        public MenuType MenuType { get; set; }
        public string Name { get; set; }
    }
}
