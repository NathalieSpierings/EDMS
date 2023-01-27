using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Haarwerk.Commands;

public class UpdateHaarwerk : CommandBase
{
    public string Naam { get; set; }
    public DateTime Geboortedatum { get; set; }
    public string Bsn { get; set; }
    public string Verzekeringsnummer { get; set; }
    public string Machtigingsnummer { get; set; }
    public HaarwerkTypeHulpmiddel TypeHulpmiddel { get; set; }
    public HaarwerkLeveringSoort LeveringSoort { get; set; }
    public HaarwerkSoort HaarwerkSoort { get; set; }
    public DateTime Afleverdatum { get; set; }
    public DateTime? DatumVoorgaandHulpmiddel { get; set; }
    public DateTime? DatumMedischVoorschrift { get; set; }
    public decimal PrijsHaarwerk { get; set; }
    public decimal BedragBasisVerzekering { get; set; }
    public decimal BedragAanvullendeVerzekering { get; set; }
    public decimal BedragEigenBijdragen { get; set; }
    public decimal BedragTeOntvangen { get; set; }
    public HaarwerkCreditType CreditType { get; set; }
}