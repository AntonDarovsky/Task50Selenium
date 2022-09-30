using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using YandexSeleniumTests;

namespace YandexTests
{
    [TestClass]
    public class YandexLoginTests
    {
        [TestMethod]
        [DataRow("antonantonov972", "Antongekaleo97")]
        [DataRow("antonDD97", "Qazwsxe1133")]
        public void LoginYandexTest(string login, string password)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://www.yandex.com/";

            driver.Manage().Window.Maximize();

            HomePageYandex homeYandex = new HomePageYandex(driver);

            homeYandex.ClickLoginButton();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            LoginPageYandex loginPageYandex = homeYandex.GoToLoginPage();

            loginPageYandex.Login(login);

            loginPageYandex.Password(password);


            var element = driver.WaitForElement(By.CssSelector(".user-account__name"), TimeSpan.FromMinutes(2));


            Assert.IsTrue(element.Displayed, "Wrong page!");

            driver.Quit();    
        }
    }
}
