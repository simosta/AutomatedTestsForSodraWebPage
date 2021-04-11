using NUnit.Framework;


namespace Sodra.Test
{
    public class UnemployementBenefitCalculatorTest : BaseTest
    {
        [TestCase("20210418", "1000", "4137.21", TestName = "TestAverageIncome1000euros")]
        [TestCase("20210317", "600", "3020.13", TestName = "TestAverageIncome600euros")]

        public static void TestUnemployementCalculator(string date, string avgSalary, string totalAmount)
        {
            unemployementBenefitCalculatorPage.NavigateToUnemployementCalculator();
            unemployementBenefitCalculatorPage.AcceptCookies();
            unemployementBenefitCalculatorPage.EnterUnemployementDate(date);
            unemployementBenefitCalculatorPage.EnterAverageMonthlyBrutoSalary(avgSalary);
            unemployementBenefitCalculatorPage.ClickCalculateButton();
            unemployementBenefitCalculatorPage.VerifyTotalAmountPayed(totalAmount);
        }

    }
}
