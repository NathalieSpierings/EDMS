﻿using AutoFixture;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Core;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Adres;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Validators;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Zorgverzekering;
using Promeetec.EDMS.Portaal.Tests.Helpers;

namespace Promeetec.EDMS.Portaal.Domain.Tests.Betrokkene.Verzekerde.Validators;

[TestFixture]
public class CreateVerzekerdeValidatorTests : TestFixtureBase
{
    private Mock<IDispatcher> _dispachter;
    private CreateVerzekerdeValidator _validator;

    [SetUp]
    public void Setup()
    {
        _dispachter = new Mock<IDispatcher>();
        _validator = new CreateVerzekerdeValidator(_dispachter.Object);
    }

    [Test]
    public async Task Should_have_validation_error_when_geslacht_is_empty()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .With(x => x.Geslacht, (Geslacht)(-1))
                .Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Geslacht);
    }


    [Test]
    public async Task Should_have_validation_error_when_voorletters_is_empty()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .With(x => x.Voorletters, String.Empty)
                .Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Voorletters);
    }

    [Test]
    public async Task Should_have_validation_error_when_voorletters_is_too_long()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
               .With(x => x.Voorletters, new string('*', 22))
                .Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Voorletters);
    }

    [Test]
    public async Task Should_have_validation_error_when_tussenvoegsel_is_too_long()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .With(x => x.Tussenvoegsel, new string('*', 22))
                .Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Tussenvoegsel);
    }


    [Test]
    public async Task Should_have_validation_error_when_achternaam_is_empty()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                 .Without(x => x.TelefoonPrive)
                .Without(x => x.TelefoonZakelijk)
                .Without(x => x.Email)
                .With(x => x.Achternaam, String.Empty)
                .Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Achternaam);
    }

    [Test]
    public async Task Should_have_validation_error_when_achternaam_is_too_long()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                 .Without(x => x.TelefoonPrive)
                .Without(x => x.TelefoonZakelijk)
                .Without(x => x.Email)
                .With(x => x.Achternaam, new string('*', 22))
                .Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Achternaam);
    }

    [Test]
    public async Task Should_have_validation_error_when_geboortedatum_is_empty()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .With(x => x.Geboortedatum, DateTime.MinValue)
                .Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Geboortedatum);
    }

    [Test]
    public async Task Should_have_validation_error_when_geboortedatum_is_in_feature()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Persoon, Fixture.Build<Persoon>()
                .With(x => x.Geboortedatum, DateTime.Now.AddDays(1))
                .Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Persoon.Geboortedatum);
    }

    [Test]
    public async Task Should_have_validation_error_when_bsn_is_empty()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Bsn, string.Empty)
            .With(x => x.Persoon, Fixture.Build<Persoon>().Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Bsn);
    }

    [Test]
    public async Task Should_have_validation_error_when_bsn_is_not_valid()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Bsn, new string('*', 12))
            .With(x => x.Persoon, Fixture.Build<Persoon>().Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Bsn);
    }

    [Test]
    public async Task Should_have_validation_error_when_bsn_is_not_unique()
    {
        var cmd = Fixture.Build<CreateVerzekerde>()
            .With(x => x.Bsn, "432127331")
            .Without(x => x.Adres)
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .Without(x => x.Zorgprofiel)
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var command = Fixture.Build<CreateVerzekerde>()
            .With(x => x.Id, cmd.Id)
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Bsn, "432127331")
            .With(x => x.Persoon, Fixture.Build<Persoon>().Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .Without(x => x.Land)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .With(x => x.Id, Guid.NewGuid())
                    .Create())
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Bsn);
    }

    //[Test]
    //public async Task Should_have_Validation_error_when_landid_is_empty()
    //{
    //    var command = Fixture.Build<CreateVerzekerde>()
    //        .Without(x => x.Zorgprofiel)
    //        .Without(x => x.Zorgverzekering)
    //        .With(x => x.Bsn, "054243579")
    //        .Without(x => x.Adres)
    //        .With(x => x.Adres, Fixture.Build<Adres>()
    //            .Without(x => x.Verzekerden)
    //            .Without(x => x.Land)
    //            .With(x => x.LandId, Guid.Empty)
    //            .Create())
    //        .Create();

    // var result = await _validator.TestValidateAsync(command);
    //    result.ShouldHaveValidationErrorFor(x => x.Adres.LandId);
    //}

    [Test]
    public async Task Should_have_Validation_error_when_verzekeraarid_is_empty()
    {
        var command = Fixture.Build<CreateVerzekerde>()
            .Without(x => x.Persoon)
            .Without(x => x.Adres)
            .Without(x => x.Zorgprofiel)
            .Without(x => x.Zorgverzekering)
            .With(x => x.Bsn, "054243579")
            .With(x => x.Persoon, Fixture.Build<Persoon>().Create())
            .With(x => x.Adres, Fixture.Build<Adres>()
                .Without(x => x.Verzekerden)
                .With(x => x.LandId, Guid.NewGuid())
                .Create())
            .With(x => x.Zorgverzekering, Fixture.Build<Zorgverzekering>()
                .Without(x => x.Verzekerden)
                .With(x => x.Verzekeraar, Fixture.Build<Models.Betrokkene.Verzekeraar.Verzekeraar>()
                    .Create())
                .With(x => x.VerzekeraarId, Guid.Empty)
                .Create())
            .Create();

        var result = await _validator.TestValidateAsync(command);
        result.ShouldHaveValidationErrorFor(x => x.Zorgverzekering.VerzekeraarId);
    }
}