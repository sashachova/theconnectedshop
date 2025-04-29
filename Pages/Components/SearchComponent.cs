using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Theconnectedshop.Config;

namespace Theconnectedshop.Pages.Components
{
    public class SearchComponent
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public SearchComponent(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestSettings.DefaultTimeOut));
        }

        private By SearchButton => By.CssSelector("a[data-action='toggle-search']");
        private By SearchInput => By.CssSelector("input.Search__Input.Heading");
        private By DisplayedSearchResult => By.CssSelector("div.Segment");

        public bool IsSearchButtonDisplayed() => driver.FindElement(SearchButton).Displayed;

        public string GetSearchHref() => driver.FindElement(SearchButton).GetAttribute("href");

        public void ClickSearchButton() => driver.FindElement(SearchButton).Click();

        public bool IsSearchInputDisplayed()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(SearchInput));
            return driver.FindElement(SearchInput).Displayed;
        }
        public string GetSearchPlaceholder() => driver.FindElement(SearchInput).GetAttribute("placeholder");
        public void EnterSearchTerm(string term)
        {
            driver.FindElement(SearchInput).Clear();
            driver.FindElement(SearchInput).SendKeys(term);
        }
         public bool IsSerchResultsAreDisplayed() 
        {
             wait.Until(ExpectedConditions.ElementIsVisible(DisplayedSearchResult));
             return driver.FindElement(DisplayedSearchResult).Displayed;
        }

    }
}