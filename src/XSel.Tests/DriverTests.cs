using FluentAssertions;
using NUnit.Framework;
using System;
using System.IO;
using System.Reflection;

namespace XSel.Tests
{
    public class DriverTests
    {
        [Test]
        public void Driver_GetChromeDriver_SearchDriverInEnvPath()
        {
            Environment.SetEnvironmentVariable("ChromeWebDriver", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), EnvironmentVariableTarget.Process);

            var driver = Driver.GetChromeDriver();
            driver.Should().NotBeNull();

            driver.Close();
            driver.Quit();
        }
    }
}
