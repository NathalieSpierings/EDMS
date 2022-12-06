using AutoFixture;
using NUnit.Framework;

namespace Promeetec.EDMS.Domain.Tests;

[TestFixture]
public abstract class TestFixtureBase
{
    protected Fixture Fixture { get; private set; }

    public Guid PromeetecId { get; set; } = Guid.NewGuid();

    [SetUp]
    protected void SetUpAutoFixture()
    {
        Fixture = new Fixture();

        Fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
        Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }
}