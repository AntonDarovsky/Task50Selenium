using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YandexSeleniumTests;
using System;
using OpenQA.Selenium.Support.UI;

namespace YandexTests
{
    [TestClass]
    public class DowloadTest
    {
        [TestMethod]
        public void RefreshPageTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html";

            driver.Manage().Window.Maximize();

            driver.WaitForElement(By.Id("cricle-btn"), TimeSpan.FromMinutes(3)).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            var persentage = driver.FindElement(By.CssSelector(".percenttext"));

            Assert.IsTrue(persentage.Displayed, "element is not presented");

            var element = wait.Until(driver => persentage.Text.Contains("50%"));

            driver.Navigate().Refresh();

            driver.Quit();
        }
    }
}
