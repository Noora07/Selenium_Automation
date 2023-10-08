/*using OpenQA.Selenium;
using SeleniumCSharpTutorial.BaseClass;
namespace SeleniumCSharpTutorial;


public class Tests : BaseTest
{
    [SetUp]
    public void Setup()
    {
        
        
    
    }

    /*[Test]
    public void Test1()
    {
        
        Console.WriteLine("Text Box Link");
        IWebElement cklabel = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div/div[1]/div/div[1]"));
        Thread.Sleep(5000);
        cklabel.Click();
        IWebElement ckMenuText = driver.FindElement(By.Id("item-0"));
        ckMenuText.Click();
        IWebElement txtName = driver.FindElement(By.Id("userName"));
        txtName.SendKeys("Saruchi Kaundil");
        IWebElement txtEmail = driver.FindElement(By.Id("userEmail"));
        txtEmail.SendKeys("saruchi.singh@gmail.com");
        IWebElement txtCuAdd = driver.FindElement(By.Id("currentAddress"));
        txtCuAdd.SendKeys("Noida");
        IWebElement txtPerAdd = driver.FindElement(By.Id("permanentAddress"));
        txtPerAdd.SendKeys("Noida");
        IWebElement btnSub = driver.FindElement(By.Id("submit"));
        btnSub.SendKeys(Keys.Return);
     
        IWebElement txtResult = driver.FindElement(By.Id("name"));

        if (txtResult.Displayed)
        {
            System.Console.WriteLine("Yes I can see the element");
            Assert.Pass();
        }
        else {
            System.Console.WriteLine("No its not visible");
        }
        driver.Quit();
        //IWebElement emailTextField = driver.FindElement(By.Id("email"));
        //IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id=email]"));
        //emailTextField.SendKeys("Selenium C#");
        
        //Assert.Pass();
    }*/

    /*[Test]
    public void Test2()
    {
        int option;
        Console.WriteLine("Check Box Link");
        IWebElement cklabel = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div/div[1]/div/div[1]"));
        Thread.Sleep(5000);
        cklabel.Click();
        IWebElement ckMenuChkBox = driver.FindElement(By.Id("item-1"));
        ckMenuChkBox.Click();
        IWebElement btnArrow = driver.FindElement(By.CssSelector("#tree-node > ol > li > span > button"));
        btnArrow.Click();
        option = 1;
        IWebElement checkBoxEl = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child("+option+") > span > label > span.rct-checkbox > svg"));
        checkBoxEl.Click();
        option = 3;
        IWebElement checkBoxEl2 = driver.FindElement(By.CssSelector("#tree-node > ol > li > ol > li:nth-child("+option+") > span > label > span.rct-checkbox > svg"));
        checkBoxEl2.Click();

        //IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id=email]"));
        //emailTextField.SendKeys("Heya");
        //Thread.Sleep(5000);

        //Assert.Pass();
    }*/
    /*[Test]
    public void Test3()
    {
   
        Console.WriteLine("Radio Button Link");
        
        IWebElement rdBtn = driver.FindElement(By.Id("item-2"));
        rdBtn.Click();
        //Thread.Sleep(4000);
        IWebElement rdBtnSel = driver.FindElement(By.Id("impressiveRadio"));
        rdBtnSel.SendKeys(Keys.Space);
        Thread.Sleep(3000);
        IWebElement rdBtnSel2 = driver.FindElement(By.XPath("//*[@id=\"yesRadio\"]"));
        rdBtnSel2.SendKeys(Keys.Space);
    }*/

  /*  [Test]
    public void Test4()
    {
        Console.WriteLine("Add Table");
        IWebElement rdBtn = driver.FindElement(By.Id("item-2"));
        rdBtn.Click();
        IWebElement adTable = driver.FindElement(By.XPath("//*[@id=\"item-3\"]"));
        if (adTable.Displayed)
        {
            Console.WriteLine("Its there only");
            adTable.Click();
        }
        else
        {
            Console.WriteLine("Its not there");
        }
    }
}
*/