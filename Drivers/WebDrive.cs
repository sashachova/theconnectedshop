using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Theconnectedshop.Drivers
{
    public static class WebDriverWait 
    {
        public static IWebDriver Create()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument($"user-data-dir={Path.Combine(Directory.GetCurrentDirectory(), "ChromeTestProfile")}");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
        var driver = new ChromeDriver(options);
        driver.Manage().Window.Maximize();
        return driver; 
        }
    }
}