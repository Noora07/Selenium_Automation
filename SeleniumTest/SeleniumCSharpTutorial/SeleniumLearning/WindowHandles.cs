using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
	public class WindowHandles
	{
		IWebDriver driver;
		[Test]
		public void startBrowser()
		{
			new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";

		}

		[Test]
		public void WindowHandle()
		{
			String parentWindowId = driver.CurrentWindowHandle;
			driver.FindElement(By.CssSelector(".blinkingText")).Click();
		
			Assert.That(driver.WindowHandles.Count, Is.EqualTo(2));
			string str = driver.WindowHandles[1];
			driver.SwitchTo().Window(str);

			String wholeText = driver.FindElement(By.CssSelector(".red")).Text;
			string[] words = wholeText.Split(" ");
			
			foreach (String ab in words)
			{
			 
				if (ab.Contains(".com"))
				{
					words[0] = ab;
				}

			}
			TestContext.Progress.WriteLine(words[0]);

			driver.SwitchTo().Window(parentWindowId);
			driver.FindElement(By.Id("username")).SendKeys(words[0]);

		}




    }
}

