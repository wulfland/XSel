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

            var searchBox = _wait.Until(
                d => d.FindElement(By.Name("s")));

            searchBox.SendKeys("DevOps");

            var button = _wait.Until(d => d.FindElement(By.ClassName("search-submit")));

            var oldTitle = _driver.Title;

            button.Submit();

            TakeScreenshot($"Sample_SimpleMobileEmulationTest_{mobileEmulatedDevice}.png");

            _wait.Until(d => d.Title != oldTitle);

            var newTitle = _wait.Until(d => d.Title);

            Assert.AreEqual("Search Results for “DevOps” – writeabout.net", newTitle);

        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }
    }
}
