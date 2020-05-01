using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.PageObject
{
    public abstract class PageObjectBase
    {
        protected readonly IWebDriver Driver;
        public static readonly string url = "http://52.177.12.77:8080";

        protected PageObjectBase(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
