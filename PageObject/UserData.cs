using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObject
{
    class UserData : PageObjectBase
    {

        private static readonly By signOutButt = By.XPath("/html/body/main/header/nav/div/div/div[1]/div[2]/div[3]/div/a[1]");
        private static readonly By signInButt = By.XPath("/html/body/main/header/nav/div/div/div[1]/div[2]/div[3]/div/a/span");
        private static readonly By email = By.Name("email");
        private static readonly By password = By.Name("password");
        private static readonly By loginingButt = By.Id("submit-login");

        private static readonly By userDataButt = By.XPath("/html/body/main/footer/div[2]/div/div[1]/div[2]/ul/li[1]/a");
        private static readonly By nameEdit = By.XPath("/html/body/main/section/div/div/section/section/form/section/div[2]/div[1]/input");
        private static readonly By passEdit = By.XPath("/html/body/main/section/div/div/section/section/form/section/div[5]/div[1]/div/input");
        private static readonly By newPass = By.XPath("/html/body/main/section/div/div/section/section/form/section/div[6]/div[1]/div/input");
        private static readonly By confirmButt = By.XPath("/html/body/main/section/div/div/section/section/form/footer/button");
        private static readonly By iAgreeButt = By.XPath("/html/body/main/section/div/div/section/section/form/section/div[10]/div[1]/span/label/input");

        private static readonly By updateSuccess = By.XPath("/html/body/main/section/div/div/section/section/aside/div/article");

        public UserData(IWebDriver driver) : base(driver)
        {
        }

        public UserData SigningIn(string testEmail, string testPassword)
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

        public UserData DataUpdating(string testPassword)
        {
            Driver.FindElement(userDataButt).Click();
            Driver.FindElement(nameEdit).Clear();
            Driver.FindElement(nameEdit).SendKeys(text: "Test");
            Driver.FindElement(passEdit).SendKeys(text: testPassword);
            Driver.FindElement(newPass).SendKeys(text: testPassword);
            Driver.FindElement(iAgreeButt).Click();
            Driver.FindElement(confirmButt).Click();
            return this;
        }

        public bool isDataUpdated()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(250));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            bool isOk = false;

            try
            {
                isOk = wait.Until(x => x.
              FindElements(updateSuccess).
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
