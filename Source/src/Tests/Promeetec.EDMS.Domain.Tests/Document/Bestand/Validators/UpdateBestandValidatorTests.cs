using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Document.Bestand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Bestand.Validators;

namespace Promeetec.EDMS.Domain.Tests.Document.Bestand.Validators;

[TestFixture]
public class UpdateBestandValidatorTests : TestFixtureBase
{
	private UpdateBestandValidator _validator;

	[SetUp]
	public void Setup()
	{
		_validator = new UpdateBestandValidator();
	}

	[Test]
	public void Should_have_validation_error_when_filename_is_empty()
	{
		var command = Fixture.Build<UpdateBestand>().With(x => x.FileName, string.Empty).Create();
		var result = _validator.TestValidate(command);
		result.ShouldHaveValidationErrorFor(x => x.FileName);
	}

	[Test]
	public void Should_have_validation_error_when_filename_is_too_long()
	{
		var command = Fixture.Build<UpdateBestand>().With(x => x.FileName, new string('*', 455)).Create();
		var result = _validator.TestValidate(command);
		result.ShouldHaveValidationErrorFor(x => x.FileName);
	}
}