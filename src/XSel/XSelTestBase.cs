﻿using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace XSel
{
    public abstract class XSelTestBase
    {
        protected RemoteWebDriver _driver;

        protected WebDriverWait _wait;

        public void Initialize(string windowSize = "Max")
        {
            _driver = Driver.GetChromeDriver();

            var browserSize = BrowserSize.Parse(windowSize);

            if (browserSize is BrowserSizeMaximized)
            {
                _driver.Manage().Window.Maximize();
            }
            else
            {
                _driver.Manage().Window.Size = browserSize.ToSize();
            }

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
        }

        public void CleanUp()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
