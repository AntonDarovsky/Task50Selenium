using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using YandexSeleniumTests;

namespace YandexTests
{
    [TestClass]
    public class YandexLoginTests
    {
        [TestMethod]
        public void LoginYandexTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://www.yandex.com/";

            driver.Manage().Window.Maximize();

            HomePageYandex homeYandex = new HomePageYandex(driver);

            homeYandex.ClickLoginButton();

            LoginPageYandex loginPageYandex = homeYandex.GoToLoginPage();

            loginPageYandex.Login("antonantonov972");

            loginPageYandex.Password("Antongekaleo97");

            
            var element = driver.FindElement(By.CssSelector(".user-account__name"));


            Assert.IsTrue(element.Displayed, "Wrong page!");

            driver.Close();
        }
    }
}
