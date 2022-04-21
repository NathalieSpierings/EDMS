using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Domain.COV;
using Promeetec.EDMS.Domain.Domain.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Domain.Modules.ION;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie.Commands;

public class UpdateOrganisatie : CommandBase
{
    public string Naam { get; set; }
    public string TelefoonZakelijk { get; set; }
    public string TelefoonPrive { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string AgbCodeOnderneming { get; set; }
    public bool Zorggroep { get; set; }
    public byte[] Logo { get; set; }
    public IONZoekOptie IONZoekoptie { get; set; }
    public string AanleverbestandLocatie { get; set; }
    public AanleverStatusNaSchrijvenAanleverbestanden AanleverStatusNaSchrijvenAanleverbestanden { get; set; }
    public COVControleType COVControleType { get; set; }
    public COVControleProcessType COVControleProcessType { get; set; }

}
