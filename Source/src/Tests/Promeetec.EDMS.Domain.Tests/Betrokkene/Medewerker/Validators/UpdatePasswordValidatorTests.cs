﻿using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Validators;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Medewerker.Validators;

[TestFixture]
public class UpdatePasswordValidatorTests : TestFixtureBase
{
    private UpdatePasswordValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new UpdatePasswordValidator();
    }

    [Test]
    public void Should_have_validation_error_when_password_is_empty()
    {
        var command = Fixture.Build<UpdatePassword>().With(x => x.Password, String.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

}