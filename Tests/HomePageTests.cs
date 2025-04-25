using NUnit.Framework;
using OpenQA.Selenium;
using Theconnectedshop.Drivers;
using Theconnectedshop.Pages;
using Theconnectedshop.Pages.Components;

namespace Theconnectedshop.Tests
{
    public class HomePageTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        //add
        public HeaderComponent Header
            {
                get;
                private set;
            }


        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.Create();
            homePage = new HomePage(driver);
            Header = new HeaderComponent(driver);
            homePage.Open();

            
        }

        [Test]
        public void Header_ShouldHaveLogoAndAccountButton()
        {
            Assert.That(Header.IsLogoDisplayed(), "Logo is not displayed");
            Assert.That(Header.GetLogoHeight(), Is.EqualTo("75"));
            Assert.That(Header.GetLogoWidth(), Is.EqualTo("250"));

            Header.ClickLogo();

            Assert.That(Header.IsAccountButtonDisplayed(), "Account button not visible");
            Assert.That(Header.GetAccountButtonHeight(), Is.EqualTo("16.5px"));
            Assert.That(Header.GetAccountButtonWidth(), Is.EqualTo("65.6875px"));
        }

        [Test]
        public void CartButton_ShouldBeVisibleAndHaveZeroCount()
        {
            Assert.That(Header.IsCartButtonDisplayed(), "Cart button not visible");
            Assert.That(Header.GetCartCountText(), Is.EqualTo("0"), "Cart count should be 0");
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