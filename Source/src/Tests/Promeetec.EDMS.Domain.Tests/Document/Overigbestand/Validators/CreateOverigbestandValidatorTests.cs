using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Overigbestand.Validators;
using Promeetec.EDMS.Domain.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Document.Overigbestand.Validators;

[TestFixture]
public class CreateOverigbestandValidatorTests : TestFixtureBase
{
	private CreateOverigbestandValidator _validator;

	[SetUp]
	public void Setup()
	{
		_validator = new CreateOverigbestandValidator();
	}

	[Test]
	public void Should_have_validation_error_when_filename_is_empty()
	{
		var command = Fixture.Build<CreateOverigBestand>().With(x => x.FileName, string.Empty).Create();
		var result = _validator.TestValidate(command);
		result.ShouldHaveValidationErrorFor(x => x.FileName);
	}

	[Test]
	public void Should_have_validation_error_when_filename_is_too_long()
	{
		var command = Fixture.Build<CreateOverigBestand>().With(x => x.FileName, new string('*', 455)).Create();
		var result = _validator.TestValidate(command);
		result.ShouldHaveValidationErrorFor(x => x.FileName);
	}

	[Test]
	public void Should_have_validation_error_when_eigenaar_is_empty()
	{
		var command = Fixture.Build<CreateOverigBestand>().With(x => x.EigenaarId, Guid.Empty).Create();
		var result = _validator.TestValidate(command);
		result.ShouldHaveValidationErrorFor(x => x.FileName);
	}
}