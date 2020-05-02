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

        
        //[TestCase(true)]
        public void Filter(bool isPositive)
        {
            ClothesCheck page = new ClothesCheck(driver);
            bool isOk = page.Goto().isFilterOk();
            Assert.That(isOk, Is.EqualTo(isPositive), $"Search is {(isOk ? "existed" : "not existed")} " +
                "but we expected opposite");
        }

        [TestCase(true)]
        public void ContactUsForm(bool isPositive)
        {
            ContactUsCheck page = new ContactUsCheck(driver);
            bool isOk = page.Goto(driver).isOk();
            Assert.That(isOk, Is.EqualTo(isPositive), $"About page {(isOk ? "existed" : "not existed")} " +
                "but we expected opposite");
        }

        [TestCase(true)]
        public void ArtFilters(bool isPositive)
        {
            ArtFilter page = new ArtFilter(driver);
            bool isOk = page.Goto(driver).isOk();
            Assert.That(isOk, Is.EqualTo(isPositive), $"Art filter {(isOk ? "existed" : "not existed")} " +
                "but we expected opposite");
        }

        [TestCase(true)]
        public void CurrencySwitch(bool isPositive)
        {
            CurrencySwitch page = new CurrencySwitch(driver);
            bool isOk = page.Goto(driver).isOk();
            Assert.That(isOk, Is.EqualTo(isPositive), $"Currency switch {(isOk ? "existed" : "not existed")} " +
                "but we expected opposite");
        }

        [Test]
        [Order(0)]
        public void LocalizationTest()
        {
            OriginalPage originalPage = new OriginalPage(driver);
            bool isSwitched = originalPage.SwitchLanguage().IsLangSwitched();
            Assert.That(isSwitched, Is.EqualTo(true), $"Language switch {(isSwitched ? "successfully" : "unsuccessfully")}");

            isSwitched = originalPage.SwitchLanguage().IsLangSwitched();
            Assert.That(isSwitched, Is.EqualTo(true), 
                $"Language switch {(isSwitched ? "successfully" : "unsuccessfully")}");
        }

        [Test]
        [Order(1)]
        public void FilterFunctionalTest()
        {
            OriginalPage originalPage = new OriginalPage(driver);
            originalPage.SwitchLanguage();
            AccessoriesPage accessoriesPage = 
                originalPage.OpenAccessoriesPage()
                    .PointHomeAccesorries()
                    .PointStationery();
            bool isFilterWork = accessoriesPage.IsFilterOn();
            Assert.That(isFilterWork, Is.EqualTo(true), 
                $"Filter is turned on {(isFilterWork ? "successfully" : "unsuccessfully")}");
        }
    } 
}
