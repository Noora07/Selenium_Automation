using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSeleniumFramework.utilities
{
	public class Base
	{
		private IWebDriver driver;
       

        [SetUp]
		public void startBrowser()
		{
			string browserName = ConfigurationManager.AppSettings["browser"];
			InitBrowser(browserName);
			driver.Manage().Window.Maximize();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);

			driver.Url = ConfigurationManager.AppSettings["URL"];

		}

		public IWebDriver getDriver()
		{
			return driver;
		}

		public void InitBrowser(string browserName)
		{
			switch (browserName)
			{
				case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
					break;
				case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
					break;

				case "Safari":
                    //new WebDriverManager.DriverManager().SetUpDriver(new SafariConfig());
                    driver = new SafariDriver();
					break;
            }
		}

		[TearDown]
		public void closeBrowser()
		{
			driver.Close();
		}
	}
}

