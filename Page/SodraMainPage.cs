using NUnit.Framework;
using OpenQA.Selenium;

namespace Sodra.Page
{
    public class SodraMainPage : BasePage
    {
        private const string PageAddress = "https://www.sodra.lt/en/";
        private IWebElement _searchInput => Driver.FindElement(By.CssSelector("#header_top > div > ul > li.search_widget_wrap.hidden-xs.opened > form > fieldset > input.qSearchField"));
        private IWebElement _searchButton => Driver.FindElement(By.CssSelector("#header_top > div > ul > li.search_widget_wrap.hidden-xs.opened > form > fieldset > button"));
        private IWebElement _searchResultText => Driver.FindElement(By.CssSelector("#content > div.content_inner.main_search.content_padding > div:nth-child(1) > form > div.col-md-8 > p > span"));


        public SodraMainPage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToMainSodraPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void SearchFor(string search)
        {
            _searchInput.SendKeys(search);
        }
        public void ClickToSearchFor()
        {
            _searchButton.Click();
        }

        public void VerifyIfSearchResultTextIsCorrect(string search)
        {
            Assert.IsTrue(_searchResultText.Text.Contains(search));
        }
    }
}
