using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.PageObject
{
    public enum SocialTitle
    {
        Male,
        Female
    }

    class SignUpPage : PageObjectBase
    {
        private static readonly By maleRadioBtn = 
            By.XPath(@"(//input[@name='id_gender'])[1]");
        private static readonly By femaleRadioBtn =
            By.XPath(@"(//input[@name='id_gender'])[2]");
        private static readonly By fieldFirstName =
            By.XPath(@"//input[@name='firstname']");
        private static readonly By fieldLastName = 
            By.XPath(@"//input[@name='lastname']");
        private static readonly By fieldEmail = 
            By.XPath(@"//input[@class='form-control' and @type='email']");
        private static readonly By fieldPassword =
            By.XPath(@"//input[@name = 'password']");
        private static readonly By fieldBirthDay =
            By.XPath(@"//input[@name = 'birthday']");
        private static readonly By offersCheckBox =
            By.XPath(@"(//span[@class= 'custom-checkbox'])[1]");
        private static readonly By newsletterCheckBox =
            By.XPath(@"(//span[@class= 'custom-checkbox'])[2]");
        private static readonly By agreeCheckBox =
            By.XPath(@"(//span[@class= 'custom-checkbox'])[3]");
        private static readonly By saveBtn =
            By.XPath(@"//button[@class = 'btn btn-primary form-control-submit float-xs-right']");
        private static readonly By account =
            By.XPath(@"//a[@class='account']");

        public SignUpPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public SignUpPage InputSocialTitle(SocialTitle socialTitle)
        {
            switch(socialTitle)
            {
                case SocialTitle.Male:
                    Driver.FindElement(maleRadioBtn).Click();
                    break;
                case SocialTitle.Female:
                    Driver.FindElement(femaleRadioBtn).Click();
                    break;
            }
            return this;
        }

        public SignUpPage InputFirstName(string firstName)
        {
            Driver.FindElement(fieldFirstName).Click();
            Driver.FindElement(fieldFirstName).SendKeys(firstName);
            Driver.FindElement(fieldFirstName).SendKeys(Keys.Tab);

            return this;
        }

        public SignUpPage InputLastName(string lastName)
        {
            Driver.FindElement(fieldLastName).Click();
            Driver.FindElement(fieldLastName).SendKeys(lastName);
            Driver.FindElement(fieldLastName).SendKeys(Keys.Tab);

            return this;
        }

        public SignUpPage InputEmail(string email)
        {
            Driver.FindElement(fieldEmail).Click();
            Driver.FindElement(fieldEmail).SendKeys(email);
            Driver.FindElement(fieldEmail).SendKeys(Keys.Tab);

            return this;
        }

        public SignUpPage InputPassword(string password)
        {
            Driver.FindElement(fieldPassword).Click();
            Driver.FindElement(fieldPassword).SendKeys(password);
            Driver.FindElement(fieldPassword).SendKeys(Keys.Tab);

            return this;
        }

        public SignUpPage InputBirthDay(string birthDay)
        {
            Driver.FindElement(fieldBirthDay).Click();
            Driver.FindElement(fieldBirthDay).SendKeys(birthDay);
            Driver.FindElement(fieldBirthDay).SendKeys(Keys.Tab);

            return this;
        }

        public SignUpPage TagOffers(bool isTagged)
        {
            if(isTagged == true)
                Driver.FindElement(offersCheckBox).Click();

            return this;
        }

        public SignUpPage TagNewsLetter(bool isTagged)
        {
            if (isTagged == true)
                Driver.FindElement(newsletterCheckBox).Click();

            return this;
        }

        public SignUpPage TagAgree(bool isTagged)
        {
            if(isTagged == true)
                Driver.FindElement(agreeCheckBox).Click();

            return this;
        }

        public SignUpPage ClickSaveButton()
        {
            Driver.FindElement(saveBtn).Click();

            return new SignUpPage(Driver);
        }

        public bool IsAccountCreated()
        {
            Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.Zero;
            wait = new WebDriverWait(Driver, System.TimeSpan.FromMilliseconds(250));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            bool isAccountCreated = false;

            try
            {
                isAccountCreated = wait.Until(x =>
                        x.FindElements(account).Any());
            }
            catch (WebDriverException)
            {
                System.Console.WriteLine("Account have not created");
            }

            return isAccountCreated;
        }
    }
}
