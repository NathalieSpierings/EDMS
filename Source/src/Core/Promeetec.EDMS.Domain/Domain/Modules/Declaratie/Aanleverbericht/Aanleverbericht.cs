using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Modules.Declaratie.Aanleverbericht;

public class Aanleverbericht : AggregateRoot
{
    /// <summary>
    /// The subject of the aanleverbericht.
    /// </summary>
    [StringLength(450)]
    public string Onderwerp { get; set; }


    /// <summary>
    /// The message of the aanleverbericht.
    /// </summary>
    [Required, MaxLength]
    public string Bericht { get; set; }


    /// <summary>
    /// The sort order of the aanleverbericht.
    /// </summary>
    [Required]
    public int Volgorde { get; set; }


    /// <summary>
    /// Indicator if the aanleverbericht is readed yes or no.
    /// </summary>
    public bool Gelezen { get; set; }


    /// <summary>
    /// The placement date of the aanleverbericht.
    /// </summary>
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime GeplaatstOp { get; set; }


    /// <summary>
    /// The last readed date of the aanleverbericht.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? LaastGelezenOp { get; set; }


    /// <summary>
    /// The status of the aanleverbericht.
    /// </summary>
    public AanleverberichtStatus AanleverberichtStatus { get; set; }

    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }

    #region Navigation properties

    /// <summary>
    /// The unique identifier of the last reader of the aanleverbericht.
    /// </summary>
    public Guid? LaasteLezerId { get; set; }

    /// <summary>
    /// Reference to the last reader of the aanleverbericht.
    /// </summary>
    public Medewerker LaasteLezer { get; set; }



    /// <summary>
    /// The unique identifier of the reciever of the aanleverbericht.
    /// </summary>
    public Guid OntvangerId { get; set; }

    /// <summary>
    /// Reference to the reciever of the aanleverbericht.
    /// </summary>
    public Medewerker Ontvanger { get; set; }



    /// <summary>
    /// The unique identifier of the sender of the aanleverbericht.
    /// </summary>
    public Guid AfzenderId { get; set; }

    /// <summary>
    /// Reference to the sender of the aanleverbericht.
    /// </summary>
    public Medewerker Afzender { get; set; }



    /// <summary>
    /// The unique identifier of the parent of the aanleverbericht.
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// Reference to the parent of the aanleverbericht.
    /// </summary>
    public Aanleverbericht Parent { get; set; }



    /// <summary>
    /// The unique identifier of the aanlevering for the aanleverbericht.
    /// </summary>
    public Guid AanleveringId { get; set; }

    /// <summary>
    /// Reference to the aanlevering for the aanleverbericht.
    /// </summary>
    public Aanlevering.Aanlevering Aanlevering { get; set; }

    #endregion


    public Aanleverbericht() { }
}