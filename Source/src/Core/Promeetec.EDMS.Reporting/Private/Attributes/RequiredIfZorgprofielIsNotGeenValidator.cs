using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;

namespace Promeetec.EDMS.Reporting.Private.Attributes;

public class RequiredIfZorgprofielIsNotGeenValidatorAttribute : ValidationAttribute, IClientValidatable
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var model = (ZorgprofielViewModel)validationContext.ObjectInstance;

        if (model.ProfielCode != null && model.ProfielCode != ProfielCode.Geen && model.ProfielStartdatum == null)
        {
            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
            return new ValidationResult(errorMessage);
        }

        return ValidationResult.Success;
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule
        {
            ErrorMessage = "Als je een profiel kiest moet u een profiel startdatum invoeren.",
            ValidationType = "zorgprofielisnotgeen"
        };

        yield return rule;
    }
}