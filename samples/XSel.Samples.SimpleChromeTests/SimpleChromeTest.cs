using NUnit.Framework;
using OpenQA.Selenium;

namespace XSel.Samples
{
    public class SimpleChromeTest : XSelTestBase
    {
        [SetUp]
        public void Setup()
        {
            Initialize();
        }

        [Test]
        public void Samples_SimpleChromeTest()
        {
            _driver.Navigate().GoToUrl("https://writeabout.net");

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