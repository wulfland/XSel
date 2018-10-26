using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace XSel
{
    public abstract class XSelTestBase
    {
        protected RemoteWebDriver _driver;

        protected WebDriverWait _wait;

        public void Initialize(string mobileEmulatedDevice = null)
        {
            _driver = Driver.GetChromeDriver(mobileEmulatedDevice);

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
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

        protected void TakeScreenshot(string filename)
        {
            TakeScreenshot(filename, ScreenshotImageFormat.Png);
        }

        protected void TakeScreenshot(string filename, ScreenshotImageFormat format)
        {
            try
            {
                var screenshot = Path.Combine(TestContext.CurrentContext.TestDirectory, filename);

                _driver.GetScreenshot().SaveAsFile(screenshot, format);

                TestContext.AddTestAttachment(screenshot);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Error taking Screenshot '{filename}': {ex.Message}");
            }
        }

        protected void WaitForDomReady()
        {
            // wait for the dom to load
            _wait.Until(d => ((RemoteWebDriver)d)
                .ExecuteScript("return document.readyState")
                .Equals("complete")
            );
        }

        public void CleanUp()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
