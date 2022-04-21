namespace Promeetec.EDMS.Domain.Betrokkene.UserProfile.Events
{
    public class UserProfileGewijzigd : DomainEvent
    {
        public bool IONToestemmingIngetrokken { get; set; }
    }
}