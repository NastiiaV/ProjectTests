using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.PageObject
{
    public class CurrencySwitch : PageObjectBase
    {
        private static readonly By currencyDropdown = By.XPath("/html/body/main/header/nav/div/div/div[1]/div[2]/div[2]/div/button/span");
        private static readonly By eurButton = By.XPath("/html/body/main/header/nav/div/div/div[1]/div[2]/div[2]/div/ul/li[1]/a");
        private static readonly By priceTag = By.XPath("/html/body/main/section/div/div/section/section/section/div/article[1]/div/div[1]/div/span[5]");
        public CurrencySwitch(IWebDriver driver) : base(driver)
        { }

        public CurrencySwitch Goto(IWebDriver driver)
        {
            Driver.FindElement(currencyDropdown).Click();
            Driver.FindElement(eurButton).Click();

            return this;
        }

        public bool isOk()
        {
            string x = Driver.FindElement(priceTag).GetAttribute("innerHTML");

            return x[0] == '€';
        }
    }
}
