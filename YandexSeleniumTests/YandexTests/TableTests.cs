using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YandexSeleniumTests;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace YandexTests
{
    [TestClass]
    public class TableTest
    {
        static readonly IWebDriver driver = new ChromeDriver();
    
        [TestMethod]

        public void TableListOfUsers()
        {
            driver.Url = "https://demo.seleniumeasy.com/table-sort-search-demo.html";
            driver.Manage().Window.Maximize();

            SelectElement select = new SelectElement(driver.FindElement(By.XPath("//*[@id='example_length']/label/select")));

            select.SelectByValue("10");

            TablePage tablePage = new TablePage(driver);
            List<List<string>> container = new List<List<string>>();
            List <List<string>> tableRows = tablePage.GetTableRows(container);

            var normalizedRows = tablePage.FilterRows(tableRows, 57, 200000);

            Console.WriteLine(String.Format("{0,-30} {1,-30} {2,-30} ", "Name", "Position", "Office"));
            foreach (var tableRow in normalizedRows)
            {
                Console.WriteLine(String.Format("{0,-30} {1,-30} {2,-30} ", tableRow[0], tableRow[1], tableRow[2]));
            }
            Console.WriteLine("\nTotal found: {0}", normalizedRows.Count);

            driver.Quit();
        }
        
    }
}
