using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObject
{
    class AccountsView : PageObjectBase
    {
        private static readonly By signOutButt = By.XPath("/html/body/main/header/nav/div/div/div[1]/div[2]/div[3]/div/a[1]");
        private static readonly By signInButt = By.XPath("/html/body/main/header/nav/div/div/div[1]/div[2]/div[3]/div/a/span");
        private static readonly By email = By.Name("email");
        private static readonly By password = By.Name("password");
        private static readonly By loginingButt = By.Id("submit-login");
        private static readonly By accountsButt = By.XPath("/html/body/main/footer/div[2]/div/div[1]/div[2]/ul/li[3]/a");
        private static readonly By accountsList = By.Id("content");
        

        public AccountsView(IWebDriver driver) : base(driver)
        {
        }

        public AccountsView SigningIn(string testEmail, string testPassword)
        {
            if (Driver.FindElements(signOutButt).Any())
            {
                Driver.FindElement(signOutButt).Click();
            }
            Driver.FindElement(signInButt).Click();
            Driver.FindElement(email).SendKeys(text: testEmail);
            Driver.FindElement(password).SendKeys(text: testPassword);
            Driver.FindElement(loginingButt).Click();
            return this;
        }

        public AccountsView AccountsViewing()
        {
            Driver.FindElement(accountsButt).Click();
            return this;
        }

        public bool isAccountsView()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(250));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            bool isOk = false;

            try
            {
                isOk = wait.Until(x => x.
              FindElements(accountsList).
              Any());
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
