using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Sodra.Drivers;
using Sodra.Page;
using Sodra.Tools;

namespace Sodra.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static SodraMainPage sodraMainPage;
        public static ChildMaitenanceCalculatorPage childMaitenanceCalculatorPage;
        public static ChildcareBenefitCalculatorPage childcareBenefitCalculatorPage;
        public static UnemployementBenefitCalculatorPage unemployementBenefitCalculatorPage;

        [SetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            sodraMainPage = new SodraMainPage(driver);
            childMaitenanceCalculatorPage = new ChildMaitenanceCalculatorPage(driver);
            childcareBenefitCalculatorPage = new ChildcareBenefitCalculatorPage(driver);
            unemployementBenefitCalculatorPage = new UnemployementBenefitCalculatorPage(driver);
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreeshot(driver);
            driver.Quit();
        }

    }
}
