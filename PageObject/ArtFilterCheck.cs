using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.PageObject
{
    public class ArtFilter : PageObjectBase
    {
        private static readonly By artButton = By.XPath("/html/body/main/header/div[2]/div/div[1]/div[2]/div[1]/ul/li[3]/a");
        private static readonly By filterCheckBox = By.XPath("/html/body/main/section/div/div[1]/div[2]/div[2]/section[1]/ul/li/label/a");
        private static readonly By wantedItem = By.XPath("/html/body/main/section/div/div[1]/div[2]/div[2]/div/button");
        public ArtFilter(IWebDriver driver) : base(driver)
        { }

        public ArtFilter Goto(IWebDriver driver)
        {
            Driver.FindElement(artButton).Click();
            Driver.FindElement(filterCheckBox).Click();

            return this;
        }

        public bool isOk()
        {
            bool isOk = true;

            try
            {
                Driver.FindElement(wantedItem);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Driver not found such element");
                isOk = false;
            }

            return isOk;
        }
    }
}
