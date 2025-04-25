using NUnit.Framework;
using OpenQA.Selenium;
using Theconnectedshop.Drivers;
using Theconnectedshop.Pages;
using Theconnectedshop.Pages.Components;

namespace Theconnectedshop.Tests
{
    public class SearchTests
    {
        private IWebDriver driver;
        private HomePage homePage;
         public SearchComponent Search
            {
                get;
                private set;
            }

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.Create();
            homePage = new HomePage(driver);
            Search = new SearchComponent(driver);
            homePage.Open();
        }

        [Test]
        public void SearchButtonAndInput_ShouldBeVisible()
        {
            Assert.That(Search.IsSearchButtonDisplayed(), "Search button is not visible");
            Assert.That(Search.GetSearchHref().EndsWith("/search"), "Search button href is incorrect");

            Search.ClickSearchButton();

            Assert.That(Search.IsSearchInputDisplayed(), "Search input is not displayed");
            Assert.That(Search.GetSearchPlaceholder(), Is.EqualTo("Search..."), "Search placeholder is incorrect");
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
}