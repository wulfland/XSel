using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace XSel
{
    public static class Driver
    {
        public static RemoteWebDriver GetChromeDriver(string mobileEmulatedDevice = null)
        {
            var path = Environment.GetEnvironmentVariable("ChromeWebDriver");
            var options = new ChromeOptions();
            options.AddArguments("--no-sandbox");

            if (!string.IsNullOrEmpty(mobileEmulatedDevice ))
            {
                options.EnableMobileEmulation(mobileEmulatedDevice);
            }

            if (!string.IsNullOrWhiteSpace(path))
            {
                return new ChromeDriver(path, options, TimeSpan.FromSeconds(300));
            }
            else
            {
                return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            }
        }
    }
}
