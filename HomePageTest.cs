using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;

namespace Theconnectedshop;

public class HomePageTest
{
    private IWebDriver driver;
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
            options.AddArgument($"user-data-dir={Path.Combine(Directory.GetCurrentDirectory(), "ChromeTestProfile")}");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
        driver = new ChromeDriver(options);
        driver.Manage().Window.Maximize(); 
    }

    [Test]
    public void OpenHomePageTest()
    {
        driver.Navigate().GoToUrl("https://theconnectedshop.com/");
        WebDriverWait waitForPageLoad = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            waitForPageLoad.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState").Equals("complete"));

        string homePageTitle = "The Connected Shop - Smart Locks, Smart Sensors, Smart Home & Office";
        string homePageUrl = "https://theconnectedshop.com/";

        Assert.That(driver.Title, Is.EqualTo(homePageTitle), "Title is not displayed");
        Assert.That(driver.Url, Is.EqualTo(homePageUrl), "The url is not correct");

        IWebElement logoPrimery = driver.FindElement(By.CssSelector("h1.Header__Logo > a.Header__LogoLink > img.Header__LogoImage--transparent"));
        Assert.That(logoPrimery.Displayed, "logo primery is not displayed");

        string expectedHeight = "75";
        string expectedWidth = "250";
        Assert.That(logoPrimery.GetAttribute("height"), Is.EqualTo(expectedHeight), "height is wrong");
        Assert.That(logoPrimery.GetAttribute("width"), Is.EqualTo(expectedWidth), "width is wrong");

        //Logo redirect 
        logoPrimery.Click();
        Assert.That(driver.Title, Is.EqualTo(homePageTitle), "Title is not displayed");

        //Account button
        IWebElement accountButton = driver.FindElement(By.CssSelector("a.Heading.Link.Link--primary.Text--subdued.u-h8"));
        Assert.That(accountButton.Displayed, "account button is not displayed");

        string expectedHeightAccountButton = "16.5px";
        string expectedWidthAccountButton = "65.6875px";

        Assert.That(accountButton.GetCssValue("height"), Is.EqualTo(expectedHeightAccountButton), "height is wrong");
        Assert.That(accountButton.GetCssValue("width"), Is.EqualTo(expectedWidthAccountButton), "width is wrong");

        //Search button
        IWebElement searchButton = driver.FindElement(By.CssSelector("a.Heading.Link.Link--primary.Text--subdued.u-h8"));
        Assert.That(searchButton.Displayed, "search button is not displayed");

        string expectedHeightSearchButton = "16.5px";
        string expectedWidthSearchButton = "65.6875px";

        Assert.That(searchButton.GetCssValue("height"), Is.EqualTo(expectedHeightSearchButton), "height is wrong");
        Assert.That(searchButton.GetCssValue("width"), Is.EqualTo(expectedWidthSearchButton), "width is wrong");

        //Cart button
        IWebElement cartButton = driver.FindElement(By.CssSelector("a.Heading.u-h6"));
        Assert.That(cartButton.Displayed, "cart button is not displayed");

    }
    [TearDown]
    public void TearDown()
    {
         try
            {
                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during teardown: {ex.Message}");
            }
            finally
            {
                driver = null;
            }
        }
    
}
