using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanleverbericht.Validators;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Declaratie.Aanleverbericht.Validators;

[TestFixture]
public class CreateAanleverberichtValidatorTests : TestFixtureBase
{
    private CreateAanleverberichtValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateAanleverberichtValidator();
    }

    [Test]
    public void Should_have_validation_error_when_onderwerp_is_empty()
    {
        var command = Fixture.Build<CreateAanleverbericht>().With(x => x.Onderwerp, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Onderwerp);
    }

    [Test]
    public void Should_have_validation_error_when_onderwerp_is_too_long()
    {
        var command = Fixture.Build<CreateAanleverbericht>().With(x => x.Onderwerp, new string('*', 460)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Onderwerp);
    }

    [Test]
    public void Should_have_validation_error_when_bericht_is_empty()
    {
        var command = Fixture.Build<CreateAanleverbericht>().With(x => x.Bericht, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Bericht);
    }

    [Test]
    public void Should_have_validation_error_when_bericht_is_too_long()
    {
        var command = Fixture.Build<CreateAanleverbericht>().With(x => x.Bericht, new string('*', 10005)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Bericht);
    }
}