﻿using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Validators;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Document.Bestand.Validators;

[TestFixture]
public class CreateBestandValidatorTests : TestFixtureBase
{
    private CreateBestandValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateBestandValidator();
    }


    [Test]
    public void Should_have_validation_error_when_filename_is_empty()
    {
        var command = Fixture.Build<CreateBestand>().With(x => x.FileName, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.FileName);
    }

    [Test]
    public void Should_have_validation_error_when_filename_is_too_long()
    {
        var command = Fixture.Build<CreateBestand>().With(x => x.FileName, new string('*', 455)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.FileName);
    }
}