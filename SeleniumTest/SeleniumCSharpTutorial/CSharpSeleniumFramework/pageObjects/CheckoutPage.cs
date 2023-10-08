using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace CSharpSeleniumFramework.pageObjects
{
	public class CheckoutPage
	{
		IWebDriver driver;

		public CheckoutPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver,this);
		}

		//IList<IWebElement> CheckoutList = driver.FindElements(By.CssSelector("h4 a"));
		[FindsBy(How = How.CssSelector, Using = "h4 a")]
		private IList<IWebElement> checkoutCards;

		[FindsBy(How = How.ClassName, Using = "btn-success")]
		private IWebElement checkoutButton;

		public IList<IWebElement> getCards()
		{
			return checkoutCards;
		}

		public ConfirmationPage checkout()
		{
			checkoutButton.Click();
			return new ConfirmationPage(driver);
		}
        
    }
}

