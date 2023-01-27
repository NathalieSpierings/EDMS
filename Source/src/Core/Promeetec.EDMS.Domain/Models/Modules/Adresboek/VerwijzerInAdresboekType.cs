using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Adresboek
{
    public enum VerwijzerInAdresboekType
    {
        [Display(Name = "Verwijzer is niet aanwezig in het adresboek")]
        VerwijzerNietZichtbaar = 0,

        [Display(Name = "Verwijzer is een optioneel veld in het adresboek")]
        VewijzerOptioneel = 1,

        [Display(Name = "Verwijzer is een verplicht veld in het adresboek")]
        VerwijzerVerplicht = 2
    }
}
