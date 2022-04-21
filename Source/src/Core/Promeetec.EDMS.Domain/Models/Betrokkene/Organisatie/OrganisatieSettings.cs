using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Domain.Models.Cov;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;
using Promeetec.EDMS.Domain.Models.Modules.ION;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;

[Owned]
public class OrganisatieSettings
{
    /// <summary>
    /// The ION search option for the organisatie.
    /// </summary>
    public IONZoekOptie IONZoekoptie { get; set; }


    /// <summary>
    /// The aanleverbestand location for the organisatie.
    /// </summary>
    public string? AanleverbestandLocatie { get; set; }


    /// <summary>
    /// The aanleverstatus after writing aanleverbestanden for the organisatie.
    /// </summary>
    public AanleverStatusNaSchrijvenAanleverbestanden AanleverStatusNaSchrijvenAanleverbestanden { get; set; }


    /// <summary>
    /// The COV controle type for the organisatie.
    /// </summary>
    public COVControleType COVControleType { get; set; }


    /// <summary>
    /// The COV controle process type for the organisatie.
    /// </summary>
    public COVControleProcessType COVControleProcessType { get; set; }

    /// <summary>
    /// The verwijzer for GLI visibiltity in the adresboek for this organisatie.
    /// </summary>
    public VerwijzerInAdresboekType VerwijzerInAdresboek { get; set; }
}
