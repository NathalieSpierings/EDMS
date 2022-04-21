namespace Promeetec.EDMS.Domain.Betrokkene.UserProfile.Events
{
    public class IONToestemmingGewijzigd : DomainEvent
    {
        public bool IONToestemmingsverlaringGetekend { get; set; }
        public bool IONToestemmingVerleend { get; set; }
        public bool IONVecozoToestemming { get; set; }
    }
}