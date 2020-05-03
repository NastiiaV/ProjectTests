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

        [TestCase(true, "shirt")]
        [TestCase(false, "s")]
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


        [TestCase("testemail123123@gmail.com", "testpass",true)]
        public void PurchaseTest(string testEmail, string testPassword, bool isPositive)
        {
            Purchase purch = new Purchase(driver);
            purch.SigningIn(testEmail, testPassword);
            purch.SellectAccessory();
            bool isDataOk = purch.MakingOrder().isPurchSuccess();
            Assert.That(isDataOk,
               Is.EqualTo(isPositive), $"Purchase was validated {(isDataOk ? "successfully" : "unseccessfully")} " +
               "but we expected opposite");
        }

           [TestCase("testemail123123@gmail.com", "testpass",true)]
        public void AccountsViewTest(string testEmail, string testPassword, bool isPositive)
        {
            AccountsView acc = new AccountsView(driver);
            acc.SigningIn(testEmail, testPassword);
            bool isDataOk = acc.AccountsViewing().isAccountsView();
            Assert.That(isDataOk,
               Is.EqualTo(isPositive), $"Accounts list was validated {(isDataOk ? "successfully" : "unseccessfully")} " +
               "but we expected opposite");
        }
    }
    
}
