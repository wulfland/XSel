using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;

namespace XSel
{
    public static class Driver
    {
        public static RemoteWebDriver GetChromeDriver(string mobileEmulatedDevice = null)
        {
            var path = Environment.GetEnvironmentVariable("ChromeWebDriver");
            var options = new ChromeOptions();
            options.AddArguments("--no-sandbox");

            if (!string.IsNullOrEmpty(mobileEmulatedDevice))
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

        public static RemoteWebDriver GetDriver<TWebDriver>(string mobileEmulatedDevice = null) where TWebDriver : IWebDriver, new()
        {
            if (typeof(TWebDriver) == typeof(ChromeDriver))
            {
                return GetChromeDriver(mobileEmulatedDevice);
            }
            else
            {
                IWebDriver driver;

                if (typeof(TWebDriver).Name == "FirefoxDriver")
                {
                    string path = Environment.GetEnvironmentVariable("GeckoWebDriver");

                    if (string.IsNullOrWhiteSpace(path))
                    {
                        path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    }

                    driver = (IWebDriver)Activator.CreateInstance(typeof(TWebDriver), new object[] { path });
                }
                else if (typeof(TWebDriver).Name == "InternetExplorerDriver")
                {
                    string path = Environment.GetEnvironmentVariable("IEWebDriver");

                    if (string.IsNullOrWhiteSpace(path))
                    {
                        path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    }

                    driver = (IWebDriver)Activator.CreateInstance(typeof(TWebDriver), new object[] { path });
                }
                else
                {
                    driver = new TWebDriver();
                }

                return (RemoteWebDriver)driver;
            }
        }
    }
}
