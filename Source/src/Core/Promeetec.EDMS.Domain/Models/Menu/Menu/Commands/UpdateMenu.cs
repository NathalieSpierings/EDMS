using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Commands
{
    public class UpdateMenu : CommandBase
    {
        public MenuType MenuType { get; set; }
        public string Name { get; set; }
    }
}
