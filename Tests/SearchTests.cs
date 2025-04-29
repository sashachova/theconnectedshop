using NUnit.Framework;
using OpenQA.Selenium;
using Theconnectedshop.Drivers;
using Theconnectedshop.Pages;
using Theconnectedshop.Pages.Components;
using Theconnectedshop.TestData;

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
        //TO-DO
        //Verify that search result is displayed when input is valid 
        [Test]
        public void SearchResutsAreDisplayed_WhenEnteringValidInput()
        {
            Search.ClickSearchButton();
            Search.EnterSearchTerm(SearchTestData.validSearchTerm);
            Assert.That(Search.IsSerchResultsAreDisplayed());

            var itemsFromSearchResultsValid = driver.FindElements(By.CssSelector("h2.ProductItem__Title Heading"));
            foreach (var item in itemsFromSearchResultsValid)
            {
                string text = item.Text.ToLower();
                Assert.That(text, Is.EqualTo(SearchTestData.validSearchTerm));
            }
            
        }
        //Verify that "No result" message is displayed when input is invalid
        public void SearchResutsAreEmpty_WhenEnteringInvalidInput()
        {
            Search.ClickSearchButton();
            Search.EnterSearchTerm(SearchTestData.invalidSearchTerm);
            Assert.That(Search.IsSerchResultsAreDisplayed());

            var itemsFromSearchResultsInvalid = driver.FindElements(By.CssSelector("div.Segment__Content"));
            foreach (var item in itemsFromSearchResultsInvalid)
            {
                string text = item.Text.ToLower();
                Assert.That(text, Is.EqualTo("no results could be found"));
            }
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