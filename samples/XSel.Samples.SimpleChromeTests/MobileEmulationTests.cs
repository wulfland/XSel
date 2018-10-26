using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace XSel.Samples
{
    public class MobileEmulationTests : XSelTestBase
    {
        [TestCase("iPad")]
        [TestCase("iPhone X")]
        [TestCase("Pixel 2 XL")]
        public void Sample_SimpleMobileEmulationTest(string mobileEmulatedDevice)
        {
            Initialize(mobileEmulatedDevice);

            var url = TestContext.Parameters["webAppUrl"];

            _driver.Navigate().GoToUrl(url);

            var button = _wait.Until(
                d => d.FindElement(
                By.CssSelector("#slide-1620 > div.slide-content.clearfix > div.read-more > a")));

            button.Click();

            var heading = _wait.Until(d => d.FindElement(By.CssSelector("#post-1620 > header > h1")));

            TakeScreenshot($"Sample_SimpleMobileEmulationTest_{mobileEmulatedDevice}.png");

            Assert.AreEqual("FAIL YOUR AZURE DEVOPS PIPELINE IF SONARQUBE QUALITY GATE FAILS", heading.Text);

        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }
    }
}
