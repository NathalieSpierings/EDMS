using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Document.Rapportage.Commands;
using Promeetec.EDMS.Domain.Models.Document.Rapportage.Validators;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Document.Rapportage.Validators;

[TestFixture]
public class CreateRapportageValidatorTests : TestFixtureBase
{
    private CreateRapportageValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateRapportageValidator();
    }

    [Test]
    public void Should_have_validation_error_when_filename_is_empty()
    {
        var command = Fixture.Build<CreateRapportage>().With(x => x.FileName, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.FileName);
    }

    [Test]
    public void Should_have_validation_error_when_filename_is_too_long()
    {
        var command = Fixture.Build<CreateRapportage>().With(x => x.FileName, new string('*', 455)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.FileName);
    }
}