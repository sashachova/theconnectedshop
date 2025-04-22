using OpenQA.Selenium;
using Theconnectedshop.Config;

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