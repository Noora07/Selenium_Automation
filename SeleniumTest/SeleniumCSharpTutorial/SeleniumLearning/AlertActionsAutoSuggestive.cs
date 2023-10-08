using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
	public class AlertActionsAutoSuggestive
	{
		IWebDriver driver;

		[SetUp]
		public void startBrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
			driver.Manage().Window.Maximize();
			driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
		}

		[Test]
		public void testAlert()
		{
			String name = "Saruchi Kaundil";
			driver.FindElement(By.Id("name")).SendKeys(name);
            driver.FindElement(By.Id("confirmbtn")).Click();
			string alertMessage = driver.SwitchTo().Alert().Text;
			driver.SwitchTo().Alert().Accept();
			//driver.SwitchTo().Alert().Dismiss();
			//driver.SwitchTo().Alert().SendKeys("Hello World");
			StringAssert.Contains(name, alertMessage);
            //Assert.That(result, Is.True);
            //Assert.That(ActualArray, Is.EqualTo(orignalArray));

        }

		[Test]
		public void testAutoSuggestiveDropDowns()
		{
			driver.FindElement(By.Id("autocomplete")).SendKeys("In");
			WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(5));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("autocomplete")));

			IList<IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));
			foreach (IWebElement op in options)
			{
				if (op.Text.Equals("India"))
				{
					op.Click();
				}
			}
            

            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
		}

		[Test]
		public void staticDropdown()
		{
			IWebElement options = driver.FindElement(By.Id("dropdown-class-example"));
			SelectElement selOption = new SelectElement(options);
			selOption.SelectByValue("option2");
			TestContext.Progress.WriteLine(driver.FindElement(By.Id("dropdown-class-example")).GetAttribute("value"));
		}

		//Test for hover over
		[Test]
		public void test_Actions()
		{
			driver.Url = "https://rahulshettyacademy.com/";
			Actions act = new Actions(driver);
			act.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Click().Perform();
			
			driver.FindElement(By.CssSelector("ul.dropdown-menu li:nth-child(1) a")).Click();
            //act.MoveToElement(driver.FindElement(By.CssSelector("ul.dropdown-menu li:nth-child(1) a"))).Click().Perform();
        }

		//Test to verify Drag and Drop
		[Test]
		public void DnD()
		{
			driver.Url = "https://demoqa.com/droppable";

            Actions a = new Actions(driver);
			a.DragAndDrop(driver.FindElement(By.Id("draggable")),driver.FindElement(By.Id("droppable"))).Perform();
		}

		//to verify iframes
		[Test]
		public void frames()
		{
			IWebElement frameScroll = driver.FindElement(By.Id("courses-iframe"));
			//scroll down window via java script event
			//Casting driver with IJavaScriptExecuter
			IJavaScriptExecutor javaScr = (IJavaScriptExecutor)driver;
			javaScr.ExecuteScript("arguments[0].scrollIntoView(true);",frameScroll);//script to scroll
			driver.SwitchTo().Frame("courses-iframe");
			driver.FindElement(By.LinkText("All Access Plan")).Click();
			TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
			driver.SwitchTo().DefaultContent();
			TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);

		}

        [TearDown]
		public void closeBrowser()
		{
			//driver.Quit();
		}
	}
}

