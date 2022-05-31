using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Validators;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Verzekerde.Validators;

[TestFixture]
public class UpdateVerzekerdeValidatorTests : TestFixtureBase
{
    private UpdateMedewerkerValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new UpdateMedewerkerValidator();
    }



    [Test]
    public void Should_have_validation_error_when_geslacht_is_empty()
    {
        var command = Fixture.Build<UpdateMedewerker>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Email)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .Without(x => x.TelefoonPrive)
                .Without(x => x.TelefoonZakelijk)
                .Without(x => x.Email)
                .With(x => x.Geslacht, (Geslacht)(-1))
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Geslacht);
    }


    [Test]
    public void Should_have_validation_error_when_voorletters_is_empty()
    {
        var command = Fixture.Build<UpdateMedewerker>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Email)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .Without(x => x.TelefoonPrive)
                .Without(x => x.TelefoonZakelijk)
                .Without(x => x.Email)
                .With(x => x.Voorletters, String.Empty)
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Voorletters);
    }

    [Test]
    public void Should_have_validation_error_when_voorletters_is_too_long()
    {
        var command = Fixture.Build<UpdateMedewerker>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Email)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .Without(x => x.TelefoonPrive)
                .Without(x => x.TelefoonZakelijk)
                .Without(x => x.Email)
                .With(x => x.Voorletters, new string('*', 22))
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Voorletters);
    }


    [Test]
    public void Should_have_validation_error_when_tussenvoegsel_is_too_long()
    {
        var command = Fixture.Build<UpdateMedewerker>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Email)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .Without(x => x.TelefoonPrive)
                .Without(x => x.TelefoonZakelijk)
                .Without(x => x.Email)
                .With(x => x.Tussenvoegsel, new string('*', 22))
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Tussenvoegsel);
    }


    [Test]
    public void Should_have_validation_error_when_achternaam_is_empty()
    {
        var command = Fixture.Build<UpdateMedewerker>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Email)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .Without(x => x.TelefoonPrive)
                .Without(x => x.TelefoonZakelijk)
                .Without(x => x.Email)
                .With(x => x.Achternaam, String.Empty)
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Achternaam);
    }

    [Test]
    public void Should_have_validation_error_when_achternaam_is_too_long()
    {
        var command = Fixture.Build<UpdateMedewerker>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Email)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .Without(x => x.TelefoonPrive)
                .Without(x => x.TelefoonZakelijk)
                .Without(x => x.Email)
                .With(x => x.Achternaam, new string('*', 22))
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Achternaam);
    }

    [Test]
    public void Should_have_validation_error_when_telefoon_zakelijk_is_too_long()
    {
        var command = Fixture.Build<UpdateMedewerker>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Email)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .Without(x => x.TelefoonPrive)
                .Without(x => x.Email)
                .With(x => x.TelefoonZakelijk, new string('*', 22))
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.TelefoonZakelijk);
    }

    [Test]
    public void Should_have_validation_error_when_telefoon_zakelijk__is_not_valid()
    {
        var command = Fixture.Build<UpdateMedewerker>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Email)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .Without(x => x.TelefoonPrive)
                .Without(x => x.Email)
                .With(x => x.TelefoonZakelijk, new string('*', 22))
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.TelefoonZakelijk);
    }


    [Test]
    public void Should_have_validation_error_when_telefoon_prive_is_too_long()
    {
        var command = Fixture.Build<UpdateMedewerker>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Email)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .Without(x => x.TelefoonZakelijk)
                .Without(x => x.Email)
                .With(x => x.TelefoonPrive, new string('*', 16))
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.TelefoonPrive);
    }

    [Test]
    public void Should_have_validation_error_when_telefoon_prive__is_not_valid()
    {
        var command = Fixture.Build<UpdateMedewerker>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Email)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .Without(x => x.TelefoonZakelijk)
                .Without(x => x.Email)
                .With(x => x.TelefoonPrive, new string('*', 22))
                .Create())
            .Create();

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.TelefoonPrive);
    }

    [Test]
    public void Should_have_validation_error_when_email_is_too_long()
    {
        var command = Fixture.Build<UpdateMedewerker>().Without(x => x.Adres).With(x => x.Email, new string('*', 460)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Test]
    public void Should_have_validation_error_when_email_is_not_valid()
    {
        var command = Fixture.Build<UpdateMedewerker>().Without(x => x.Adres).With(x => x.Email, "email").Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }


    [Test]
    public void Should_have_validation_error_when_agbcode_onderneming_is_empty()
    {
        var command = Fixture.Build<UpdateMedewerker>().Without(x => x.Adres).With(x => x.AgbCodeOnderneming, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.AgbCodeOnderneming);
    }

    [Test]
    public void Should_have_validation_error_when_functie_is_too_long()
    {
        var command = Fixture.Build<UpdateMedewerker>().Without(x => x.Adres).With(x => x.Functie, new string('*', 201)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Functie);
    }
}