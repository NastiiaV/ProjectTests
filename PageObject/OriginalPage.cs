using OpenQA.Selenium;

namespace AutomationTests.PageObject
{
    class OriginalPage : PageObjectBase 
    {
        private static readonly By langMenu = By.XPath(@"//div[@class = 'language-selector-wrapper']");
        private static readonly By html = By.XPath(@"/html");
        private bool isSwitched = false;

        public OriginalPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public OriginalPage SwitchLanguage()
        {
            string language = Driver.FindElement(html).GetAttribute("lang");
            Driver.FindElement(langMenu).Click();
            if(language == "uk")
                Driver.FindElement(langMenu).FindElement(By.XPath($"//a[@data-iso-code = 'en']")).Click();
            else
                Driver.FindElement(langMenu).FindElement(By.XPath($"//a[@data-iso-code = 'uk']")).Click();
            isSwitched = true;

            return this;
        }

        public bool IsLangSwitched()
        {
            return isSwitched;
        }
    }
}
