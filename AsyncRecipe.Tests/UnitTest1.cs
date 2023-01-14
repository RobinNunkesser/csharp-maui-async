using System.Threading.Tasks;
using AsyncRecipe.Core;
using NUnit.Framework;

namespace AsyncRecipe.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task TestUIExample()
    {
        var example = new AsyncExample();
        var result = await example.UIExample();
        Assert.AreEqual(42, result);
    }
}
