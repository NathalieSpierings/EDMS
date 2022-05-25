using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Land;

public class Land : AggregateRoot
{
    /// <summary>
    /// The culture code of the country.
    /// </summary>
    [Required, MaxLength(50)]
    public string CultureCode { get; set; }


    /// <summary>
    /// The native name of the country.
    /// </summary>
    [Required, MaxLength(128)]
    public string NativeName { get; set; }


    /// <summary>
    /// The status of the country.
    /// </summary>
    public Status Status { get; set; }


    /// <summary>
    /// Creates an empty country.
    /// </summary>
    public Land()
    {

    }

    /// <summary>
    /// Creates a country.
    /// </summary>
    /// <param name="cmd">The create country command.</param>
    public Land(CreateCountry cmd)
    {
        Id = cmd.Id;

        CultureCode = cmd.CultureCode;
        NativeName = cmd.NativeName;
        Status = Status.Actief;
    }

    /// <summary>
    /// Update the details of the country.
    /// </summary>
    /// <param name="cmd">The update country command.</param>
    public void Update(UpdateCountry cmd)
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
