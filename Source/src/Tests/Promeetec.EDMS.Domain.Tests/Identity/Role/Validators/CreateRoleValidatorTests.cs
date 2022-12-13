using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Identity.Role.Commands;
using Promeetec.EDMS.Domain.Models.Identity.Role.Validators;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Identity.Role.Validators;

[TestFixture]
public class CreateRoleValidatorTests : TestFixtureBase
{
    private CreateRoleValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateRoleValidator();
    }


    [Test]
    public void Should_have_validation_error_when_name_is_empty()
    {
        var command = Fixture.Build<CreateRole>().With(x => x.Name, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public void Should_have_validation_error_when_name_is_too_long()
    {
        var command = Fixture.Build<CreateRole>().With(x => x.Name, new string('*', 251)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public void Should_have_validation_error_when_description_is_empty()
    {
        var command = Fixture.Build<CreateRole>().With(x => x.Description, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Test]
    public void Should_have_validation_error_when_description_is_too_long()
    {
        var command = Fixture.Build<CreateRole>().With(x => x.Description, new string('*', 2000)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
}