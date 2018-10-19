using Moq;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using System.IO;
using System.Reflection;

namespace XSel.Tests
{
    public class DriverTests
    {
        [Test]
        public void Driver_GetChromeDriver_SearchDriverInEnvPath()
        {
            Environment.SetEnvironmentVariable("ChromeWebDriver", "XXXX");

            Action act = () => {
                Driver.GetChromeDriver();
            };

            act.Should()
                .Throw<OpenQA.Selenium.DriverServiceNotFoundException>()
                .WithMessage("The file XXXX\\chromedriver.exe does not exist. The driver can be downloaded at http://chromedriver.storage.googleapis.com/index.html");
        }
    }
}
