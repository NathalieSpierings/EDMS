using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Changelog.Commands;
using Promeetec.EDMS.Domain.Models.Changelog.Validators;

namespace Promeetec.EDMS.Domain.Tests.Changelog.Validators;

[TestFixture]
public class CreateChangelogValidatorTests : TestFixtureBase
{
    private CreateChangelogPostValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateChangelogPostValidator();
    }


    [Test]
    public void Should_have_validation_error_when_title_is_empty()
    {
        var command = Fixture.Build<CreateChangelogPost>().With(x => x.Title, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Test]
    public void Should_have_validation_error_when_title_is_too_long()
    {
        var command = Fixture.Build<CreateChangelogPost>().With(x => x.Title, new string('*', 222)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Test]
    public void Should_have_validation_error_when_description_is_empty()
    {
        var command = Fixture.Build<CreateChangelogPost>().With(x => x.Description, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Test]
    public void Should_have_validation_error_when_description_is_too_long()
    {
        var command = Fixture.Build<CreateChangelogPost>().With(x => x.Description, new string('*', 460)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Test]
    public void Should_have_validation_error_when_content_is_empty()
    {
        var command = Fixture.Build<CreateChangelogPost>().With(x => x.Content, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Content);
    }
}