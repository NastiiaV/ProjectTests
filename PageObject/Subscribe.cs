using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.PageObject
{
    public class Subscribe:PageObjectBase
    {
        private static readonly By subscribeButton = By.Name("submitNewsletter");
        private static readonly By emailInput = By.Name("email");
        private static readonly By isEmailOkDiv = By.XPath("//div[@class='col-xs-12']//p[@class='alert alert-success']");

        public Subscribe(IWebDriver driver) : base(driver)
        { }

        public Subscribe EnterData(string email)
        {
            Driver.FindElement(emailInput).Click();
            Driver.FindElement(emailInput).Clear();
            Driver.FindElement(emailInput).SendKeys(email);
            Driver.FindElement(emailInput).SendKeys(Keys.Tab);
            Driver.FindElement(subscribeButton).Click();
            return this;
            
        }

        public bool IsDataExist()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;


            wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(250));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            bool isOk = false;
            try
            {
                isOk = wait.Until(x => x.
              FindElements(isEmailOkDiv).
              Any());
                //Driver.FindElement(emailInput).SendKeys(password);
                //Driver.FindElement(emailInput).SendKeys(Keys.Tab);
                //Driver.FindElement(subscribeButton).Click();
            }

            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Driver not found such element");
            }

            Driver.Manage().Timeouts().ImplicitWait = implicitWait;
            return isOk;

        }

    }
}
