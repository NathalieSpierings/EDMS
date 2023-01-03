using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Promeetec.EDMS.Reporting.Private.Attributes;

public sealed class IsLessThan : ValidationAttribute, IClientValidatable
{
    private readonly string testedPropertyName;
    private readonly bool allowEquals;
    private object propertyTestedValue;

    public IsLessThan(string testedPropertyName, bool allowEquals = false)
    {
        this.testedPropertyName = testedPropertyName;
        this.allowEquals = allowEquals;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var propertyTestedInfo = validationContext.ObjectType.GetProperty(testedPropertyName);
        if (propertyTestedInfo == null)
            return new ValidationResult($"unknown property {testedPropertyName}");

        propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);

        if (value == null || !(value is int))
            return ValidationResult.Success;


        if (propertyTestedValue == null || !(propertyTestedValue is int))
            return ValidationResult.Success;


        // Compare values
        if ((int)value <= (int)propertyTestedValue)
        {
            if (allowEquals)
                return ValidationResult.Success;

            if ((int)value < (int)propertyTestedValue)
                return ValidationResult.Success;
        }

        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule
        {
            ErrorMessage = ErrorMessageString,
            ValidationType = "islessthan",
            ValidationParameters =
            {
                ["propertytested"] = testedPropertyName,
                ["allowequals"] = allowEquals
            }
        };
        yield return rule;
    }
}