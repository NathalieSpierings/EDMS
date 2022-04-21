using AutoFixture;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Rules;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Validators;

namespace Promeetec.EDMS.Domain.Tests.Organisatie;

[TestFixture]
public class CreateOrganisatieValidatorTests : TestFixtureBase
{
    [Test]
    public void ShouldHaveValidationErrorWhenNameIsEmpty()
    {
        var dispatcher = new Mock<IDispatcher>();


        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Naam, string.Empty).Create();

        var sut = new CreateOrganisatieValidator(dispatcher.Object);

        sut.ShouldHaveValidationErrorFor(x => x.Naam, command);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenNameIsTooLong()
    {
        var dispatcher = new Mock<IDispatcher>();

        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Naam, new string('*', 201)).Create();

        var sut = new CreateOrganisatieValidator(dispatcher.Object);

        sut.ShouldHaveValidationErrorFor(x => x.Naam, command);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenNumberIsNotUnque()
    {
        var command = Fixture.Create<CreateOrganisatie>();

        var dispatcher = new Mock<IDispatcher>();
        dispatcher.Setup(x => x.Get(new IsOrganisatieNummerUnique { Nummer = command.Nummer, Id = command.CreateOrganisatieId })).ReturnsAsync(false);


        var sut = new CreateOrganisatieValidator(dispatcher.Object);

        sut.ShouldHaveValidationErrorFor(x => x.Naam, command);
    }
}