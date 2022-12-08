﻿using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands;
using Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Validators;

namespace Promeetec.EDMS.Domain.Tests.Document.Aanleverbestand.Validators;

[TestFixture]
public class UpdateAanleverbestandValidatorTests : TestFixtureBase
{
	private UpdateAanleverbestandValidator _validator;

	[SetUp]
	public void Setup()
	{
		_validator = new UpdateAanleverbestandValidator();
	}


	[Test]
	public void Should_have_validation_error_when_eigenaar_is_empty()
	{
		var command = Fixture.Build<UpdateAanleverbestand>().With(x => x.EigenaarId, Guid.Empty).Create();
		var result = _validator.TestValidate(command);
		result.ShouldHaveValidationErrorFor(x => x.EigenaarId);
	}
}