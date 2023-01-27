namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Haarwerk;

public class HaarwerkExport
{
    public string Organisatie { get; set; }
    public string Client { get; set; }
    public string Geboortedatum { get; set; }
    public string Bsn { get; set; }
    public string Verzekeringsnummer { get; set; }
    public string Machtigingsnummer { get; set; }
    public string TypeHulpmiddel { get; set; }
    public string LeveringSoort { get; set; }
    public string HaarwerkSoort { get; set; }
    public string Afleverdatum { get; set; }
    public string DatumVoorgaandHulpmiddel { get; set; }
    public string DatumMedischVoorschrift { get; set; }
    public string PrijsHaarwerk { get; set; }
    public string BedragBasisVerzekering { get; set; }
    public string BedragAanvullendeVerzekering { get; set; }
    public string BedragEigenBijdragen { get; set; }
    public string BedragTeOntvangen { get; set; }
    public string CreditType { get; set; }
    public DateTime ExportedOn { get; set; }
}