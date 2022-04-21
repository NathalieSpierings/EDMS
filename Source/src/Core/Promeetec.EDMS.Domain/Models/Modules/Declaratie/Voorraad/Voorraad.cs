using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Voorraad;

public class Voorraad : AggregateRoot
{
    #region Navigation properties

    public virtual Organisatie Organisatie { get; set; }
    public virtual ICollection<Aanleverbestand> Voorraadbestanden { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty voorraad.
    /// </summary>
    public Voorraad()
    {
    }
}
