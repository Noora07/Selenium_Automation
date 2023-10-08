using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
	public class SortWebTables
	{
        //private const int Actual = 1;
        IWebDriver driver;

		[SetUp]
		public void startBrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);

			driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/";
			//driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";

        }

		[Test]
		public void sortVegTable()
		{

			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".cart-icon")));
			

			//to handle the different window opened by an application

			//store id of orignal window
			string orgWindow = driver.CurrentWindowHandle;

			//Assert.AreEqual(driver.WindowHandles.Count, 1);
			Assert.That(driver.WindowHandles.Count, Is.EqualTo(1));

            driver.FindElement(By.CssSelector(".cart-header-navlink:nth-child(2)")).Click();

			wait.Until(wd => wd.WindowHandles.Count == 2);
			foreach (String window in driver.WindowHandles)
			{
				if (window != orgWindow)
				{
					driver.SwitchTo().Window(window);
					break;
				}

			}
            

			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("page-menu")));
			IWebElement pageSize = driver.FindElement(By.Id("page-menu"));
			SelectElement sel = new SelectElement(pageSize);
			sel.SelectByValue("20");

			//get the vegetable names into array list

			ArrayList orignalArray = new ArrayList(); 

			IList<IWebElement> orignalList = driver.FindElements(By.CssSelector("tr td:nth-child(1)"));
			foreach (IWebElement veggies in orignalList)
			{
				orignalArray.Add(veggies.Text);
			}
			orignalArray.Sort();
			foreach (string element in orignalArray)
			{
				TestContext.Progress.WriteLine(element);
			}

            // click the column

            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();
            ArrayList ActualArray = new ArrayList();

			IList<IWebElement> actualList = driver.FindElements(By.CssSelector("tr td:nth-child(1)"));
			foreach (IWebElement vegetable in actualList)
			{
				ActualArray.Add(vegetable.Text);
			}
            //Assert.AreEqual(orignalArray,ActualArray);
			Assert.That(ActualArray,Is.EqualTo(orignalArray));


        }

		[TearDown]

		public void closeBrowser()
		{
			driver.Quit();
		}
	}
}

