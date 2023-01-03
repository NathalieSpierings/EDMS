using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;

namespace Promeetec.EDMS.Reporting.Private.Attributes;

public class RequiredWhenVerwijsDatumInAdresboek : ValidationAttribute, IClientValidatable
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

        var date = value is DateTime ? (DateTime)value : default;
        return date != null && date != DateTime.MinValue
            ? ValidationResult.Success
            : new ValidationResult("Verwijsdsatum is verplicht.");
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule
        {
            ErrorMessage = "Verwijsdsatum is verplicht.",
            ValidationType = "verwijsdatuminadresboek"
        };
        yield return rule;
    }
}