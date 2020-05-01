using System;
using OpenQA.Selenium;

namespace AutomationTests.PageObject
{
    public class SearchPage:PageObjectBase
    {
        private static readonly By search = By.Name("s");
        private static readonly By buttonSearch = By.XPath("//button[@type ='submit']");
        private static readonly By alertParagraph = By.XPath("//div[@id='js-product-list']//section[@id='content']");
        public SearchPage(IWebDriver driver) : base(driver)
        { }
        public SearchPage EnterData(string searchData)
        {
            Driver.FindElement(search).Clear();
            Driver.FindElement(search).Click();
            Driver.FindElement(search).SendKeys(searchData);
            Driver.FindElement(search).SendKeys(Keys.Tab);
            Driver.FindElement(buttonSearch).Click();
            return this;
        }
        public bool isSearchOk()
        {
            bool isSearchExist = false;

            try
            {
                Driver.FindElement(alertParagraph);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Driver not found such element");
                isSearchExist = true;
            }

            return isSearchExist;
        }
    }
}
