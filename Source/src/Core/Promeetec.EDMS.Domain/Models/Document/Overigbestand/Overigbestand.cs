using Promeetec.EDMS.Domain.Models.Document.Overigbestand.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering;

namespace Promeetec.EDMS.Domain.Models.Document.Overigbestand;

public class Overigbestand : Bestand.Bestand
{
    #region Navigation properties

    public Guid AanleveringId { get; set; }
    public virtual Aanlevering Aanlevering { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty overig bestand.
    /// </summary>
    public Overigbestand()
    {

    }


    /// <summary>
    /// Creates an aanleverbestand.
    /// </summary>
    /// <param name="cmd">The create aanleverbestand command.</param>
    public Overigbestand(CreateOverigBestand cmd)
    {
        Id = cmd.Id;

        FileName = cmd.FileName;
        FileSize = cmd.FileSize;
        Extension = cmd.Extension;
        MimeType = cmd.MimeType;
        Data = cmd.Data;
        EigenaarId = cmd.EigenaarId;
        AangemaaktOp = DateTime.Now;
        AangemaaktDoorId = cmd.UserId;
        AangemaaktDoor = cmd.UserDisplayName;

        AanleveringId = cmd.AanleveringId;
    }
}