using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Domain.Document.Aanleverbestand.Aanleverberstand;

namespace Promeetec.EDMS.Domain.Domain.Modules.Declaratie.Voorraad;

public class Voorraad : AggregateRoot
{
    public Voorraad() { }


    #region Navigation properties

    /// <summary>
    /// Reference to the organisatie for the voorraad.
    /// </summary>
    public Organisatie Organisatie { get; set; }
    public IList<Aanleverbestand> Voorraadbestanden { get; set; } = new List<Aanleverbestand>();

    #endregion

}
