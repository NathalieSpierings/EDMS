namespace Promeetec.EDMS.Domain.Modules.ION.Commands
{
    public class VerwerkPatientRelatie : DomainCommand<IONPatientRelatie>
    {
        public bool Verwerkt { get; set; }
    }
}