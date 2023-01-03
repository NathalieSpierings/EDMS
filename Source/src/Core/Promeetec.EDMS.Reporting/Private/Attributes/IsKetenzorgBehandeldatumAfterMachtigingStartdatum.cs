using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Promeetec.EDMS.Reporting.Private.Attributes;

public sealed class IsKetenzorgBehandeldatumAfterMachtigingStartdatum : ValidationAttribute, IClientValidatable
{
    private readonly string testedPropertyName;
    private readonly bool allowEqualDates;

    public IsKetenzorgBehandeldatumAfterMachtigingStartdatum(string testedPropertyName, bool allowEqualDates = false)
    {
        this.testedPropertyName = testedPropertyName;
        this.allowEqualDates = allowEqualDates;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var propertyTestedInfo = validationContext.ObjectType.GetProperty(testedPropertyName);
        if (propertyTestedInfo == null)
            return new ValidationResult($"unknown property {testedPropertyName}");

        var propertyTestedValue = propertyTestedInfo.GetValue(validationContext.ObjectInstance, null);

        if (value == null || !(value is DateTime))
            return ValidationResult.Success;


        if (propertyTestedValue == null || !(propertyTestedValue is DateTime))
            return ValidationResult.Success;

        // Compare values
        if ((DateTime)propertyTestedValue >= (DateTime)value)
        {
            if (allowEqualDates)
                return ValidationResult.Success;

            if ((DateTime)propertyTestedValue > (DateTime)value)
                return ValidationResult.Success;
        }

        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule
        {
            ErrorMessage = ErrorMessageString,
            ValidationType = "isketenzorgbehandeldatumaftermachtigingstartdatum",
            ValidationParameters =
            {
                ["propertytested"] = testedPropertyName,
                ["allowequaldates"] = allowEqualDates
            }
        };
        yield return rule;
    }
}