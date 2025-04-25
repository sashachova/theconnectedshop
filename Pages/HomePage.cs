using OpenQA.Selenium;
using Theconnectedshop.Config;
using Theconnectedshop.Pages.Components;

namespace Theconnectedshop.Pages
{
    public class HomePage
    {
            private readonly IWebDriver driver;

            
            public SearchComponent Search
            {
                get;
            }
            
            public HomePage(IWebDriver driver)
            {
                this.driver = driver;
                
                Search = new SearchComponent(driver);
            }

            
     public void Open() => driver.Navigate().GoToUrl(TestSettings.BaseUrl);
            

    }
}