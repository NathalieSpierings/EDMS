using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Commands
{
    public class UpdateUserProfile : CommandBase
    {
        public int PageSize { get; set; }
        public TableLayout TableLayout { get; set; }
        public SidebarLayout SidebarLayout { get; set; }
        public string AanleverstatusIds { get; set; }
        public string CarbonCopyAdressen { get; set; }
        public bool EmailBijRapportage { get; set; }
        public EmailOntvangenType EmailBijAanleverbericht { get; set; }
        public EmailOntvangenType EmailBijToevoegenDocument { get; set; }
        public bool IONToestemmingIngetrokken { get; set; }

    }
}