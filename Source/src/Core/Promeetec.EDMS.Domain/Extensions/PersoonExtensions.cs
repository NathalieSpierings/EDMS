using System.Text;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;

namespace Promeetec.EDMS.Domain.Extensions;

public static class PersoonExtensions
{
    public static string Aanhef(Geslacht geslacht)
    {
        string afkorting;
        switch (geslacht)
        {
            case Geslacht.Mannelijk:
                afkorting = "Dhr.";
                break;

            case Geslacht.Vrouwelijk:
                afkorting = "Mevr.";
                break;
            default:
                afkorting = "heer, mevrouw";
                break;
        }

        return afkorting;
    }

    public static string GeslachtAfkorting(Geslacht geslacht)
    {
        string afkorting;
        switch (geslacht)
        {
            case Geslacht.Mannelijk:
                afkorting = "Hr";
                break;

            case Geslacht.Vrouwelijk:
                afkorting = "Mw";
                break;
            default:
                afkorting = "Hr/Mw";
                break;
        }

        return afkorting;
    }

    public static string Aanhef(Geslacht geslacht, string tussenvoegsel, string achternaam)
    {
        string aanhef;
        switch (geslacht)
        {
            case Geslacht.Mannelijk:
                aanhef = $"heer {SetKorteNaam(tussenvoegsel, achternaam)}";
                break;

            case Geslacht.Vrouwelijk:
                aanhef = $"mevrouw {SetKorteNaam(tussenvoegsel, achternaam)}";
                break;
            default:
                aanhef = $"heer/mevrouw {SetKorteNaam(tussenvoegsel, achternaam)}";
                break;
        }

        return aanhef;
    }


    public static string SetFormeleNaam(string voorletters, string tussenvoegsel, string achternaam, string? voornaam = default)
    {
        string naam;
        if (!string.IsNullOrWhiteSpace(voornaam))
        {
            naam = !string.IsNullOrEmpty(tussenvoegsel) ?
                !string.IsNullOrEmpty(achternaam) ? $"{achternaam}, {tussenvoegsel} {voornaam}" : $"{tussenvoegsel} {voornaam}" :
                !string.IsNullOrEmpty(achternaam) ? $"{achternaam}, {voornaam}" : $"{VoorlettersMetPunten(voorletters)}";
        }
        else
        {
            if (!string.IsNullOrEmpty(voorletters))
            {
                naam = !string.IsNullOrEmpty(tussenvoegsel) ?
                    !string.IsNullOrEmpty(achternaam) ? $"{achternaam}, {tussenvoegsel} {VoorlettersMetPunten(voorletters)}  " : $"{tussenvoegsel} {VoorlettersMetPunten(voorletters)}" :
                    !string.IsNullOrEmpty(achternaam) ? $"{achternaam}, {VoorlettersMetPunten(voorletters)}" : !string.IsNullOrEmpty(VoorlettersMetPunten(voorletters)) ? $"{VoorlettersMetPunten(voorletters)}" : string.Empty;
            }
            else
            {
                naam = !string.IsNullOrEmpty(tussenvoegsel) ?
                    !string.IsNullOrEmpty(achternaam) ? $"{achternaam}, {tussenvoegsel}" : !string.IsNullOrEmpty(tussenvoegsel) ? $"{tussenvoegsel}" : string.Empty :
                    !string.IsNullOrEmpty(achternaam) ? $"{achternaam}" : string.Empty;
            }
        }

        return naam;
    }

    public static string SetVolledigeNaam(string voorletters, string? tussenvoegsel, string achternaam, string? voornaam = default)
    {
        string naam;
        if (!string.IsNullOrWhiteSpace(voornaam))
        {
            naam = !string.IsNullOrEmpty(tussenvoegsel) ?
                !string.IsNullOrEmpty(achternaam) ? $"{voornaam} {tussenvoegsel} {achternaam}" : $"{voornaam} {tussenvoegsel}" :
                !string.IsNullOrEmpty(achternaam) ? $"{voornaam} {achternaam}" : $"{VoorlettersMetPunten(voorletters)}";
        }
        else
        {
            if (!string.IsNullOrEmpty(voorletters))
            {
                naam = !string.IsNullOrEmpty(tussenvoegsel) ?
                    !string.IsNullOrEmpty(achternaam) ? $"{VoorlettersMetPunten(voorletters)} {tussenvoegsel} {achternaam}" : $"{VoorlettersMetPunten(voorletters)} {tussenvoegsel}" :
                    !string.IsNullOrEmpty(achternaam) ? $"{VoorlettersMetPunten(voorletters)} {achternaam}" : !string.IsNullOrEmpty(VoorlettersMetPunten(voorletters)) ? $"{voorletters}" : string.Empty;
            }
            else
            {
                naam = !string.IsNullOrEmpty(tussenvoegsel) ?
                    !string.IsNullOrEmpty(achternaam) ? $"{tussenvoegsel} {achternaam}" : !string.IsNullOrEmpty(tussenvoegsel) ? $"{tussenvoegsel}" : string.Empty :
                    !string.IsNullOrEmpty(achternaam) ? $"{achternaam}" : string.Empty;
            }
        }

        return naam;
    }

    public static string SetKorteNaam(string tussenvoegsel, string achternaam)
    {
        var korteNaam = $"{(!string.IsNullOrWhiteSpace(tussenvoegsel) ? tussenvoegsel + " " : string.Empty)}{(!string.IsNullOrWhiteSpace(achternaam) ? achternaam : null)}";

        return korteNaam;
    }

    public static string VoorlettersMetPunten(string voorletters)
    {
        var sb = new StringBuilder();

        foreach (char c in voorletters)
            sb.Append(c).Append('.');

        return sb.ToString();
    }

    public static string VerwijderPunten(string tekst)
    {
        var sb = new StringBuilder();
        foreach (char c in tekst)
        {
            if (c != '.')
                sb.Append(c);
        }

        return sb.ToString();
    }

    public static string GenerateUserName(string organisatieNummer, string voorletters, string tussenvoegsel, string achternaam)
    {
        voorletters = voorletters.Replace(".", "");
        tussenvoegsel = tussenvoegsel?.Replace(" ", string.Empty).Replace("'", string.Empty);
        achternaam = achternaam.Replace(" ", string.Empty).Replace("-", string.Empty);
        return $"{organisatieNummer}-{voorletters.ToLower()}{tussenvoegsel?.ToLower()}{achternaam.ToLower()}";
    }
}