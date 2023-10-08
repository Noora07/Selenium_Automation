using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace CSharpSeleniumFramework.pageObjects
{
	public class LoginPage
	{
		private IWebDriver driver;

		public LoginPage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}

		//PageFactory
		[FindsBy(How = How.Id, Using = "username")]
		private IWebElement userName;

		[FindsBy(How = How.Name, Using = "password")]
		private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "label:nth-child(2) input")]
        private IWebElement radioUser;

		[FindsBy(How = How.CssSelector, Using = "select.form-control")]
		private IWebElement userOption;

		[FindsBy(How = How.Id, Using = "terms")]
		private IWebElement checkTerms;

		[FindsBy(How = How.Name, Using = "signin")]
		private IWebElement submitBtn;

        //Methods


        public ProductPage validLogin(string username, string passWord)
        {
            userName.SendKeys(username);
            password.SendKeys(passWord);
            //radioUser.Click();
            IWebElement dropDown = userOption;
            SelectElement sel = new SelectElement(dropDown);
            sel.SelectByValue("consult");
            checkTerms.Click();
            submitBtn.Click();
            return new ProductPage(driver);
        }

        public ProductPage validLogin(string username, string passWord, string option)
		{
            userName.SendKeys(username);
            password.SendKeys(passWord);
            radioUser.Click();
			IWebElement dropDown = userOption;
            SelectElement sel = new SelectElement(dropDown);
            sel.SelectByValue(option);
            checkTerms.Click();
            submitBtn.Click();
            return new ProductPage(driver); 

        }

        public IWebElement getUserName()
		{
			return userName;
		}

		public IWebElement getPassword()
		{
			return password;
		}

		public IWebElement getuserType()
		{
			return radioUser;
		}

        public IWebElement getuserOption()
        {
            return userOption;
        }

        public IWebElement getCheckTerms()
        {
            return checkTerms;
        }

        public IWebElement getSubmit()
        {
            return submitBtn;
        }
    }
}

