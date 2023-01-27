using AutoFixture;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Core;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Validators;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Validators.Rules;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Menu.Menu.Validators;

[TestFixture]
public class CreateMenuValidatorTests : TestFixtureBase
{
    private Mock<IDispatcher> _dispachter;
    private CreateMenuValidator _validator;

    [SetUp]
    public void Setup()
    {
        _dispachter = new Mock<IDispatcher>();
        _validator = new CreateMenuValidator(_dispachter.Object);
    }


    [Test]
    public async Task Should_have_validation_error_when_id_is_empty()
    {
        var command = Fixture.Build<CreateMenu>().With(x => x.Id, Guid.Empty).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Id);
    }

    [Test]
    public async Task Should_have_Validation_error_when_id_is_not_unique()
    {
        var command = Fixture.Create<CreateMenu>();
        _dispachter.Setup(x => x.Get(new IsMenuIdUnique { Id = command.Id })).ReturnsAsync(false);

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Id);
    }

    [Test]
    public async Task Should_have_validation_error_when_name_is_not_unique()
    {
        var command = Fixture.Create<CreateMenu>();
        _dispachter.Setup(x => x.Get(new IsMenuNameUnique { Name = command.Name })).ReturnsAsync(false);

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public async Task Should_have_validation_error_when_name_is_not_valid()
    {
        var command = Fixture.Build<CreateMenu>().With(x => x.Name, "*Alpha@$#5").Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public async Task Should_have_validation_error_when_name_is_empty()
    {
        var command = Fixture.Build<CreateMenu>().With(x => x.Name, string.Empty).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public async Task Should_have_validation_error_when_name_is_too_long()
    {
        var command = Fixture.Build<CreateMenu>().With(x => x.Name, new string('*', 251)).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public async Task Should_have_validation_error_when_menu_type_is_empty()
    {
        var command = Fixture.Build<CreateMenu>().With(x => x.MenuType, (MenuType)(-1)).Create();
        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.MenuType);
    }
}