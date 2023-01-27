using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Validators;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Admin.Zorgstraat.Validators;

[TestFixture]
public class CreateZorgstraatValidatorTests : TestFixtureBase
{
    private CreateZorgstraatValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateZorgstraatValidator();
    }


    [Test]
    public void Should_have_validation_error_when_naam_is_empty()
    {
        var command = Fixture.Build<CreateZorgstraat>().With(x => x.Naam, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }

    [Test]
    public void Should_have_validation_error_when_naam_is_too_long()
    {
        var command = Fixture.Build<CreateZorgstraat>().With(x => x.Naam, new string('*', 222)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }
}