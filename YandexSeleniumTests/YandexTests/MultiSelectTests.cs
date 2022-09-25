using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace YandexTests
{
    [TestClass]
    public class MultiSelectTests
    {
        [TestMethod]

        public void MultiSelectTest1()
        {
            string[] states = { "California", "Florida", "New York" };

            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";

            driver.Manage().Window.Maximize();

            SelectElement select = new SelectElement(driver.FindElement(By.Id("multi-select")));

            Assert.IsTrue(select.IsMultiple, "The select doesn't contains multiple selection");

            foreach (var state in states)
            {
                select.SelectByValue(state);
            }

            select.DeselectAll();

            driver.Close();
 
        }
    }
}
