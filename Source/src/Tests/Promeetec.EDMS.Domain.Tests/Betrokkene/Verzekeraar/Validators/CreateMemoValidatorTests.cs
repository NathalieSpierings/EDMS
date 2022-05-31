using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar.Validators;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Verzekeraar.Validators;

[TestFixture]
public class CreateVerzekeraarValidatorTests : TestFixtureBase
{
    private CreateVerzekeraarValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateVerzekeraarValidator();
    }


    [Test]
    public void Should_have_validation_error_when_uzovi_is_empty()
    {
        var command = Fixture.Build<CreateVerzekeraar>().With(x => x.Uzovi, 0).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Uzovi);
    }

    [Test]
    public void Should_have_validation_error_when_name_is_empty()
    {
        var command = Fixture.Build<CreateVerzekeraar>().With(x => x.Naam, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }

    [Test]
    public void Should_have_validation_error_when_name_is_too_long()
    {
        var command = Fixture.Build<CreateVerzekeraar>().With(x => x.Naam, new string('*', 257)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }
}