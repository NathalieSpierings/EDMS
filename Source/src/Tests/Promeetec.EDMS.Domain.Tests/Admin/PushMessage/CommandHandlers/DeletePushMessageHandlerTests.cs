using System.Data;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Data.Repositories;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Handlers;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Tests.Helpers;

namespace Promeetec.EDMS.Domain.Tests.Admin.PushMessage.CommandHandlers;


[TestFixture]
public class DeletePushMessageHandlerTests : TestFixtureBase
{
    private EDMSDbContext _context;
    private IPushMessageRepository _repository;

    [SetUp]
    public void Setup()
    {
        _context = new EDMSDbContext(Shared.CreateContextOptions());
        _repository = new PushMessageRepository(_context);
    }


    [Test]
    public void Should_throw_data_exception_when_push_message_not_found()
    {
        var sut = new DeletePushMessageHandler(_repository);
        Assert.ThrowsAsync<DataException>(async () => await sut.Handle(Fixture.Create<DeletePushMessage>()));
    }

    [Test]
    public async Task Should_delete_push_message()
    {
        var cmd = Fixture.Build<CreatePushMessage>()
            .Without(x => x.Groups)
            .With(x => x.Groups, Fixture.Build<Group>()
                .CreateMany().ToList())
            .Create();

        var msg = new Models.Admin.PushMessage.PushMessage(cmd);
        _context.PushMessages.Add(msg);
        await _context.SaveChangesAsync();


        var command = Fixture.Build<DeletePushMessage>()
            .With(x => x.Id, msg.Id)
            .With(x => x.OrganisatieId, PromeetecId)
            .With(x => x.UserId, Guid.NewGuid())
            .With(x => x.UserDisplayName, "Ad de Admin")
            .Create();

        var sut = new DeletePushMessageHandler(_repository);
        await sut.Handle(command);

        var dbEntity = await _context.Landen.FirstOrDefaultAsync(x => x.Id == command.Id);

        Assert.NotNull(dbEntity);
        Assert.AreEqual(Status.Verwijderd, dbEntity?.Status);
    }
}