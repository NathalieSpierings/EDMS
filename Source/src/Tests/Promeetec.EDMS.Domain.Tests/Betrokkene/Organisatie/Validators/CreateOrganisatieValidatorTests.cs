using AutoFixture;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Core;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Validators;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Validators.Rules;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Betrokkene.Organisatie.Validators;

[TestFixture]
public class CreateOrganisatieValidatorTests : TestFixtureBase
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
    public async Task Should_have_Validation_error_when_nummer_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Nummer, string.Empty).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Nummer);
    }

    [Test]
    public async Task Should_have_Validation_error_when_nummer_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Nummer, new string('*', 21)).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Nummer);
    }

    [Test]
    public async Task Should_have_Validation_error_when_nummer_is_not_unique()
    {
        var command = Fixture.Create<CreateOrganisatie>();
        _dispachter.Setup(x => x.Get(new IsOrganisatieNummerUnique { Nummer = command.Nummer, Id = command.Id })).ReturnsAsync(false);

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Nummer);
    }

    [Test]
    public async Task Should_have_Validation_error_when_name_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Naam, string.Empty).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }

    [Test]
    public async Task Should_have_Validation_error_when_name_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Naam, new string('*', 201)).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }

    [Test]
    public async Task Should_have_Validation_error_when_agbcodeonderneming_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.AgbCodeOnderneming, string.Empty).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.AgbCodeOnderneming);
    }

    [Test]
    public async Task Should_have_Validation_error_when_telefoonzakelijk_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonZakelijk, string.Empty).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonZakelijk);
    }

    [Test]
    public async Task Should_have_Validation_error_when_telefoonzakelijk_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonZakelijk, new string('*', 16)).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonZakelijk);
    }

    [Test]
    public async Task Should_have_Validation_error_when_telefoonprive_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonPrive, string.Empty).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonPrive);
    }

    [Test]
    public async Task Should_have_Validation_error_when_telefoonprive_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonPrive, new string('*', 16)).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonPrive);
    }

    [Test]
    public async Task Should_have_Validation_error_when_email_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Email, new string('*', 451)).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Test]
    public async Task Should_have_Validation_error_when_email_is_not_valid()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Email, "email").Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Test]
    public async Task Should_have_Validation_error_when_website_is_too_long()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Website, new string('*', 257)).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Website);
    }

    [Test]
    public async Task Should_have_Validation_error_when_website_is_not_valid()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Website, "test.nl").Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Website);
    }

    [Test]
    public async Task Should_have_Validation_error_when_contactpersoon_is_empty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.ContactpersoonId, Guid.Empty).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.ContactpersoonId);
    }
}