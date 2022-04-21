using AutoFixture;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie.Rules;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Organisatie.Validators;

namespace Promeetec.EDMS.Tests.Domain.Organisatie;

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

        var command = Fixture.Build<CreateOrganisatie>().With(x => x.Naam, new string('*', 51)).Create();

        var sut = new CreateOrganisatieValidator(dispatcher.Object);

        sut.ShouldHaveValidationErrorFor(x => x.Naam, command);
    }

    [Test]
    public void ShouldHaveValidationErrorWhenNameIsNotUnque()
    {
        var command = Fixture.Create<CreateOrganisatie>();

        var dispatcher = new Mock<IDispatcher>();
        dispatcher.Setup(x => x.Get(new IsNameUnique { Naam = command.Naam, Id = command.Id })).ReturnsAsync(false);


        var sut = new CreateOrganisatieValidator(dispatcher.Object);

        sut.ShouldHaveValidationErrorFor(x => x.Naam, command);
    }
}