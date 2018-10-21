using OpenQA.Selenium.Remote;
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

        public void Initialize(string mobileEmulatedDevice = null)
        {
            _driver = Driver.GetChromeDriver(mobileEmulatedDevice);

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(4));
        }

        public void ChangeBrowserSize(string windowSize)
        {
            var browserSize = BrowserSize.Parse(windowSize);

            if (browserSize is BrowserSizeMaximized)
            {
                _driver.Manage().Window.Maximize();
            }
            else
            {
                _driver.Manage().Window.Size = browserSize.ToSize();
            }
        }

        public void CleanUp()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
