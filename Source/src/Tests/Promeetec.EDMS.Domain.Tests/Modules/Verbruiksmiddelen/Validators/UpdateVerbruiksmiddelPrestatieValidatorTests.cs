using System.Text.RegularExpressions;
using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Validators;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Verbruiksmiddelen.Validators;

[TestFixture]
public class UpdateVerbruiksmiddelPrestatieValidatorTests : TestFixtureBase
{
    private UpdateVerbruiksmiddelPrestatieValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new UpdateVerbruiksmiddelPrestatieValidator();
    }


    [Test]
    public void Should_match_regex()
    {
        var regex = new Regex("^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)\\d\\d$");

        Assert.IsTrue(regex.IsMatch("22-07-1975"));
        Assert.IsFalse(regex.IsMatch("22-7-0075"));
    }
    
    [Test]
    public void Should_have_validation_error_when_zindex_is_empty()
    {
        var command = Fixture.Build<UpdateVerbruiksmiddelPrestatie>().With(x => x.ZIndex, (int?)(null)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.ZIndex);
    }

    [Test]
    public void Should_have_validation_error_when_zindex_is_less_than_zero()
    {
        var command = Fixture.Build<UpdateVerbruiksmiddelPrestatie>().With(x => x.ZIndex, 0).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.ZIndex);
    }


    [Test]
    public void Should_have_validation_error_when_prestatie_datum_is_empty()
    {
        var command = Fixture.Build<UpdateVerbruiksmiddelPrestatie>().With(x => x.PrestatieDatum, (DateTime?)null).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.PrestatieDatum);
    }

    [Test]
    public void Should_have_validation_error_when_prestatie_datum_is_invalid()
    {
        var command = Fixture.Build<UpdateVerbruiksmiddelPrestatie>().With(x => x.PrestatieDatum, new DateTime(75, 7, 22)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.PrestatieDatum);
    }



    [Test]
    public void Should_have_validation_error_when_hoeveelheid_is_empty()
    {
        var command = Fixture.Build<UpdateVerbruiksmiddelPrestatie>().With(x => x.Hoeveelheid, (int?)(null)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Hoeveelheid);
    }

    [Test]
    public void Should_have_validation_error_when_hoeveelheid_is_less_than_zero()
    {
        var command = Fixture.Build<UpdateVerbruiksmiddelPrestatie>().With(x => x.Hoeveelheid, 0).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Hoeveelheid);
    }
}