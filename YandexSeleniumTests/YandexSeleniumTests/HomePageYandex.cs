using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace YandexSeleniumTests
{
    public class HomePageYandex : BasePage
    {
        public static readonly By _LoginButton1 = By.CssSelector(".user__login-link");
        public static readonly By _LoginButton2 = By.ClassName("Button2");
        public HomePageYandex(IWebDriver driver) : base(driver)
        {
        }

        public void ClickLoginButton()
        {
            Driver.FindElement(_LoginButton1).Click();
        }

        public LoginPageYandex GoToLoginPage()
        {
            Driver.FindElement(_LoginButton2).Click();
            return new LoginPageYandex(Driver);
        }
    }
}
