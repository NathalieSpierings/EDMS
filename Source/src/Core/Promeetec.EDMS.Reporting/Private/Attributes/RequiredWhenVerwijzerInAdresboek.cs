using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

namespace Promeetec.EDMS.Reporting.Private.Attributes;

public class RequiredWhenVerwijzerInAdresboek : ValidationAttribute, IClientValidatable
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var createModel = validationContext.ObjectInstance as VerzekerdeCreateViewModel;
        var editModel = validationContext.ObjectInstance as VerzekerdeEditViewModel;


        if (createModel is VerzekerdeCreateViewModel)
        {
            if (createModel.Organisatie.VerwijzerInAdresboek != VerwijzerInAdresboekType.VerwijzerVerplicht)
                return ValidationResult.Success;
        }
        else if (editModel is VerzekerdeEditViewModel)
        {
            if (editModel.Organisatie.VerwijzerInAdresboek != VerwijzerInAdresboekType.VerwijzerVerplicht)
                return ValidationResult.Success;
        }
        else
        {
            return ValidationResult.Success;
        }

        var agb = value as string;
        return string.IsNullOrWhiteSpace(agb)
            ? new ValidationResult("Agbcode verwijzer is verplicht.")
            : ValidationResult.Success;
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule
        {
            ErrorMessage = "Agbcode verwijzer is verplicht.",
            ValidationType = "verwijzerinadresboek"
        };
        yield return rule;
    }
}