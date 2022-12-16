using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Commands
{
    public class UpdatePageSize : CommandBase
    {
        public int PageSize { get; set; }
    }
}