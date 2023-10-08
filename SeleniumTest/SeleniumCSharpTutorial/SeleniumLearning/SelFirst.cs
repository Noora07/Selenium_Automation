using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
	public class SelFirst
	{
        public IWebDriver driver;
            
        [SetUp]
        public void StartBrowser()
        {
            //chromedriver.exe ChromeDriver ChromeConfig, 
            //webdriver manager for managing the version of browser exe
            //geckodriver.exe FirefoxDriver FirefoxConfig
            //edge.exe EdgeDriver EdegeConfig
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/";

        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}

