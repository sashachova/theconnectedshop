using OpenQA.Selenium;
using Theconnectedshop.Config;
using Theconnectedshop.Pages.Components;

namespace Theconnectedshop.Pages
{
    public class HomePage
    {
            private readonly IWebDriver driver;
            public HeaderComponent Header
            {
                get;
            }
            public SearchComponent Search
            {
                get;
            }
            public HomePage(IWebDriver driver)
            {
                this.driver = driver;
                Header = new HeaderComponent(driver);
                Search = new SearchComponent(driver);
            }

            
     public void Open() => driver.Navigate().GoToUrl(TestSettings.BaseUrl);
            

    }
}