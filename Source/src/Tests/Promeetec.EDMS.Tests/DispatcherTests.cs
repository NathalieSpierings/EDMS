using Moq;
using NUnit.Framework;
using Promeetec.EDMS.Portaal.Core;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Core.Mapping;
using Promeetec.EDMS.Portaal.Core.Queries;
using Promeetec.EDMS.Tests;

namespace Promeetec.EDMS.Portaal.Tests
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
