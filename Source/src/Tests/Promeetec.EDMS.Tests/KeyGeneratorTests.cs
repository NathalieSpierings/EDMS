using NUnit.Framework;
using Promeetec.EDMS.Portaal.Core.Extensions;

namespace Promeetec.EDMS.Tests;

[TestFixture]
public class KeyGeneratorTests
{
    [TestCase(16)]
    public void Should_generate_puk_code(int size)
    {
        var pukCode = KeyGenerator.GeneratePukCode(size);
        var result = pukCode.Replace("-", string.Empty);

        Assert.IsNotNull(pukCode);
        Assert.AreEqual(size, result.Length);
    }

    [TestCase(8)]
    public void Should_generate_unique_key(int size)
    {
        var key = KeyGenerator.GenerateUniqueKey(size);

        Assert.IsNotNull(key);
        Assert.AreEqual(size, key.Length);
    }


    [TestCase(8)]
    public void Should_generate_password(int size)
    {
        var password = KeyGenerator.CreatePassword(size);
        
        Assert.IsNotNull(password);
        Assert.AreEqual(size, password.Length);
    }
}
