namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Ketenzorg;

public class InvoiceCaregroup
{
    public string Name { get; set; }
    public string Agb { get; set; }
    public string Footer { get; set; }
    public string Logo { get; set; }
}

public class InvoiceCareprovider
{
    public string Name { get; set; }
    public string Agb { get; set; }
    public string BankAccountNumber { get; set; }

}

public class InvoiceRegistrationPatient
{
    public string Initials { get; set; }
    public string OwnNamePrefix { get; set; }
    public string OwnName { get; set; }
    public string PartnerNamePrefix { get; set; }
    public string PartnerName { get; set; }
    public DateTime Birthdate { get; set; }
    public string BSN { get; set; }
}

public class Invoice
{
    public Guid Id { get; set; }
    public Guid InvoicePeriodId { get; set; }
    public string InvoiceNumber { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedOn { get; set; }
    public string DebitorNumber { get; set; }

    public virtual InvoiceCareprovider Careprovider { get; set; }
    public virtual InvoiceCaregroup Caregroup { get; set; }
    public virtual ICollection<InvoiceRegistration> Registrations { get; set; }
}

public class InvoiceRegistration
{
    public Guid Id { get; set; }
    public DateTime TreatmentDate { get; set; }
    public int Quantity { get; set; }
    public decimal BaseTariff { get; set; }
    public decimal Tariff { get; set; }
    public decimal Subtotal { get; set; }
    public InvoiceRegistrationPatient Patient { get; set; }
    public virtual ProductActivity Activity { get; set; }
}


public class Debitor
{
    public Guid Id { get; set; }
    public string Agb { get; set; }
    public string Name { get; set; }
}

public class InvoicePeriod
{
    public Guid Id { get; set; }
    public DateTime Startdate { get; set; }
    public DateTime Enddate { get; set; }
    public Debitor Debitor { get; set; }
    public DateTime CreatedOn { get; set; }
    public string InvoiceNumber { get; set; }
    public virtual ICollection<Invoice> Invoices { get; set; }
}