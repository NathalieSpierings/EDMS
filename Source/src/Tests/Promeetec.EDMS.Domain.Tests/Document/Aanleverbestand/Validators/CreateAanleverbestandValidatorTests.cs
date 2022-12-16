using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Validators;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Document.Aanleverbestand.Validators;

[TestFixture]
public class CreateAanleverbestandValidatorTests : TestFixtureBase
{
	private CreateAanleverbestandValidator _validator;

	[SetUp]
	public void Setup()
	{
		_validator = new CreateAanleverbestandValidator();
	}

	[Test]
	public void Should_have_validation_error_when_eigenaar_is_empty()
	{
		var command = Fixture.Build<CreateAanleverbestand>().With(x => x.EigenaarId, Guid.Empty).Create();
		var result = _validator.TestValidate(command);
		result.ShouldHaveValidationErrorFor(x => x.EigenaarId);
	}
}