using AutoFixture;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Validators;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Validators.Rules;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Organisatie.Validators;

[TestFixture]
public class CreateOrganisatieValidatorTests : TestFixtureBase
{
    private Mock<IDispatcher> _dispachter;
    private CreateOrganisatieValidator _validator;

    [SetUp]
    public void Setup()
    {
        _dispachter = new Mock<IDispatcher>();
        _validator =  new CreateOrganisatieValidator(_dispachter.Object);
    }


    [Test]
    public void ShouldHaveValidationErrorWhenNummerIsEmpty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Nummer, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Nummer);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenNummerIsTooLong()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Nummer, new string('*', 21)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Nummer);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenNumberIsNotUnque()
    {
        var command = Fixture.Create<CreateOrganisatie>();
        _dispachter.Setup(x => x.Get(new IsOrganisatieNummerUnique { Nummer = command.Nummer, Id = command.Id })).ReturnsAsync(false);

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Nummer);
    }


    [Test]
    public void ShouldHaveValidationErrorWhenNameIsEmpty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Naam, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenNameIsTooLong()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Naam, new string('*', 201)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Naam);
    }



    [Test]
    public void ShouldHaveValidationErrorWhenAgbCodeOndernemingIsEmpty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.AgbCodeOnderneming, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.AgbCodeOnderneming);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenAgbCodeOndernemingIsTooLong()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.AgbCodeOnderneming, new string('*', 201)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.AgbCodeOnderneming);
    }


    [Test]
    public void ShouldHaveValidationErrorWhenTelefoonZakelijkIsEmpty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonZakelijk, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonZakelijk);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenTelefoonZakelijkIsTooLong()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonZakelijk, new string('*', 16)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonZakelijk);
    }


    [Test]
    public void ShouldHaveValidationErrorWhenTelefoonPriveIsEmpty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonPrive, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonPrive);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenTelefoonPriveIsTooLong()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.TelefoonPrive, new string('*', 16)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.TelefoonPrive);
    }


   

    [Test]
    public void ShouldHaveValidationErrorWhenEmailIsTooLong()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Email, new string('*', 451)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenEmailIsNotValid()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Email, "email").Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }


    [Test]
    public void ShouldHaveValidationErrorWhenWebsiteIsTooLong()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Website, new string('*', 257)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Website);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenWebsiteIsNotValid()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Website, "test.nl").Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Website);
    }


    [Test]
    public void ShouldHaveValidationErrorWhenContactpersoonIsEmpty()
    {
        var command = Fixture.Build<CreateOrganisatie>().With(x => x.ContactpersoonId, Guid.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.ContactpersoonId);
    }
}