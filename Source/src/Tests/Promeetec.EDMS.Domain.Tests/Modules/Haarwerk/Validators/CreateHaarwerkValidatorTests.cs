using System.Text.RegularExpressions;
using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Haarwerk.Validators;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Modules.Haarwerk.Validators;

[TestFixture]
public class CreateHaarwerkValidatorTests : TestFixtureBase
{
    private CreateHaarwerkValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateHaarwerkValidator();
    }

    [Test]
    public void Should_match_valid_date_regex()
    {
        var regex = new Regex("^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)\\d\\d$");

        Assert.IsTrue(regex.IsMatch("22-07-1975"));
        Assert.IsFalse(regex.IsMatch("22-7-0075"));
    }

    [Test]
    public void Should_match_regex()
    {
        var regex = new Regex("^(([1-9]{1}|[\\d]{2,})((\\.|,)[\\d]+)?)$|^(1\\.[\\d]+)$");

        Assert.IsTrue(regex.IsMatch("25.89"));
        Assert.IsTrue(regex.IsMatch("25,89"));
        Assert.IsFalse(regex.IsMatch("0.00"));
        Assert.IsFalse(regex.IsMatch("0,00"));
        Assert.IsFalse(regex.IsMatch("-25,89"));
        Assert.IsFalse(regex.IsMatch("-25,89"));
    }

    [Test]
    public void Should_have_validation_error_when_naam_is_empty()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Naam, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }

    [Test]
    public void Should_have_validation_error_when_naam_is_invalid()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Naam, "@#909naa").Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }

    [Test]
    public void Should_have_validation_error_when_naam_is_too_long()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Naam, new string('*', 210)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }
    
    [Test]
    public void Should_have_validation_error_when_geboortedatum_is_empty()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Geboortedatum, DateTime.MinValue).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Geboortedatum);
    }

    [Test]
    public void Should_have_validation_error_when_geboortedatum_is_in_feature()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Geboortedatum, DateTime.Now.AddDays(2)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Geboortedatum);
    }

    [Test]
    public void Should_have_validation_error_when_geboortedatum_is_invalid()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Geboortedatum, new DateTime(75, 7, 22)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Geboortedatum);
    }


    [Test]
    public void Should_have_validation_error_when_bsn_is_empty()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Bsn, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Bsn);
    }

    [Test]
    public void Should_have_validation_error_when_bsn_is_invalid()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Bsn, "0354205023").Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Bsn);
    }

    [Test]
    public void Should_have_validation_error_when_afleverdatum_is_empty()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Afleverdatum, DateTime.MinValue).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Afleverdatum);
    }

    [Test]
    public void Should_have_validation_error_when_afleverdatum_is_in_feature()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Afleverdatum, DateTime.Now.AddDays(2)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Afleverdatum);
    }

    [Test]
    public void Should_have_validation_error_when_afleverdatum_is_invalid()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.Afleverdatum, new DateTime(75, 7, 22)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Afleverdatum);
    }
    
    [Test]
    public void Should_have_validation_error_when_prijs_haarwerk_is_zero()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.PrijsHaarwerk, new decimal(0.00)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.PrijsHaarwerk);
    }

    [Test]
    public void Should_have_validation_error_when_prijs_haarwerk_is_negative()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.PrijsHaarwerk, new decimal(-25.50)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.PrijsHaarwerk);
    }

    [Test]
    public void Should_have_validation_error_when_bedrag_aanvullende_verzekering_is_zero()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.BedragAanvullendeVerzekering, new decimal(0.00)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.BedragAanvullendeVerzekering);
    }

    [Test]
    public void Should_have_validation_error_when_bedrag_aanvullende_verzekering_is_negative()
    {
        var command = Fixture.Build<CreateHaarwerk>().With(x => x.BedragAanvullendeVerzekering, new decimal(-25.50)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.BedragAanvullendeVerzekering);
    }
}