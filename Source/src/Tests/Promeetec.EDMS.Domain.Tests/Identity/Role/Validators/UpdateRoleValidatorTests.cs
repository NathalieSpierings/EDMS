using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Validators;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Identity.Role.Validators;

[TestFixture]
public class UpdateRoleValidatorTests : TestFixtureBase
{
    private UpdateRoleValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new UpdateRoleValidator();
    }


    [Test]
    public void Should_have_validation_error_when_name_is_empty()
    {
        var command = Fixture.Build<UpdateRole>().With(x => x.Name, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public void Should_have_validation_error_when_name_is_too_long()
    {
        var command = Fixture.Build<UpdateRole>().With(x => x.Name, new string('*', 251)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public void Should_have_validation_error_when_description_is_empty()
    {
        var command = Fixture.Build<UpdateRole>().With(x => x.Description, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Test]
    public void Should_have_validation_error_when_description_is_too_long()
    {
        var command = Fixture.Build<UpdateRole>().With(x => x.Description, new string('*', 2000)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
}