namespace Promeetec.EDMS.Domain.Betrokkene.UserProfile.Commands
{
    public class UpdatePageSize : DomainCommand<Medewerker.Medewerker>
    {
        public int PageSize { get; set; }
    }
}