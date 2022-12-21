using System.Security.Claims;
using Moq;
using NUnit.Framework;

namespace Promeetec.EDMS.Domain.Tests.Identity;

[TestFixture]
public class ClaimsPrincipalTests
{
    [Test]
    public void TestClaims()
    {
        var claims = new Mock<ClaimsPrincipal>();
        var principal = new ClaimsPrincipal(new ClaimsIdentity("Basic"));


    }
}
