using OpenQA.Selenium;

namespace AutomationTests.PageObject
{
    class LogInPage : PageObjectBase
    {
        private static readonly By signUpEn = 
            By.XPath(@"//a[@href = 'http://52.177.12.77:8080/en/login?create_account=1']");
        private static readonly By signUpUk =
            By.XPath(@"//a[@href = 'http://52.177.12.77:8080/uk/login?create_account=1']");
        private readonly string lang;

        public LogInPage(IWebDriver webDriver, string lang = "uk") : base(webDriver)
        {
            this.lang = lang;
        }

        public SignUpPage ClickOnMakeAccount()
        {
            if (lang == "uk")
                Driver.FindElement(signUpUk).Click();
            else
                Driver.FindElement(signUpEn).Click();

            return new SignUpPage(Driver);
        }
    }
}
