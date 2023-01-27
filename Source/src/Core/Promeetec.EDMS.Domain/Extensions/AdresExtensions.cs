using System.Text;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Land;

namespace Promeetec.EDMS.Portaal.Domain.Extensions
{
    public static class AdresExtensions
    {
        public static string? VektisVolledigAdres(string straat, string huisnummer, string? huisnummertoevoeging, string postcode, string woonplaats, string? landNaam)
        {
            return VolledigeAdres(straat, huisnummer, huisnummertoevoeging, postcode, woonplaats, landNaam);
        }

        public static string? VolledigeAdres(string straat, string huisnummer, string? huisnummertoevoeging, string postcode, string woonplaats, Land land)
        {
            return VolledigeAdres(straat, huisnummer, huisnummertoevoeging, postcode, woonplaats, land != null ? land.NativeName : string.Empty);
        }

        public static string? VolledigeAdres(string straat, string huisnummer, string? huisnummertoevoeging, string postcode, string woonplaats, string? land)
        {
            var sb = new StringBuilder();

            var volledigeStraatAdres = GeefVolledigeStraatAdres(straat, huisnummer, huisnummertoevoeging);
            sb.AppendLine(volledigeStraatAdres);

            if (!string.IsNullOrWhiteSpace(postcode) && !string.IsNullOrEmpty(postcode))
                sb.Append(postcode.Replace(" ", string.Empty).ToUpper()).Append("  ");

            if (!string.IsNullOrWhiteSpace(woonplaats))
                sb.AppendLine(woonplaats);

            if (!string.IsNullOrWhiteSpace(land))
                sb.AppendLine(land);

            return sb.ToString().Trim();
        }

        public static string VolledigeStraatadres(string straat, string huisnummer, string? huisnummertoevoeging)
        {
            var sb = GeefVolledigeStraatAdres(straat, huisnummer, huisnummertoevoeging);
            return sb.ToString().Trim();
        }

        public static string GeefVolledigeStraatAdres(string straat, string huisnummer, string? huisnummertoevoeging)
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(straat))
                sb.Append(straat).Append(" ");

            if (!string.IsNullOrWhiteSpace(huisnummer))
                sb.Append(huisnummer).Append(" ");

            if (!string.IsNullOrWhiteSpace(huisnummertoevoeging))
                sb.Append(huisnummertoevoeging).Append(" ");

            return sb.ToString();
        }
    }
}