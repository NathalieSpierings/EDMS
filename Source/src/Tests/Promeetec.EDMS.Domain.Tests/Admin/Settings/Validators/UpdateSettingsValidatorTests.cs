using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Admin.Settings;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Commands;
using Promeetec.EDMS.Domain.Models.Admin.Settings.Validators;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.Settings.Validators;

[TestFixture]
public class UpdateSettingsValidatorTests : TestFixtureBase
{
    private UpdateSettingsValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new UpdateSettingsValidator();
    }

    [Test]
    public void Should_have_validation_error_when_straat_is_empty()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Straat, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Straat);
    }

    [Test]
    public void Should_have_validation_error_when_straat_is_too_long()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Straat, new string('*', 222)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Straat);
    }


    [Test]
    public void Should_have_validation_error_when_huisnummer_is_empty()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Huisnummer, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Huisnummer);
    }

    [Test]
    public void Should_have_validation_error_when_huisnummer_is_too_long()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Huisnummer, new string('*', 222)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Huisnummer);
    }


    [Test]
    public void Should_have_validation_error_when_huisnummertoevoeging_is_too_long()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Huisnummertoevoeging, new string('*', 222)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Huisnummertoevoeging);
    }

    [Test]
    public void Should_have_validation_error_when_postcode_is_empty()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Postcode, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Postcode);
    }

    [Test]
    public void Should_have_validation_error_when_postcode_is_too_long()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Postcode, new string('*', 55)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Postcode);
    }

    [Test]
    public void Should_have_validation_error_when_woonplaats_is_empty()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Woonplaats, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Woonplaats);
    }

    [Test]
    public void Should_have_validation_error_when_woonplaats_is_too_long()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Woonplaats, new string('*', 222)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Woonplaats);
    }

    [Test]
    public void Should_have_validation_error_when_telefoon_is_too_long()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Telefoon, new string('*', 18)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Telefoon);
    }

    [Test]
    public void Should_have_validation_error_when_email_is_too_long()
    {
        var command = Fixture.Build<UpdateSettings>().With(x => x.Email, new string('*', 460)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }


    [Test]
    public void Should_have_validation_error_when_bedrag_basis_verzekering_is_zero()
    {
        var command = Fixture.Build<UpdateSettings>()
            .Without(x => x.Haarwerk)
            .With(x => x.Haarwerk, Fixture.Build<SettingsHaarwerk>()
                .With(x => x.BedragBasisVerzekeringHaarwerk, new decimal(0.00))
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Haarwerk.BedragBasisVerzekeringHaarwerk);
    }

    [Test]
    public void Should_have_validation_error_when_bedrag_basis_verzekering_is_negative()
    {
        var command = Fixture.Build<UpdateSettings>()
            .Without(x => x.Haarwerk)
            .With(x => x.Haarwerk, Fixture.Build<SettingsHaarwerk>()
                .With(x => x.BedragBasisVerzekeringHaarwerk, new decimal(-25.50))
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Haarwerk.BedragBasisVerzekeringHaarwerk);
    }
}