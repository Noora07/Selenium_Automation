using System;
using System.Collections.Generic;
using CSharpSeleniumFramework.pageObjects;
using CSharpSeleniumFramework.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharpSeleniumFramework
{
	public class E2EFlow : Base
	{
		[Test]
        public void EndToEndFlow()
        {
            String[] expProduct = { "iphone X", "Blackberry" };
            String[] actualProd = new String[2];
            LoginPage loginPage = new LoginPage(getDriver());
            ProductPage productPage = loginPage.validLogin("rahulshettyacademy", "learning");


            //Products page
            productPage.waitForPageDisplay();
            IList<IWebElement> products = productPage.getCards();

            foreach (IWebElement filter in products)
            {
                //string actProduct = filter.FindElement(By.CssSelector(".card-title a")).Text;
                string actProduct = filter.FindElement(productPage.getCardTitle()).Text;
                if (expProduct.Contains(actProduct))
                {
                    filter.FindElement(productPage.getaddToCartButton()).Click();
                }

                
            }

            CheckoutPage checkoutPage = productPage.getCheckout();

            IList<IWebElement> checkoutCards = checkoutPage.getCards();
          

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProd[i] = checkoutCards[i].Text;

            }

            Assert.That(expProduct, Is.EqualTo(actualProd));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn-success")));

            ConfirmationPage confirmationPage = checkoutPage.checkout();

            confirmationPage.Purchase("ind", "Indonesia");
            //confirmationPage.getLocation().SendKeys("Ind");
            //driver.FindElement(By.ClassName("btn-success")).Click();

            /*driver.FindElement(By.Id("country")).SendKeys("Ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("suggestions")));
            driver.FindElement(By.LinkText("Indonesia")).Click();
            TestContext.Progress.WriteLine("Hi There its clickable");
            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.FindElement(By.CssSelector(".btn-success")).Click();*/
            //confirmationPage.Purchase("India");

            string actualMessage = confirmationPage.getalertConfirmation().Text;
            //string actualMessage = driver.FindElement(By.CssSelector(".alert-success")).Text;
            TestContext.Progress.WriteLine(actualMessage);
            StringAssert.Contains("Success! Thank you!", actualMessage);
        }
    }

}

