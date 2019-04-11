using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

            var searchBox = _wait.Until(d => d.FindElement(By.Name("s")));

            searchBox.SendKeys("DevOps");

            var button = _wait.Until(d => d.FindElement(By.ClassName("search-submit")));

            button.Click();

            string title = _wait.Until(d => d.Title);

            Assert.AreEqual("Search Results for “DevOps” – writeabout.net", title);
        }

        [TestCase("Max")]
        [TestCase("1024x786")]
        [TestCase("360x640")]
        public void Samples_SimpleChromeTest(string windowSize)
        {
            ChangeBrowserSize(windowSize);

            var url = TestContext.Parameters["webAppUrl"];

            _driver.Navigate().GoToUrl(url);

            var searchBox = _wait.Until(d => d.FindElement(By.Name("s")));

            searchBox.SendKeys("DevOps");

            var button = _wait.Until(d => d.FindElement(By.ClassName("search-submit")));

            button.Click();

            string title = _wait.Until(d => d.Title);

            Assert.AreEqual("Search Results for “DevOps” – writeabout.net", title);
        }

        [TearDown]
        public void TearDown()
        {
            CleanUp();
        }
    }
}