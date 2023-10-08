namespace SeleniumLearning;

public class Tests
{
    [OneTimeSetUp]
    public void Setup()
    {
        TestContext.Progress.WriteLine("We are inside Setup");
    }

    [Test]
    public void Test1()
    {
        TestContext.Progress.WriteLine("We are inside Test1");
    }
    [Test]
    public void Test2()
    {
        TestContext.Progress.WriteLine("We are inside Test2");
    }
    [TearDown]
    public void CloseBrowser()
    {
        TestContext.Progress.WriteLine("We are inside TearDown");
    }
}
