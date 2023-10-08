using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
	public class E2ETest
	{
		IWebDriver driver;
		[SetUp]
		public void startBrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
			driver.Manage().Window.Maximize();
			driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }



		[Test]
		public void EndToEndFlow()
		{
			String[] expProduct = {"iphone X", "Blackberry" };
			String[] actualProd = new String[2];
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");
            driver.FindElement(By.Id("terms")).Click();
            driver.FindElement(By.Id("signInBtn")).Click();
			WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(8));
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

			IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
			foreach (IWebElement filter in products)
			{
				string actProduct = filter.FindElement(By.CssSelector(".card-title a")).Text;
				if (expProduct.Contains(actProduct))
				{
                    filter.FindElement(By.ClassName("btn-info")).Click();
                }

				/*for (int i = 0; i < expProduct.Length; i++)
				{
					if (expProduct[i] == actProduct)
					{
						filter.FindElement(By.ClassName("btn-info")).Click();

					}
				}*/
			}

			driver.FindElement(By.PartialLinkText("Checkout")).Click();

			IList<IWebElement> CheckoutList = driver.FindElements(By.CssSelector("h4 a"));

			for (int i = 0; i < CheckoutList.Count; i++)
			{
                actualProd[i] = CheckoutList[i].Text;
				
			}

			Assert.That(expProduct, Is.EqualTo(actualProd));
			//wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-success")));
			
			driver.FindElement(By.ClassName("btn-success")).Click();
			driver.FindElement(By.Id("country")).SendKeys("Ind");
			wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("suggestions")));
			driver.FindElement(By.LinkText("Indonesia")).Click();
            TestContext.Progress.WriteLine("Hi There its clickable");
            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
			driver.FindElement(By.CssSelector(".btn-success")).Click();
			string actualMessage = driver.FindElement(By.CssSelector(".alert-success")).Text;
			TestContext.Progress.WriteLine(actualMessage);
			StringAssert.Contains("Success! Thank you!",actualMessage);
        }
    }
}

