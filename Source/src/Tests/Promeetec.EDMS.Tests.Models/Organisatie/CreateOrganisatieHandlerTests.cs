using NUnit.Framework;

namespace Promeetec.EDMS.Tests.Domain.Organisatie;


[TestFixture]
public class CreateOrganisatieHandlerTests : TestFixtureBase
{
    [Test]
    public async Task Should_create_new_user_and_add_event()
    {
        //using (var dbContext = new EDMSDbContext(Shared.CreateContextOptions()))
        //{
        //    var command = Fixture.Create<CreateUser>();

        //    var validator = new Mock<IValidator<CreateUser>>();
        //    validator
        //        .Setup(x => x.ValidateAsync(command, new CancellationToken()))
        //        .ReturnsAsync(new ValidationResult());

        //    var sut = new CreateOrganisatieHandler(dbContext, validator.Object);

        //    await sut.Handle(command);

        //    var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == command.Id);
        //    var @event = await dbContext.Events.FirstOrDefaultAsync(x => x.TargetId == command.Id);

        //    validator.Verify(x => x.ValidateAsync(command, new CancellationToken()));
        //    Assert.NotNull(user);
        //    Assert.NotNull(@event);
        //}
    }
}