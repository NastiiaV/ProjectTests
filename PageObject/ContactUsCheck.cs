using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.PageObject
{
    public class ContactUsCheck : PageObjectBase
    {
        private static readonly By contactUsButton = By.XPath("/html/body/main/header/nav/div/div/div[1]/div[1]/div/div/a");
        private static readonly By buttonCl = By.XPath("/html/body/main/section/div/div[2]/section/section/section/form/section/div[1]/div/h3");
        public ContactUsCheck(IWebDriver driver) : base(driver)
        { }

        public ContactUsCheck Goto(IWebDriver driver)
        {
            Driver.FindElement(contactUsButton).Click();

            return this;
        }

        public bool isOk()
        {
            bool isOk = true;

            try
            {
                Driver.FindElement(buttonCl);
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
