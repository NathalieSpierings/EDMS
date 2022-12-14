using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land;

public class Land : AggregateRoot
{
    /// <summary>
    /// The culture code of the land.
    /// </summary>
    [Required, MaxLength(50)]
    public string CultureCode { get; set; }


    /// <summary>
    /// The native name of the land.
    /// </summary>
    [Required, MaxLength(128)]
    public string NativeName { get; set; }


    /// <summary>
    /// The status of the land.
    /// </summary>
    public Status Status { get; set; }


    /// <summary>
    /// Creates an empty land.
    /// </summary>
    public Land() { }


    /// <summary>
    /// Creates a land.
    /// </summary>
    /// <param name="cmd">The create land command.</param>
    public Land(CreateLand cmd)
    {
        Id = cmd.Id;

        CultureCode = cmd.CultureCode;
        NativeName = cmd.NativeName;
        Status = Status.Actief;
    }

    /// <summary>
    /// Update the details of the land.
    /// </summary>
    /// <param name="cmd">The update land command.</param>
    public void Update(UpdateLand cmd)
    {
        CultureCode = cmd.CultureCode;
        NativeName = cmd.NativeName;
    }

    /// <summary>
    /// Set the status as deleted.
    /// </summary>
    public void Delete()
    {
        Status = Status.Verwijderd;
    }


    /// <summary>
    /// Sets the status of the land as suspended.
    /// The land will no longer be able.
    /// </summary>
    public void Suspend()
    {
        Status = Status.Inactief;
    }

    /// <summary>
    /// Reinstates the land if suspended.
    /// </summary>
    public void Reinstate()
    {
        Status = Status.Actief;
    }
}
