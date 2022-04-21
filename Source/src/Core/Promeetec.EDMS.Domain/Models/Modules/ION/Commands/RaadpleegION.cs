namespace Promeetec.EDMS.Domain.Modules.ION.Commands
{
    public class RaadpleegION : DomainCommand<IONPatientRelatie>
    {
        public string AgbCodePraktijk { get; set; }
        public string AgbCodeZorgverlener { get; set; }
        public IONZoekOptie IONZoekOptie { get; set; }
        public DateTime Periode { get; set; }
        public int AantalRelaties { get; set; }

    }
}