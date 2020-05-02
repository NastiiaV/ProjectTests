using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace AutomationTests.PageObject
{
    class AccessoriesPage : PageObjectBase
    {
        private static readonly By homeAccesorriesUk = 
            By.XPath(@"//a[@href='http://52.177.12.77:8080/uk/6-accessories?q=%D0%9A%D0%B0%D1%82%D0%B5%D0%B3%D0%BE%D1%80%D1%96%D1%97-Home+Accessories']");
        private static readonly By homeAccesorriesEn = 
            By.XPath(@"//a[@href='http://52.177.12.77:8080/en/6-accessories?q=Categories-Home+Accessories']");
        private static readonly By stationeryUk =
            By.XPath(@"//a[@href='http://52.177.12.77:8080/uk/6-accessories?q=%D0%9A%D0%B0%D1%82%D0%B5%D0%B3%D0%BE%D1%80%D1%96%D1%97-Home+Accessories-Stationery']");
        private static readonly By stationeryEn =
            By.XPath(@"//a[@href='http://52.177.12.77:8080/en/6-accessories?q=Categories-Home+Accessories-Stationery']");
        private static readonly By btnClear =
            By.XPath(@"//button[@class='btn btn-tertiary js-search-filters-clear-all']");
        private readonly string lang;
        public AccessoriesPage(IWebDriver webDriver, string lang = "uk") : base(webDriver)
        {
            this.lang = lang;
        }
        
        public AccessoriesPage PointHomeAccesorries()
        {
            if (lang == "uk")
                Driver.FindElement(homeAccesorriesUk).Click();
            else
                Driver.FindElement(homeAccesorriesEn).Click();

            return this;
        }

        public AccessoriesPage PointStationery()
        {
            if (lang == "uk")
                Driver.FindElement(stationeryUk).Click();
            else
                Driver.FindElement(stationeryEn).Click();

            return this;
        }

        public bool IsFilterOn()
        {
            Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.Zero;
            wait = new WebDriverWait(Driver, System.TimeSpan.FromMilliseconds(250));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            bool isFilterOn = false;

            try
            {
                isFilterOn = wait.Until(x =>
                        x.FindElements(btnClear).Any());
            }
            catch (WebDriverException)
            {
                System.Console.WriteLine("Filter have not been turned on");
            }

            return isFilterOn;
        }
    }
}
