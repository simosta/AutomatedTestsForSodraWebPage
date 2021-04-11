using NUnit.Framework;

namespace Sodra.Test
{
    public class ChildcareBenefitCalculatorTest : BaseTest
    {
        [TestCase(false, "1000", "0", "775.80", TestName = "Test1000EurosNoAdditionalIncomeOneYear")]
        [TestCase(true, "1000", "0", "543.10", TestName = "Test1000EurosNoAdditionalIncomeTwoYear")]
        [TestCase(false, "1000", "100", "675.80", TestName = "Test1000EurosAdditionalIncome100EurosOneYear")]
        [TestCase(true, "1000", "100", "443.10", TestName = "Test1000EurosAdditionalIncome100EurosTwoYear")]
        public static void TestChildcareBenefitCalculatorOneYearOption(bool twoyear, string income, string additionalIncome, string result)
        {
            childcareBenefitCalculatorPage.NavigateToChildcareBenefitCalculatorPage();
            childcareBenefitCalculatorPage.AcceptCookies();
            childcareBenefitCalculatorPage.SelectDuration(twoyear);
            childcareBenefitCalculatorPage.ClickGoToSecondStepButton();
            childcareBenefitCalculatorPage.EnterIncomeAmount(income);
            childcareBenefitCalculatorPage.ClickGoToThirdStepButton();
            childcareBenefitCalculatorPage.EnterAdditionalIncomeAmount(additionalIncome);
            childcareBenefitCalculatorPage.ClickGoToResultButton();
            childcareBenefitCalculatorPage.VerifyCalculatedBenefitIsCorrect(result);
        }
    }
}
