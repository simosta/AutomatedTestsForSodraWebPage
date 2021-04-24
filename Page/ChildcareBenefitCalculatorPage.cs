using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Sodra.Page
{
    public class ChildcareBenefitCalculatorPage : BasePage
    {
        private const string PageAddress = "https://www.sodra.lt/en/calculators/maternity_paternity_calculator#step1";
        private static IWebElement _twoYearRadio => Driver.FindElement(By.CssSelector(".radio-hold:nth-child(2) > .income_change:nth-child(2)"));
        private static IWebElement _gotoSecondStepButton => Driver.FindElement(By.CssSelector(".btn-hold:nth-child(6) > .btn-blue"));
        private static IWebElement _incomeInputField => Driver.FindElement(By.XPath("//input[@name='income_self']"));
        private static IWebElement _gotoThirdStepButton => Driver.FindElement(By.CssSelector(".btn-hold:nth-child(9) > .btn-blue"));
        private static IWebElement _additionalIncomeInputfield => Driver.FindElement(By.Id("monthincome"));
        private static IWebElement _gotoResultButton => Driver.FindElement(By.CssSelector(".calc_but"));
        private static IWebElement _calculatedBenefitResult => Driver.FindElement(By.CssSelector("#sodra-calc > div > div:nth-child(5) > div.calc_results > div.table-responsive > table > tbody > tr > td.text-center.calc_results_red"));
        private static IWebElement _resetButton => Driver.FindElement(By.CssSelector("#sodra-calc > div > div:nth-child(5) > div.row > div:nth-child(1) > div > div:nth-child(4) > a"));
        public ChildcareBenefitCalculatorPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToChildcareBenefitCalculatorPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }
        public void SelectDuration(bool twoyear)
        {
            if (twoyear)
                ClickTwoYearRadio();
        }
        public void ClickGoToSecondStepButton()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(_gotoSecondStepButton)).Click();
        }

        public void EnterIncomeAmount(string income)
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(_incomeInputField)).Clear();
            _incomeInputField.SendKeys(income);
        }
        public void ClickGoToThirdStepButton()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(_gotoThirdStepButton)).Click();
        }
        public void EnterAdditionalIncomeAmount(string income)
        {
            GetWait(20).Until(ExpectedConditions.ElementToBeClickable(_additionalIncomeInputfield)).Clear();
            _additionalIncomeInputfield.SendKeys(income);

        }
        public void ClickGoToResultButton()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(_gotoResultButton)).Click();
        }

        public void VerifyCalculatedBenefitIsCorrect(string result)
        {
            Assert.IsTrue(_calculatedBenefitResult.Text.Contains(result), $"{_calculatedBenefitResult.Text} instead of {result}");
            ResetCalculator();
        }
        private void ClickTwoYearRadio()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(_twoYearRadio)).Click();
        }

        private void ResetCalculator()
        {
            GetWait(20).Until(ExpectedConditions.ElementToBeClickable(_resetButton)).Click();
        }

    }
}
