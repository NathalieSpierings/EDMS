﻿using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Validators;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Identity.Group.Validators;

[TestFixture]
public class UpdateGroupValidatorTests : TestFixtureBase
{
    private UpdateGroupValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new UpdateGroupValidator();
    }


    [Test]
    public void Should_have_validation_error_when_name_is_empty()
    {
        var command = Fixture.Build<UpdateGroup>().With(x => x.Name, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public void Should_have_validation_error_when_name_is_too_long()
    {
        var command = Fixture.Build<UpdateGroup>().With(x => x.Name, new string('*', 251)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Test]
    public void Should_have_validation_error_when_description_is_empty()
    {
        var command = Fixture.Build<UpdateGroup>().With(x => x.Description, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }

    [Test]
    public void Should_have_validation_error_when_description_is_too_long()
    {
        var command = Fixture.Build<UpdateGroup>().With(x => x.Description, new string('*', 2000)).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
}