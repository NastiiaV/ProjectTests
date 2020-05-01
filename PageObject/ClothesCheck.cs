using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.PageObject
{
    public class ClothesCheck:PageObjectBase
    {

        private static readonly By buttonCl = By.XPath("//div[@id='_desktop_top_menu']//li[@id='category-3']");
        private static readonly By bWomen = By.XPath("//*[@id='left-column']/div[1]/ul/li[2]/ul/li[2]");
        private static readonly By filter = By.XPath("//div[@id='search_filters']//label");
        
        private static readonly By parag= By.XPath("//section[@id='js - active - search - filters']");

        public ClothesCheck(IWebDriver driver) : base(driver)
        { }

        public ClothesCheck Goto()
        {
            Driver.FindElement(buttonCl).Click();
            Driver.FindElement(bWomen).Click();
            Driver.FindElement(filter).Click();

            return this;
        }

        public bool isFilterOk()
        {
            bool isOk = false;

            try
            {
                Driver.FindElement(parag);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Driver not found such element");
                isOk = true;
            }

            return isOk;
        }
    }
}
