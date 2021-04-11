using NUnit.Framework;

namespace Sodra.Test
{
    public class SodraMainTest : BaseTest
    {
        [TestCase("Ligos išmoka")]
        [TestCase("miau")]

        public static void TestSearch(string search)
        {
            sodraMainPage.NavigateToMainSodraPage();
            sodraMainPage.AcceptCookies();
            sodraMainPage.SearchFor(search);
            sodraMainPage.ClickToSearchFor();
            sodraMainPage.VerifyIfSearchResultTextIsCorrect(search);
        }
    }
}
