using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;

namespace Promeetec.EDMS.Reporting.Private.Attributes;

public class RequiredIfZorgprofielIsGeenValidatorAttribute : ValidationAttribute, IClientValidatable
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var model = (ZorgprofielViewModel)validationContext.ObjectInstance;

        if (model.ProfielCode == ProfielCode.Geen && model.ProfielEinddatum == null)
        {
            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }

        return ValidationResult.Success;
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        var rule = new ModelClientValidationRule
        {
            ErrorMessage = "Als u voor profiel 'Geen' kiest moet u een profiel einddatum invoeren.",
            ValidationType = "zorgprofielisgeen"
        };
        yield return rule;
    }
}