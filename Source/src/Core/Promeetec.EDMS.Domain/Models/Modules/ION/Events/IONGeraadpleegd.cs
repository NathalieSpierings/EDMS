namespace Promeetec.EDMS.Domain.Modules.ION.Events
{
    public class IONGeraadpleegd : DomainEvent
    {
        public string AgbCodePraktijk { get; set; }
        public string AgbCodeZorgverlener { get; set; }
        public DateTime Periode { get; set; }
        public int AantalRelaties { get; set; }
        public string PatientrelatiesZoekoptie { get; set; }

    }
}