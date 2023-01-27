using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat;

public class Zorgstraat : AggregateRoot
{
    /// <summary>
    /// The name of the zorgstraat.
    /// </summary>
    [Required, MaxLength(200)]
    public string Naam { get; set; }


    /// <summary>
    /// The status of the zorgstraat.
    /// </summary>
    public Status Status { get; set; }



    /// <summary>
    /// Creates an empty zorgstraat.
    /// </summary>
    public Zorgstraat()
    {

    }

    /// <summary>
    /// Creates a zorgstraat.
    /// </summary>
    /// <param name="cmd">The create zorgstraat command.</param>
    public Zorgstraat(CreateZorgstraat cmd)
    {
        Id = cmd.Id;

        Naam = cmd.Naam;
        Status = Status.Actief;
    }

    /// <summary>
    /// Update the details of the zorgstraat.
    /// </summary>
    /// <param name="cmd">The update zorgstraat command.</param>
    public void Update(UpdateZorgstraat cmd)
    {
        Naam = cmd.Naam;
    }

    /// <summary>
    /// Set the status as deleted.
    /// </summary>
    public void Delete()
    {
        Status = Status.Verwijderd;
    }

    /// <summary>
    /// Sets the status of the country as suspended.
    /// The country will no longer be able.
    /// </summary>
    public void Suspend()
    {
        Status = Status.Inactief;
    }

    /// <summary>
    /// Reinstates the country if suspended.
    /// </summary>
    public void Reinstate()
    {
        Status = Status.Actief;
    }
}
