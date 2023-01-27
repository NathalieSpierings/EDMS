using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Commands
{
    public class CreateMenu : CommandBase
    {
        public string Name { get; set; }
        public MenuType MenuType { get; set; }
    }
}
