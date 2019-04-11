using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace XSel.Samples
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    public class XBrowserTest<TWebDriver> : XSelTestBase where TWebDriver : IWebDriver, new()
    {
        [TestCase("1024x768")]
        public void Samples_XBrowserTest(string windowSize)
        {
            Initialize<TWebDriver>();

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