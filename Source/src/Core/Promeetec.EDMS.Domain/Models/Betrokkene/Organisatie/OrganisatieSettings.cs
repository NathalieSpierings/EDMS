using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;

[Owned]
public class OrganisatieSettings
{
    /// <summary>
    /// The aanleverbestand location for the organisatie.
    /// </summary>
    public string? AanleverbestandLocatie { get; set; }


    /// <summary>
    /// The aanleverstatus after writing aanleverbestanden for the organisatie.
    /// </summary>
    public AanleverStatusNaSchrijvenAanleverbestanden AanleverStatusNaSchrijvenAanleverbestanden { get; set; }
    
    /// <summary>
    /// The verwijzer for GLI visibiltity in the adresboek for this organisatie.
    /// </summary>
    public VerwijzerInAdresboekType VerwijzerInAdresboek { get; set; }
}
