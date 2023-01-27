using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile.Commands
{
    public class WijzigIONToestemming : CommandBase
    {
        public bool IONToestemmingsverlaringGetekend { get; set; }
        public bool IONVecozoToestemming { get; set; }
    }
}