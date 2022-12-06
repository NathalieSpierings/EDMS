using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.Settings;

public class Settings : AggregateRoot
{
    /// <summary>
    /// The street of the address.
    /// </summary>
    [Required, MaxLength(200)]
    public string Straat { get; set; }

    /// <summary>
    /// The house number of the address.
    /// </summary>
    [Required, MaxLength(50)]
    public string Huisnummer { get; set; }

    /// <summary>
    /// The house number addition of the address.
    /// </summary>
    [MaxLength(50)]
    public string Huisnummertoevoeging { get; set; }

    /// <summary>
    /// The zip code of the address.
    /// </summary>
    [Required, MaxLength(50)]
    public string Postcode { get; set; }

    /// <summary>
    /// The hometown of the address.
    /// </summary>
    [Required, MaxLength(200)]
    public string Woonplaats { get; set; }

    /// <summary>
    /// The business phonenumber of the person.
    /// </summary>
    [MaxLength(50)]
    public string Telefoon { get; set; }

    /// <summary>
    /// The business phonenumber of the person.
    /// </summary>
    [MaxLength(450)]
    public string Email { get; set; }

    public SettingsHaarwerk Haarwerk { get; set; }


    /// <summary>
    /// Creates an empty setting.
    /// </summary>
    public Settings()
    {

    }

    /// <summary>
    /// Update the settings.
    /// </summary>
    /// <param name="cmd">The update settings command.</param>
    public void Update(UpdateSettings cmd)
    {
        Straat = cmd.Straat;
        Huisnummer = cmd.Huisnummer;
        Huisnummertoevoeging = cmd.Huisnummertoevoeging;
        Postcode = cmd.Postcode;
        Woonplaats = cmd.Woonplaats;
        Telefoon = cmd.Telefoon;
        Email = cmd.Email;
        Haarwerk = cmd.Haarwerk;
    }
}
