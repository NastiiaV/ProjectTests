using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.PageObject
{
    class Purchase : PageObjectBase
    {
        private static readonly By accessoriesButt = By.XPath("//div[@id='_desktop_top_menu']//li[@id='category-6']");
        private static readonly By stationeryButt = By.XPath("/html/body/main/section/div/div[1]/div[1]/ul/li[2]/ul/li[1]");
        private static readonly By notebookSelect = By.XPath("/html/body/main/section/div/div[2]/section/section/div[3]/div/div[1]/article[1]/div/a/img");
        private static readonly By addToCartButt = By.XPath("/html/body/main/section/div/div/section/div[1]/div[2]/div[2]/div[2]/form/div[2]/div/div[2]/button");
        private static readonly By cartButt = By.XPath("/html/body/main/header/nav/div/div/div[1]/div[2]/div[4]/div/div");
        private static readonly By toOrderButt = By.XPath("/html/body/main/section/div/div/section/div/div[2]/div[1]/div[2]/div/a");

        private static readonly By signOutButt = By.XPath("/html/body/main/header/nav/div/div/div[1]/div[2]/div[3]/div/a[1]");
        private static readonly By signInButt = By.XPath("/html/body/main/header/nav/div/div/div[1]/div[2]/div[3]/div/a/span");
        private static readonly By email = By.Name("email");
        private static readonly By password = By.Name("password");
        private static readonly By loginingButt = By.Id("submit-login");

        private static readonly By confirmingButt = By.Name("confirm-addresses");
        private static readonly By confirmDelivButt = By.Name("confirmDeliveryOption");
        private static readonly By paymentOpp = By.Id("payment-option-1");
        private static readonly By accessCheck = By.XPath("/html/body/section/div/section/div/div[1]/section[4]/div/form/ul/li/div[1]/span/input");
        private static readonly By purchaiseButt = By.XPath("/html/body/section/div/section/div/div[1]/section[4]/div/div[3]/div[1]/button");
        
        // /html/body/main/section/div/div/section/div/div[2]/div[1]/div[2]/div/a
        private static readonly By purchSuccess = By.XPath("//div[@class='col-md-12']//h3[@class='h1 card-title']");
        private static readonly By mainButt = By.XPath("/html/body/main/header/div[2]/div/div[1]/div[1]/a/img");

        public Purchase(IWebDriver driver) : base(driver)
        { }

        public Purchase SellectAccessory()
        {
            Driver.FindElement(accessoriesButt).Click();
            Driver.FindElement(stationeryButt).Click();
            Driver.FindElement(notebookSelect).Click();
            Driver.FindElement(addToCartButt).Click();
            //Driver.FindElement(toOrderButt).Click();
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Escape).Perform();


            return this;
        }

        public Purchase SigningIn(string testEmail, string testPassword)
        {
            if (Driver.FindElements(signOutButt).Any())
            {
                Driver.FindElement(signOutButt).Click();
            }
            Driver.FindElement(signInButt).Click();
            Driver.FindElement(email).SendKeys(text: testEmail);
            Driver.FindElement(password).SendKeys(text: testPassword);
            Driver.FindElement(loginingButt).Click();

            //try
            //{
            //    Driver.FindElement(signOutButt).Click();
            //}
            //catch (NoSuchElementException)
            //{
            //    Driver.FindElement(signInButt).Click();
            //    Driver.FindElement(email).SendKeys(text: testEmail);
            //    Driver.FindElement(password).SendKeys(text: testPassword);
            //    Driver.FindElement(loginingButt).Click();
            //}
            //Driver.FindElement(signInButt).Click();
            //Driver.FindElement(email).SendKeys(text: testEmail);
            //Driver.FindElement(password).SendKeys(text: testPassword);
            //Driver.FindElement(loginingButt).Click();

            return this;
        }

        public Purchase MakingOrder()
        {
            Driver.FindElement(mainButt).Click();
            Driver.FindElement(cartButt).Click();
            Driver.FindElement(toOrderButt).Click();
            Driver.FindElement(confirmingButt).Click();
            Driver.FindElement(confirmDelivButt).Click();
            Driver.FindElement(paymentOpp).Click();
            Driver.FindElement(accessCheck).Click();
            Driver.FindElement(purchaiseButt).Click();

            return this;
        }

        public bool isPurchSuccess()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(250));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            bool isOk = false;

            try
            {
                isOk = wait.Until(x => x.
              FindElements(purchSuccess).
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
