using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;

namespace YandexSeleniumTests
{
   public class TablePage: BasePage
    {
        public TablePage(IWebDriver driver): base(driver)
        {
        }

        public List<List<string>> GetTableRows(List<List<string>> container)
        {
            var table = Driver.FindElement(By.XPath("//*[@id='example']"));
            IWebElement nextButton = Driver.FindElement(By.Id("example_next"));

            bool isNextButtonDisabled = nextButton.GetAttribute("class")
                .Split(" ")
                .ToList()
                .Contains("disabled");

            List<IWebElement> tableRows = new List<IWebElement>(table.FindElements(By.CssSelector("tbody>tr")));

            List<List<string>> tableCells = tableRows
                .ConvertAll((row) =>
                {
                    var rowData = new List<IWebElement>(row.FindElements(By.TagName("td")))
                        .ConvertAll((cell) => cell.Text);

                    return rowData;
                }
                 )
                .ToList();

            List<List<string>> nextContainer = container.Concat(tableCells).ToList();

            return !isNextButtonDisabled ? GetNextPageRow(nextButton, nextContainer) : nextContainer;
        }

        public  List<List<string>> GetNextPageRow(IWebElement nextButton, List<List<string>> container)
        {
            nextButton.Click();

            return GetTableRows(container);
        }

        public List<List<string>> FilterRows(List<List<string>> rows, int minAge, int maxSalary)
        {
            static string trimCell(string str)
            {
                return Regex.Replace(str, @"\D", String.Empty);
            };

            var elems =
                from row in rows
                where Int32.Parse(row[3]) > minAge && Int32.Parse(trimCell(row[5])) <= maxSalary
                select row;

            return elems.ToList();
        }
    }
}
