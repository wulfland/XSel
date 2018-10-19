using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace XSel
{
    public abstract class XSelTestBase
    {
        public RemoteWebDriver WebDriver { get; private set; }

        public WebDriverWait WebDriverWait { get; private set; }

        public void Initialize(string windowSize = "Max")
        {
            WebDriver = Driver.GetChromeDriver();

            var browserSize = BrowserSize.Parse(windowSize);

            if (browserSize is BrowserSizeMaximized)
            {
                WebDriver.Manage().Window.Maximize();
            }
            else
            {
                WebDriver.Manage().Window.Size = browserSize.ToSize();
            }

            WebDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(4));
        }

        public void CleanUp()
        {
            WebDriver.Close();
        }
    }
}
