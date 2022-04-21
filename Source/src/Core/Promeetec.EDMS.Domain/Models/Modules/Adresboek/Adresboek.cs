using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;

namespace Promeetec.EDMS.Domain.Models.Modules.Adresboek;

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