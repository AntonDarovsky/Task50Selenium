using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YandexSeleniumTests;
using System;

namespace YandexTests
{
    [TestClass]

    public class UserWaiter
    {
        [TestMethod]

        public void WaitUser()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://demo.seleniumeasy.com/dynamic-data-loading-demo.html";

            driver.Manage().Window.Maximize();

            driver.WaitForElement(By.Id("save"), TimeSpan.FromMinutes(3)).Click();

            var element = driver.WaitForElement(By.Id("loading"), TimeSpan.FromMinutes(3));

            Assert.IsTrue(element.Displayed, "element is not loading");

            driver.Close();
        }
    }
}
