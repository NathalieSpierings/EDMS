using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Domain.Extensions;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;

[Index(nameof(VolledigeNaam), nameof(FormeleNaam), nameof(Achternaam), nameof(Email))]
[Owned]
public class Persoon
{
    /// <summary>
    /// The gender of the person.
    /// </summary>
    public Geslacht Geslacht { get; set; }


    /// <summary>
    /// The date of birth of the person.
    /// </summary>
    public DateTime? Geboortedatum { get; set; }

    /// <summary>
    /// The initials of the person.
    /// </summary>
    [Required, MaxLength(20)]
    public string Voorletters { get; set; }

    /// <summary>
    /// The middle name of the person.
    /// </summary>
    [MaxLength(20)]
    public string Tussenvoegsel { get; set; }

    /// <summary>
    /// The first name of the person.
    /// </summary>
    [MaxLength(200)]
    public string Voornaam { get; set; }

    /// <summary>
    /// The last name of the person.
    /// </summary>
    [Required, MaxLength(256)]
    public string Achternaam { get; set; }

    /// <summary>
    /// The business phonenumber of the person.
    /// </summary>
    [MaxLength(50)]
    public string TelefoonZakelijk { get; set; }


    /// <summary>
    /// The private phonenumber of the person.
    /// </summary>
    [MaxLength(50)]
    public string TelefoonPrive { get; set; }


    /// <summary>
    /// The phonenumber extension of the person.
    /// </summary>
    [MaxLength(50)]
    public string Doorkiesnummer { get; set; }


    /// <summary>
    /// The email address of the person.
    /// </summary>
    [Required, MaxLength(450)]
    public string Email { get; set; }


    private string _volledigeNaam;

    /// <summary>
    /// The full name of the person.
    /// </summary>
    [MaxLength(450)]
    public string VolledigeNaam
    {
        get
        {
            if (string.IsNullOrEmpty(_volledigeNaam))
                _volledigeNaam = PersoonExtensions.SetVolledigeNaam(Voorletters, Tussenvoegsel, Achternaam, Voornaam);

            return _volledigeNaam;
        }
        set => _volledigeNaam = value;
    }


    private string _formeleNaam;


    /// <summary>
    /// The formal name of the person.
    /// </summary>
    [MaxLength(450)]
    public string FormeleNaam
    {
        get
        {
            if (string.IsNullOrEmpty(_formeleNaam))
                _formeleNaam = PersoonExtensions.SetFormeleNaam(Voorletters, Tussenvoegsel, Achternaam, Voornaam);

            return _formeleNaam;
        }
        set => _formeleNaam = value;
    }
}
