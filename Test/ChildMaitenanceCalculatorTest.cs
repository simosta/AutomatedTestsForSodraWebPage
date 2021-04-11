using NUnit.Framework;

namespace Sodra.Test
{
    public class ChildMaitenanceCalculatorTest : BaseTest
    {
        [TestCase("150", "52", "72,00 €")]
        [TestCase("79", "52", "27,00 €")]

        public static void TestChildMaitenanaceAdjudgedInEuros(string adjudged, string debtor, string result)
        {
            childMaitenanceCalculatorPage.NavigateToChildMaitenanceCalculatorPage();
            childMaitenanceCalculatorPage.AcceptCookies();
            childMaitenanceCalculatorPage.InputMaitenanceAmountsAdjudgedInEuros(adjudged, debtor);
            childMaitenanceCalculatorPage.ClickCalculateMaitenanceButton();
            childMaitenanceCalculatorPage.VerifyIfMaitenanceAmountCorrect(result);
        }
        [TestCase("300", "52", "34,89 €")]
        [TestCase("250", "52", "20,41 €")]
        public static void TestChildMaitenanaceAdjungedInLitai(string adjudged, string debtor, string result)
        {
            childMaitenanceCalculatorPage.NavigateToChildMaitenanceCalculatorPage();
            childMaitenanceCalculatorPage.AcceptCookies();
            childMaitenanceCalculatorPage.SelectDateBeforeEuros();
            childMaitenanceCalculatorPage.InputMaitenanceAmountAdjudgedInLitai(adjudged, debtor);
            childMaitenanceCalculatorPage.ClickCalculateMaitenanceButton();
            childMaitenanceCalculatorPage.VerifyIfMaitenanceAmountCorrect(result);
        }
    }
}
