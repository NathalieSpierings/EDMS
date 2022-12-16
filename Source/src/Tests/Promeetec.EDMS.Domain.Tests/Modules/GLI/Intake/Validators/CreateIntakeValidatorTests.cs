using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Commands;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Intake.Validators;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.GLI.Intake.Validators;

[TestFixture]
public class CreateIntakeValidatorTests : TestFixtureBase
{
    private CreateIntakeValidator _validator;

   
    [SetUp]
    public void Setup()
    {
        _validator = new CreateIntakeValidator();
    }


    [Test]
    public void Should_have_validation_error_when_intakedatum_is_empty()
    {
        var command = Fixture.Build<CreateIntake>().With(x => x.IntakeDatum, DateTime.MinValue).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.IntakeDatum);
    }

    [Test]
    public void Should_have_validation_error_when_intakedatum_is_not_valid()
    {
        var command = Fixture.Build<CreateIntake>().With(x => x.IntakeDatum, new DateTime(75, 7, 22)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.IntakeDatum);
    }

    [Test]
    public void Should_have_validation_error_when_intakedatum_is_in_feature()
    {
        var command = Fixture.Build<CreateIntake>().With(x => x.IntakeDatum, DateTime.Now.AddDays(1)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.IntakeDatum);
    }

    [Test]
    public void Should_have_validation_error_when_verzekerde_is_empty()
    {
        var command = Fixture.Build<CreateIntake>().With(x => x.VerzekerdeId, Guid.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.VerzekerdeId);
    }

    [Test]
    public void Should_have_validation_error_when_behandelaar_is_empty()
    {
        var command = Fixture.Build<CreateIntake>().With(x => x.BehandelaarId, Guid.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.BehandelaarId);
    }
}