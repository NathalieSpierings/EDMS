namespace Promeetec.EDMS.Domain.Betrokkene.UserProfile.Commands
{
    public class WijzigIONToestemming : DomainCommand<Medewerker.Medewerker>
    {
        public bool IONToestemmingsverlaringGetekend { get; set; }
        public bool IONVecozoToestemming { get; set; }
    }
}