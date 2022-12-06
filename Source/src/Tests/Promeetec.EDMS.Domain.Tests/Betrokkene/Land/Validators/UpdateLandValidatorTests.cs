using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Validators;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Land.Validators;

[TestFixture]
public class UpdateLandValidatorTests : TestFixtureBase
{
    private UpdateLandValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new UpdateLandValidator();
    }


    [Test]
    public void Should_have_validation_error_when_culturecode_is_empty()
    {
        var command = Fixture.Build<UpdateLand>().With(x => x.CultureCode, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.CultureCode);
    }

    [Test]
    public void Should_have_validation_error_when_culturecode_is_too_long()
    {
        var command = Fixture.Build<UpdateLand>().With(x => x.CultureCode, new string('*', 51)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.CultureCode);
    }

    [Test]
    public void Should_have_validation_error_when_nativename_is_empty()
    {
        var command = Fixture.Build<UpdateLand>().With(x => x.NativeName, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.NativeName);
    }

    [Test]
    public void Should_have_validation_error_when_nativename_is_too_long()
    {
        var command = Fixture.Build<UpdateLand>().With(x => x.NativeName, new string('*', 129)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.NativeName);
    }
}