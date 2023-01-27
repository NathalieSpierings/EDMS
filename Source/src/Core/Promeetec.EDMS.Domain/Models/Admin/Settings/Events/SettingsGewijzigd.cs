using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Settings.Events;

public class SettingsGewijzigd : EventBase
{
    public string Straat { get; set; }
    public string Huisnummer { get; set; }
    public string Huisnummertoevoeging { get; set; }
    public string Postcode { get; set; }
    public string Woonplaats { get; set; }
    public string Telefoon { get; set; }
    public string Email { get; set; }
    public decimal BedragBasisVerzekering { get; set; }
}