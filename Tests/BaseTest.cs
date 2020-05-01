using OpenQA.Selenium.Chrome;
using System.IO;
using AutomationTests.PageObject;
using OpenQA.Selenium;
using NUnit.Framework;

namespace AutomationTests.Tests
{
    [TestFixture]
    class BaseTest
    {
        public readonly IWebDriver driver;
        public BaseTest()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = PageObjectBase.implicitWait;
            driver.Navigate().GoToUrl(PageObjectBase.url);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();

        //[TestCase(true, "shirt")]
        //[TestCase(false, "s")]
        public void Search(bool isPositive, string someSearch)
        {
            SearchPage searchPage = new SearchPage(driver);
            bool isSearchExist = searchPage.EnterData(someSearch).isSearchOk();
            Assert.That(isSearchExist, Is.EqualTo(isPositive), $"Search is {(isSearchExist ? "existed" : "not existed")} " +
                "but we expected opposite");
        }

        [TestCase(false, "t@gmail.com")]
        //[TestCase(true, "new@gmail.com")]

        public void SubscribeValid(bool isPositive, string email)
        {
            Subscribe subs = new Subscribe(driver);
            bool isDataOk = subs.EnterData(email).IsDataExist();
            Assert.That(isDataOk,
                Is.EqualTo(isPositive), $"Email was validated {(isDataOk ? "successfully" : "unseccessfully")} " +
                "but we expected opposite");
        }
    }
    
}
