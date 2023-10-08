using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace CSharpSeleniumFramework.pageObjects
{
	public class ConfirmationPage
	{
		IWebDriver driver;
		public ConfirmationPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement location;

        

        [FindsBy(How = How.CssSelector, Using = ".suggestions ul li a")]
        private IList<IWebElement> suggestionList;

        

        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2']")]
        private IWebElement checkTC;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement purchaseButton;

        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement alertConfirmation;

        //driver.FindElement(By.CssSelector(".alert-success"))
        //Methods

        

			
        public IList<IWebElement> waitDropDownVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".suggestions")));
            return suggestionList;
        }

        public IWebElement getLocation()
        {
            return location;
        }

        public IWebElement getalertConfirmation()
        {
            return alertConfirmation;
        }

        public void Purchase(string Location, string CountryName)
        {
            location.SendKeys(Location);
            
            IList<IWebElement> options = waitDropDownVisible();
            //String[] strOption = options.Text.Split('\n');

            foreach (IWebElement op in options)
            {
               // IList<IWebElement> suggestiveList = op.Text.Split('\n');
                if (op.Text.Equals(CountryName))
                {
                    //TestContext.Progress.WriteLine("Auto sugesstion " +op.Text);
                    op.Click();
                }
            }
            checkTC.Click();
            purchaseButton.Click();
        }

       
        
    }
}

