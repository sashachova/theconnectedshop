using OpenQA.Selenium;
using Theconnectedshop.Config;
using Theconnectedshop.Pages.Components;

namespace Theconnectedshop.Pages
{
    public class HomePage
    {
            private readonly IWebDriver driver;

            public HomePage(IWebDriver driver)
            {
                this.driver = driver;
            }

            public void Open() => driver.Navigate().GoToUrl(TestSettings.BaseUrl);
    }
}