namespace Promeetec.EDMS.Domain.Betrokkene.UserProfile.Commands
{
    public class UpdateEmailBijRapportage : DomainCommand<Medewerker.Medewerker>
    {
        public bool EmailBijRapportage { get; set; }
    }
}