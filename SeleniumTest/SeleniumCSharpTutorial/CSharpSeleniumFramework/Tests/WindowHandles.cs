using System;
using CSharpSeleniumFramework.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using WebDriverManager.DriverConfigs.Impl;

namespace CSharpSeleniumLearning
{
	public class WindowHandles :Base
	{
		
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

