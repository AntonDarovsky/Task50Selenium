using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using YandexSeleniumTests;

namespace YandexTests
{
    [TestFixture]
    public class AlertTests
    {
        public IWebDriver driver;

        [SetUp]
        public void Open()
        {
            driver = new ChromeDriver();

            driver.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";

            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }

        [Test]
        public void JavaScriptAlertBoxTest()
        {
         string expectedText = "I am an alert box!";

         driver.WaitForElement(By.CssSelector(".btn-default"), TimeSpan.FromMinutes(3)).Click();

         string alertMessage = driver.SwitchTo().Alert().Text;
                        
         Assert.AreEqual(expectedText, alertMessage, "Wrong Alert!");

         driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void JavaScriptConfirmBoxTest1()
        {
            string expectedText = "Press a button!";

            driver.WaitForElement(By.CssSelector(".btn-lg"), TimeSpan.FromMinutes(3)).Click();

            string alertMessage = driver.SwitchTo().Alert().Text;

            Assert.AreEqual(expectedText, alertMessage, "Wrong Alert!");

            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void JavaScriptConfirmBoxTest2()
        {
            string expectedText = "Press a button!";

            driver.WaitForElement(By.CssSelector(".btn-lg"), TimeSpan.FromMinutes(3)).Click();

            string alertMessage = driver.SwitchTo().Alert().Text;

            Assert.AreEqual(expectedText, alertMessage, "Wrong Alert!");

            driver.SwitchTo().Alert().Dismiss();
        }
    }
}
