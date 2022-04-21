using Promeetec.EDMS.Domain.Domain.Modules.Declaratie.Aanlevering;

namespace Promeetec.EDMS.Domain.Domain.Document.Overigbestand;

/// <summary>
/// Overigbestand is een uitbereiding op <see cref="Bestand"/> en kan niet
/// bestaan zonder een <see cref="Aanlevering"/>.
/// </summary>
public class Overigbestand : Bestand.Bestand
{
    /// <summary>
    /// The unique identifier of the aanlevering for the overig bestand.
    /// </summary>
    public Guid AanleveringId { get; set; }


    /// <summary>
    /// Reference to the aanlevering for the overig bestand.
    /// </summary>
    public virtual Aanlevering Aanlevering { get; set; }


    public Overigbestand() { }
}