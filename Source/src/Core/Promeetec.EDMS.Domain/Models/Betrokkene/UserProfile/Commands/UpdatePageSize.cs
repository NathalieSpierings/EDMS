using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile.Commands
{
    public class UpdatePageSize : CommandBase
    {
        public int PageSize { get; set; }
    }
}