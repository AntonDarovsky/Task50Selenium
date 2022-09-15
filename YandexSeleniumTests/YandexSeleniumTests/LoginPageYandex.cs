using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace YandexSeleniumTests
{
    public class LoginPageYandex : BasePage
    {
        public static readonly By _loginField = By.Id("passp-field-login");

        public static readonly By _signInButton1 = By.CssSelector(".passp-sign-in-button");

        public static readonly By _passwordField = By.Id("passp-field-passwd");

        public static readonly By _passwordButton = By.CssSelector(".passp-sign-in-button");

        public static readonly By _mailSettingsButton = By.XPath("//*[contains(@class,'mail - SettingsButton')]");

       

        public LoginPageYandex(IWebDriver driver) : base(driver)
        {
        }
        
        public void Login(string login)
        {
            Driver.FindElement(_loginField).SendKeys(login);
            
            Driver.FindElement(_signInButton1).Click();

            Thread.Sleep(1000);
        }

        public void Password(string password)
        {
            
            Driver.FindElement(_passwordField).SendKeys(password);

            Driver.FindElement(_passwordButton).Click();

            Thread.Sleep(5000);
        }

        
    }
}
