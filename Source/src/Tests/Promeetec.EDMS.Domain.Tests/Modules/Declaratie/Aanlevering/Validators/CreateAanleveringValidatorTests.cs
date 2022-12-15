using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Validators;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Declaratie.Aanlevering.Validators;

[TestFixture]
public class CreateAanleveringValidatorTests : TestFixtureBase
{
    private CreateAanleveringValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateAanleveringValidator();
    }


    [Test]
    public void Should_have_validation_error_when_referentie_is_empty()
    {
        var command = Fixture.Build<CreateAanlevering>().With(x => x.Referentie, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Referentie);
    }

    [Test]
    public void Should_have_validation_error_when_referentie_is_too_long()
    {
        var command = Fixture.Build<CreateAanlevering>().With(x => x.Referentie, new string('*', 251)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Referentie);
    }

    [Test]
    public void Should_have_validation_error_when_referentie_promeetec_is_too_long()
    {
        var command = Fixture.Build<CreateAanlevering>().With(x => x.ReferentiePromeetec, new string('*', 251)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.ReferentiePromeetec);
    }

    [Test]
    public void Should_have_validation_error_when_eigenaar_is_empty()
    {
        var command = Fixture.Build<CreateAanlevering>().With(x => x.EigenaarId, Guid.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.EigenaarId);
    }

    [Test]
    public void Should_have_validation_error_when_behandelaar_is_empty()
    {
        var command = Fixture.Build<CreateAanlevering>().With(x => x.BehandelaarId, Guid.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.BehandelaarId);
    }
}