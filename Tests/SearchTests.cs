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

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.Create();
            homePage = new HomePage(driver);
            homePage.Open();
        }

        [Test]
        public void SearchButtonAndInput_ShouldBeVisible()
        {
            Assert.That(homePage.Search.IsSearchButtonDisplayed(), "Search button is not visible");
            Assert.That(homePage.Search.GetSearchHref().EndsWith("/search"), "Search button href is incorrect");

            homePage.Search.ClickSearchButton();

            Assert.That(homePage.Search.IsSearchInputDisplayed(), "Search input is not displayed");
            Assert.That(homePage.Search.GetSearchPlaceholder(), Is.EqualTo("Search..."), "Search placeholder is incorrect");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}