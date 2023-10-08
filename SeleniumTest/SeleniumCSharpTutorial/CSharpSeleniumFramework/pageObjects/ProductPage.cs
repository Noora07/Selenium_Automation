using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace CSharpSeleniumFramework.pageObjects
{
	public class ProductPage

	{
        private IWebDriver driver;
        By cardTitle = By.CssSelector(".card-title a");
        By addToCart = By.ClassName("btn-info");

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PageFactory
        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutBtn;
        

        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }
        //to select the products
        

        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public By getCardTitle()
        {
            return cardTitle;
        }

        public By getaddToCartButton()
        {
            return addToCart;
        }

        public CheckoutPage getCheckout()
        {
            checkoutBtn.Click();
            return new CheckoutPage(driver);
        }
    }
}

