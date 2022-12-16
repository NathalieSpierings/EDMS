using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Commands
{
    public class WijzigIONToestemming : CommandBase
    {
        public bool IONToestemmingsverlaringGetekend { get; set; }
        public bool IONVecozoToestemming { get; set; }
    }
}