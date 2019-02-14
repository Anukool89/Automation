﻿using Common.Library.enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Pages.Contracts;

namespace Selenium.Page.Repository
{
    public class SeleniumBase : IBase
    {
        public IWebDriver Driver { get; set; }

        public void InitialSetup()
        {
            Driver = GetDriver(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://qa.moodle.net/");
        }

        private IWebDriver GetDriver(BrowserType browserType)
        {
            IWebDriver _driver = null;
            switch (browserType)
            {
                case BrowserType.Chrome:
                    _driver = new ChromeDriver();
                    break;

                case BrowserType.IE:
                    _driver = new InternetExplorerDriver();
                    break;
            }
            return _driver;
        }

        public void FinalTearDown()
        {
            Driver.Quit();
        }
    }
}