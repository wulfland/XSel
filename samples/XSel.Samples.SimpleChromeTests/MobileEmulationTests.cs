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
        [TestCase("iPhone X")]
        [TestCase("Pixel 2 XL")]
        public void Sample_SimpleMobileEmulationTest(string mobileEmulatedDevice)
        {
            Initialize(mobileEmulatedDevice);

            var url = TestContext.Parameters["webAppUrl"];

            _driver.Navigate().GoToUrl(url);

            var searchBox = _wait.Until(
                d => d.FindElement(
                    By.CssSelector("#search-4 > form > label > input")));

            searchBox.SendKeys("DevOps");

            var button = _wait.Until(
                d => d.FindElement(
                By.CssSelector("#search-4 > form > button")));

            button.Click();

            Assert.AreEqual("Search Results for “DevOps” – writeabout.net", _driver.Title);

        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }
    }
}
