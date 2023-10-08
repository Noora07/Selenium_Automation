using System;
using SeleniumCSharpTutorial.UIElements;

namespace SeleniumCSharpTutorial
{
	public class EntryPoint
	{
		public static void mains()
		{
            HomePage homePage = new HomePage();
            //HomePage homepage = homePage;

            Driver.driver.Navigate().GoToUrl("https://demoqa.com/books");

            homePage.login.Click();
			Console.WriteLine("Its done");
		}
	}
}

