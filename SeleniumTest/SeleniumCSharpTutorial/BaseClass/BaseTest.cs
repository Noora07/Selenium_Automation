/*using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
namespace SeleniumCSharpTutorial.BaseClass
{
	public class BaseTest
	{
		public IWebDriver driver;

		[SetUp]
		public void Open()
		{
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();
			driver.Navigate().GoToUrl("https://demoqa.com");
            //driver.Url = "https://demoqa.com/textbox";
            IWebElement cklabel = driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div[2]/div/div[1]/div/div[1]"));
            Thread.Sleep(5000);
            cklabel.Click();
        }

		[TearDown]
		public void Close()
		{
			Console.WriteLine("TearDown");
			driver.Quit();
		}
	}
}*/

