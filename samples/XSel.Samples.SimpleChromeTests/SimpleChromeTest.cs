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

            WaitForPageLoad();

            Assert.AreEqual("Search Results for “DevOps” – writeabout.net", _driver.Title);
        }

        [TestCase("Max")]
        [TestCase("1024x786")]
        [TestCase("360x640")]
        public void Samples_SimpleChromeTest(string windowSize)
        {
            ChangeBrowserSize(windowSize);

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

            WaitForPageLoad();

            Assert.AreEqual("Search Results for “DevOps” – writeabout.net", _driver.Title);
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }
    }
}