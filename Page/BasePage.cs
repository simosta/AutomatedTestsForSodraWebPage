using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Sodra.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public WebDriverWait GetWait(int seconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            return wait;
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }

        public void AcceptCookies()
        {
            Cookie myCookie = new Cookie("nonmodal_closed_43", "Mon%20May%2010%202021%2016%3A25%3A49%20GMT%2B0300%20(Eastern%20European%20Summer%20Time)",
                "www.sodra.lt", "/en", DateTime.Now.AddDays(5));
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
        }
    }
}
