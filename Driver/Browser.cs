using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectLineGroupTests.Driver
{
    public static class Browser
    {
        public static IWebDriver driver;

        public static void SetBrowser(String BrowserName)
        {

            if (BrowserName.Equals("Chrome"))
            {
                Browser.driver = new ChromeDriver();
                Browser.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            }

        }

        public static void NavigateToURL(String URL)
        {
            Browser.driver.Navigate().GoToUrl(URL);
        }

    }
}