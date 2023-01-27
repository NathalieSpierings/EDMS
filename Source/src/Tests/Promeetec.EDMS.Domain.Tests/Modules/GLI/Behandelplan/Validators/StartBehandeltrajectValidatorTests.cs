using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Validators;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Modules.GLI.Behandelplan.Validators;

[TestFixture]
public class StartBehandeltrajectTests : TestFixtureBase
{
    private StartBehandeltrajectValidator _validator;


    [SetUp]
    public void Setup()
    {
        _validator = new StartBehandeltrajectValidator();
    }

    [Test]
    public async Task Should_have_validation_error_when_startdatum_is_empty()
    {
        var command = Fixture.Build<StartBehandeltraject>().With(x => x.Startdatum, DateTime.MinValue).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Startdatum);
    }
    
    [Test]
    public async Task Should_have_validation_error_when_startdatum_is_before_intakedatum()
    {
        var command = Fixture.Build<StartBehandeltraject>()
            .With(x => x.Intakedatum, DateTime.Now.AddDays(-2))
            .With(x => x.Startdatum, DateTime.Now.AddDays(-1))
            .Create();
       
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Startdatum);
    }


    [Test]
    public void Should_have_validation_error_when_startdatum_is_not_valid()
    {
        var command = Fixture.Build<StartBehandeltraject>().With(x => x.Startdatum, new DateTime(75, 7, 22)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Startdatum);
    }


    [Test]
    public async Task Should_have_validation_error_when_programma_is_empty()
    {
        var command = Fixture.Build<StartBehandeltraject>().With(x => x.Programma, (GliProgramma)(-1)).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Programma);
    }

    [Test]
    public async Task Should_have_validation_error_when_verzekerde_is_empty()
    {
        var command = Fixture.Build<StartBehandeltraject>().With(x => x.VerzekerdeId, Guid.Empty).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.VerzekerdeId);
    }

    [Test]
    public async Task Should_have_validation_error_when_behandelaar_is_empty()
    {
        var command = Fixture.Build<StartBehandeltraject>().With(x => x.BehandelaarId, Guid.Empty).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.BehandelaarId);
    }
}