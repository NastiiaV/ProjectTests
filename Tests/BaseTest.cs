using OpenQA.Selenium.Chrome;
using System.IO;
using AutomationTests.PageObject;
using OpenQA.Selenium;
using NUnit.Framework;

namespace AutomationTests.Tests
{
    [TestFixture]
    class BaseTest
    {
        public readonly IWebDriver driver;
    }
}
