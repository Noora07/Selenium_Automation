namespace CSharpSeleniumFramework;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        TestContext.Progress.WriteLine("Hello its done");
    }
}
