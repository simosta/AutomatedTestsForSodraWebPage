using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Sodra.Page
{
    public class ChildMaitenanceCalculatorPage : BasePage
    {
        private const string PageAddress = "https://www.sodra.lt/en/calculators/child_support";
        private IWebElement _adjudgedAmountEUR => Driver.FindElement(By.CssSelector("#react_child_support_root > div > div:nth-child(2) > div:nth-child(3) > div.field_holder > input"));
        private IWebElement _payedAmountEUR => Driver.FindElement(By.CssSelector("#react_child_support_root > div > div:nth-child(2) > div:nth-child(3) > div:nth-child(2) > div > input"));
        private IWebElement _calculateMaitenanceButton => Driver.FindElement(By.CssSelector("#react_child_support_root > div > div:nth-child(2) > div.btn-hold > div"));
        private IWebElement _calculatedMaitenanceResult => Driver.FindElement(By.CssSelector("#react_child_support_root > div > div:nth-child(2) > div:nth-child(5) > div > div.calc_results > div.calc_results_text > span"));
        private IWebElement _beforeEuros => Driver.FindElement(By.CssSelector(".radiomark:nth-child(2)"));
        private IWebElement _adjudgedAmountLT => Driver.FindElement(By.CssSelector("#react_child_support_root > div > div:nth-child(2) > div:nth-child(2) > div.col-md-6.nopad > div > input"));

        public ChildMaitenanceCalculatorPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToChildMaitenanceCalculatorPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }
        public void SelectDateBeforeEuros()
        {
            if (!_beforeEuros.Selected)
            {
                _beforeEuros.Click();
            }
        }

        public void InputMaitenanceAmountsAdjudgedInEuros(string adjudged, string debtor)
        {
            InputAdjudgedAmountInEuros(adjudged);
            InputPayedAmountInEuros(debtor);
        }
        public void InputMaitenanceAmountAdjudgedInLitai(string adjudged, string debtor)
        {
            InputAdjudgedAmountInLitai(adjudged);
            InputPayedAmountInEuros(debtor);
        }
        public void ClickCalculateMaitenanceButton()
        {
            _calculateMaitenanceButton.Click();
        }

        public void VerifyIfMaitenanceAmountCorrect(string result)
        {
            Assert.AreEqual(result, _calculatedMaitenanceResult.Text, $"{_calculatedMaitenanceResult.Text} instead of {result}");
        }

        private void InputAdjudgedAmountInLitai(string litai)
        {
            _adjudgedAmountLT.Clear();
            _adjudgedAmountLT.SendKeys(litai);
        }
        private void InputAdjudgedAmountInEuros(string euros)
        {
            _adjudgedAmountEUR.Clear();
            _adjudgedAmountEUR.SendKeys(euros);
        }
        private void InputPayedAmountInEuros(string euros)
        {
            _payedAmountEUR.Clear();
            _payedAmountEUR.SendKeys(euros);
        }
    }
}
