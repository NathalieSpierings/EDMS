using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Cov;

public enum COVControleType
{
    [Display(Name = "COV Controle bij aanmaken aanlevering")]
    COVControleBijAanlevering = 0,

    [Display(Name = "COV Controle bij toevoegen aan voorraad")]
    COVControleBijVoorraad = 1
}