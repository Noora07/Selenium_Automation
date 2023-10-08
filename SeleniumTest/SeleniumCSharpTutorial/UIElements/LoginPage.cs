using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

using System;


namespace SeleniumCSharpTutorial.UIElements
{
    public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement userName { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement LogButton { get; set; }

        [FindsBy(How = How.Id, Using = "newUser")]
        public IWebElement AddUser { get; set; }
    }
   
}

