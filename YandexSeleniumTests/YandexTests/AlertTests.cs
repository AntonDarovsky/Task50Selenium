using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YandexSeleniumTests;
using System;


namespace YandexTests
{
    [TestClass]
    public class AlertTests
    {
        [TestMethod]

        public void JavaScriptAlertBox()
        {
            string expectedText = "I am an alert box!";

            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";

            driver.Manage().Window.Maximize();

            driver.WaitForElement(By.CssSelector(".btn-default"), TimeSpan.FromMinutes(3)).Click();

            string alertMessage = driver.SwitchTo().Alert().Text;
                        
            Assert.AreEqual(expectedText, alertMessage);

            driver.SwitchTo().Alert().Accept();
                
           driver.Close();

        }

        [TestMethod]

        public void JavaScriptConfirmBox1()
        {
            string expectedText = "Press a button!";

            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";

            driver.Manage().Window.Maximize();

            driver.WaitForElement(By.CssSelector(".btn-lg"), TimeSpan.FromMinutes(3)).Click();

            string alertMessage = driver.SwitchTo().Alert().Text;

            Assert.AreEqual(expectedText, alertMessage);

            driver.SwitchTo().Alert().Accept();

            driver.Close();

        }

        [TestMethod]

        public void JavaScriptConfirmBox2()
        {
            string expectedText = "Press a button!";

            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";

            driver.Manage().Window.Maximize();

            driver.WaitForElement(By.CssSelector(".btn-lg"), TimeSpan.FromMinutes(3)).Click();

            string alertMessage = driver.SwitchTo().Alert().Text;

            Assert.AreEqual(expectedText, alertMessage);

            driver.SwitchTo().Alert().Dismiss();

            driver.Close();

        }
    }
}
