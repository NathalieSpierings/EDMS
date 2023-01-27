using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Memo.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Memo.Validators;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Betrokkene.Memo.Validators;

[TestFixture]
public class CreateMemoValidatorTests : TestFixtureBase
{
    private CreateMemoValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new CreateMemoValidator();
    }


    [Test]
    public void Should_have_validation_error_when_content_is_empty()
    {
        var command = Fixture.Build<CreateMemo>().With(x => x.Content, string.Empty).Create();
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Content);
    }

}