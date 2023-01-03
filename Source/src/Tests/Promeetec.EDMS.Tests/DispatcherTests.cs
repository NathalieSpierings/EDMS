using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Mapping;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Tests
{
    public class DispatcherTests
    {
       
        [Test]
        public async Task Should_get_result()
        {
            var query = new SampleQuery();
            var result = new SampleResult();

            var commandSender = new Mock<ICommandSender>();
            var queryProcessor = new Mock<IQueryProcessor>();
            queryProcessor.Setup(x => x.Process(query)).ReturnsAsync(result);
            var eventPublisher = new Mock<IEventPublisher>();
            var objectFactory = new Mock<IObjectFactory>();

            var sut = new Dispatcher(commandSender.Object, queryProcessor.Object, eventPublisher.Object, objectFactory.Object);

            var actual = await sut.Get(query);

            queryProcessor.Verify(x => x.Process(query), Times.Once);
            Assert.AreEqual(result, actual);
        }
        
    }
}
