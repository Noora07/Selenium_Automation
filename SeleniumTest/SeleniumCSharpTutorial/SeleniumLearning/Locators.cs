using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
	public class Locators
	{
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //implicit wait can be declared
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }
        [Test]
		public void LocatorsIdentification()
		{
            IWebElement userName = driver.FindElement(By.Id("username"));
            userName.SendKeys("rahulshetty");
            userName.Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("1234");
            //deep-xpath
            //driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            //deep-css if id than #<id>, if css unique class-name than .classname 
            driver.FindElement(By.CssSelector(".text-info span:nth-child(1) input")).Click();

            //BY CSS
            //tagname[attribute='value']
            //driver.FindElement(By.CssSelector("input[value = 'Sign In']")).Click();
            //xpath //tagname[@attribute ='value']
            IWebElement signButton =  driver.FindElement(By.XPath("//input[@value = 'Sign In']"));
            signButton.Click();

            //Explicit Wait

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(signButton, "Sign In"));
            

            string alertMessage = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(alertMessage);

            IWebElement link = driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            string actLink = link.GetAttribute("href");

            string expectedURL = "https://rahulshettyacademy.com/documents-request";

            Assert.That(actLink, Is.EqualTo(expectedURL));
           
		}

        
	}
}

