using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;

namespace Sodra.Page
{
    public class UnemployementBenefitCalculatorPage : BasePage
    {
        private const string PageAddress = "https://www.sodra.lt/en/calculators/unemployment_benefit_calculator";
        private static IWebElement _unemployementDateField => Driver.FindElement(By.Id("date_unemployed"));
        private static IWebElement _averageMonthlyBrutoSalaryField => Driver.FindElement(By.Name("average_salary_one"));
        private static IWebElement _calculateButton => Driver.FindElement(By.CssSelector("#calculator_form > div.form-group.last_group > div > button"));
        private static IWebElement _totalAmountpayed => Driver.FindElement(By.CssSelector(".calc_results_red:nth-child(2)"));

        public UnemployementBenefitCalculatorPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToUnemployementCalculator()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void EnterUnemployementDate(string date)
        {
            Actions action = new Actions(Driver);
            action.SendKeys(_unemployementDateField, date);
            action.Build().Perform();
        }

        public void EnterAverageMonthlyBrutoSalary(string salary)
        {
            _averageMonthlyBrutoSalaryField.Clear();
            _averageMonthlyBrutoSalaryField.SendKeys(salary);
        }

        public void ClickCalculateButton()
        {
            _calculateButton.Click();
        }
        
        public void VerifyTotalAmountPayed(string result)
        {
            Assert.IsTrue(_totalAmountpayed.Text.Contains(result), $"Expected {result}, actual {_totalAmountpayed.Text}");
        }

    }
}
