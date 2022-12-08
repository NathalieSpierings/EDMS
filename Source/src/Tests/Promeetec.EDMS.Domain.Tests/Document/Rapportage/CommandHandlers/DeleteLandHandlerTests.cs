﻿using System.Data;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Handlers;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Tests.Betrokkene.Land.CommandHandlers;


[TestFixture]
public class DeleteLandHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private ILandRepository _repository;
    private IEventRepository _eventRepository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new LandRepository(_context);
        _eventRepository = new EventRepository(_context);
    }


    [Test]
    public void Should_throw_data_exception_when_organisatie_not_found()
    {
        var sut = new DeleteLandHandler(_repository, _eventRepository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<DeleteLand>()));
    }

    [Test]
    public async Task Should_delete_country_and_add_event()
    {
        var cmd = new CreateLand
        {
            UserId = Guid.NewGuid(),
            UserDisplayName = "Ad de Admin",

            Id = Guid.NewGuid(),
            OrganisatieId = PromeetecId,

            CultureCode = "nl-NL",
            NativeName = "Nederland"
        };

        var country = new Models.Betrokkene.Land.Land(cmd);
        _context.Landen.Add(country);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<DeleteLand>()
            .With(x => x.Id, country.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .Create();

        var sut = new DeleteLandHandler(_repository, _eventRepository);
        await sut.Handle(command);

        var dbEntity = await _context.Landen.FirstOrDefaultAsync(x => x.Id == command.Id);
        var @event = await _context.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        Assert.AreEqual(Status.Verwijderd, dbEntity.Status);
        Assert.NotNull(@event);
    }
}