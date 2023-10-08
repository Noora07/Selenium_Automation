using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumCSharpTutorial.UIElements
{
	public class HomePage
	{
		public HomePage()
		{
			PageFactory.InitElements(Driver.driver,this);
      
        }
        [FindsBy(How = How.Id, Using = "item-0")]
        public IWebElement login { get; set; }

    }
}

