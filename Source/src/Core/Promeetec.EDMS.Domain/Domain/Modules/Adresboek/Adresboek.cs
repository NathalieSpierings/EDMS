using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Modules.Adresboek;

[Table("Adresboek")]
public class Adresboek : AggregateRoot
{
    ///// <summary>
    ///// The unique identifier of the organisatie for the voorraad.
    ///// </summary>
    //public Guid OrganisatieId { get; set; }

    /// <summary>
    /// Reference to the organisatie for the adresboek.
    /// </summary>
    public virtual Organisatie Organisatie { get; set; }

    public virtual IList<Verzekerde> Verzekerden { get; set; } = new List<Verzekerde>();


    public Adresboek() { }
}