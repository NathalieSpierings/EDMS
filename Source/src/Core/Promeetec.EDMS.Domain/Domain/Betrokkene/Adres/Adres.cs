using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Adres;

public class Adres : AggregateRoot
{
    /// <summary>
    /// The street of the address.
    /// </summary>
    [StringLength(200)]
    public string Straat { get; set; }


    /// <summary>
    /// The zip code of the address.
    /// </summary>
    [StringLength(50)]
    public string Postcode { get; set; }


    /// <summary>
    /// The house number of the address.
    /// </summary>
    [StringLength(50)]
    public string Huisnummer { get; set; }


    /// <summary>
    /// The house number addition of the address.
    /// </summary>
    [StringLength(50)]
    public string Huisnummertoevoeging { get; set; }


    /// <summary>
    /// The hometown of the address.
    /// </summary>
    [StringLength(200)]
    public string Woonplaats { get; set; }


    /// <summary>
    /// The country name of the address.
    /// </summary>
    public string LandNaam { get; set; }


    /// <summary>
    /// Value indicating when the insured person lives at the address.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? WoonachtigOp { get; set; }


    /// <summary>
    /// Value indicating untill the insured person lives at the address.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? WoonachtigTot { get; set; }


    /// <summary>
    /// Returns the complete address based on VEKTIS.
    /// </summary>
    public string VektisVolledigAdres => AdresExtensions.VolledigeAdres(Straat, Huisnummer, Huisnummertoevoeging, Postcode, Woonplaats, LandNaam);


    /// <summary>
    /// Returns the complete address.
    /// </summary>
    public string VolledigAdres => AdresExtensions.VolledigeAdres(Straat, Huisnummer, Huisnummertoevoeging, Postcode, Woonplaats, Land);


    #region Naivigation properties

    /// <summary>
    /// The unique identifier of the country for the address.
    /// </summary>
    public Guid? LandId { get; set; }


    /// <summary>
    /// Reference to the country for the address.
    /// </summary>
    public virtual Land.Land Land { get; set; }



    public virtual ICollection<VerzekerdeToAdres> Verzekerden { get; set; } = new List<VerzekerdeToAdres>();


    #endregion
}
