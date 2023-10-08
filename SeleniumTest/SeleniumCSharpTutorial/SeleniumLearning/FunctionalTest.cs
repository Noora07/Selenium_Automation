using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class FunctionalTest
    {
        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //implicit wait can be declared
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

        }

        [Test]
        public void dropDown()
        {
            IWebElement dropDown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement sel = new SelectElement(dropDown);
            sel.SelectByText("Teacher");
            sel.SelectByValue("consult");
            sel.SelectByIndex(0);
        }

        [Test]
        public void radioButtonbylocator()
        {
            IWebElement userName = driver.FindElement(By.Id("username"));
            userName.SendKeys("rahulshetty");
            userName.Clear();
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");
            driver.FindElement(By.CssSelector("label:nth-child(2) input")).Click();
            //TestContext.Progress.WriteLine("radio button is selected");
            Thread.Sleep(2);
            driver.FindElement(By.Id("okayBtn")).Click();
            //Boolean result = driver.FindElement(By.)

        }

        [Test]
        public void radioButtons()
        {
            IList<IWebElement> rdButton = driver.FindElements(By.CssSelector("input[type='radio']"));
            foreach (IWebElement radButton in rdButton)
            {


                if (radButton.GetAttribute("value").Equals("user"))

                {
                    radButton.Click();

                }

            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();

            Boolean result = driver.FindElement(By.CssSelector("label:nth-child(2) input")).Selected;
            TestContext.Progress.WriteLine("Result is " + result);
            Assert.That(result, Is.True);
        }
        [Test]
        public void positiveLogin()
        {
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");
            driver.FindElement(By.CssSelector("label:nth-child(2) input")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.Id("okayBtn")).Click();
            IWebElement dropDown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement selc = new SelectElement(dropDown);
            selc.SelectByValue("consult");

            driver.FindElement(By.Id("terms")).Click();
            driver.FindElement(By.Id("signInBtn")).Click();
        }
    }    
}

