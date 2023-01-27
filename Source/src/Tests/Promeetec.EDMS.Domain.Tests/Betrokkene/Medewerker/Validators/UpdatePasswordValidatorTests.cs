using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Validators;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Betrokkene.Medewerker.Validators;

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