using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Promeetec.EDMS.Reporting.Private.Attributes;

public class RequiredIfAttribute : ValidationAttribute, IClientValidatable
{
    private string PropertyName { get; set; }
    private object DesiredValue { get; set; }

    private readonly RequiredAttribute _innerAttribute;

    public RequiredIfAttribute(string propertyName, object desiredvalue)
    {
        PropertyName = propertyName;
        DesiredValue = desiredvalue;
        _innerAttribute = new RequiredAttribute();
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dependentValue = validationContext.ObjectInstance.GetType().GetProperty(PropertyName).GetValue(validationContext.ObjectInstance, null);
        if (dependentValue?.ToString() == DesiredValue.ToString())
        {
            if (!_innerAttribute.IsValid(value))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName), new[] { validationContext.MemberName });
            }
        }

        return ValidationResult.Success;
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule
        {
            ErrorMessage = ErrorMessageString,
            ValidationType = "requiredif",
            ValidationParameters =
            {
                ["dependentproperty"] = (context as ViewContext).ViewData.TemplateInfo.GetFullHtmlFieldId(PropertyName),
                ["desiredvalue"] = DesiredValue is bool ? DesiredValue.ToString().ToLower() : DesiredValue
            }
        };

        yield return rule;
    }
}