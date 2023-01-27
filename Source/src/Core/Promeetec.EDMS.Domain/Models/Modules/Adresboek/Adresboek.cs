using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Adresboek;

public class Adresboek : AggregateRoot
{
    #region Navigation properties

    public virtual Organisatie Organisatie { get; set; }
    public virtual ICollection<Verzekerde> Verzekerden { get; set; } = new List<Verzekerde>();

    #endregion


    /// <summary>
    /// Creates an empty addressbook.
    /// </summary>
    public Adresboek()
    {

    }
}