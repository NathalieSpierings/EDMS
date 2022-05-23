using AutoFixture;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Validators;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Validators;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;

namespace Promeetec.EDMS.Domain.Tests.Medewerker.Validators;

[TestFixture]
public class UpdatePasswordValidatorTests : TestFixtureBase
{
    private UpdatePasswordValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator =  new UpdatePasswordValidator();
    }

    [Test]
    public void Should_have_validation_error_when_password_isEmpty()
    {
        var command = Fixture.Build<UpdatePassword>().With(x => x.Password, String.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

}