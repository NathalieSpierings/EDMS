using AutoFixture;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Validators;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Medewerker.Validators;

[TestFixture]
public class UpdateMedewerkerValidatorTests : TestFixtureBase
{
    private Mock<IDispatcher> _dispachter;
    private CreateOrganisatieValidator _validator;

    [SetUp]
    public void Setup()
    {
        _dispachter = new Mock<IDispatcher>();
        _validator = new CreateOrganisatieValidator(_dispachter.Object);
    }


    [Test]
    public void Should_have_validation_error_when_name_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Naam, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }

    [Test]
    public void Should_have_validation_error_when_name_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Naam, new string('*', 201)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }



    [Test]
    public void Should_have_validation_error_when_agbcodeonderneming_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.AgbCodeOnderneming, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.AgbCodeOnderneming);
    }

    [Test]
    public void Should_have_validation_error_when_agbcodeonderneming_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.AgbCodeOnderneming, new string('*', 201)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.AgbCodeOnderneming);
    }


    [Test]
    public void Should_have_validation_error_when_telefoonzakelijk_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonZakelijk, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonZakelijk);
    }

    [Test]
    public void Should_have_validation_error_when_telefoonzakelijk_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonZakelijk, new string('*', 16)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonZakelijk);
    }


    [Test]
    public void Should_have_validation_error_when_telefoonprive_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonPrive, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonPrive);
    }

    [Test]
    public void Should_have_validation_error_when_telefoonprive_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonPrive, new string('*', 16)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonPrive);
    }




    [Test]
    public void Should_have_validation_error_when_email_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Email, new string('*', 451)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Test]
    public void Should_have_validation_error_when_email_is_not_valid()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Email, "email").Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }


    [Test]
    public void Should_have_validation_error_when_website_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Website, new string('*', 257)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Website);
    }

    [Test]
    public void Should_have_validation_error_when_website_is_not_valid()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Website, "test.nl").Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Website);
    }


    [Test]
    public void Should_have_validation_error_when_contactpersoon_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.ContactpersoonId, Guid.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.ContactpersoonId);
    }
}