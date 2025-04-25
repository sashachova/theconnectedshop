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
            }


        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.Create();
            homePage = new HomePage(driver);
            header = new HeaderComponent(driver);
            homePage.Open();

            
        }

        [Test]
        public void Header_ShouldHaveLogoAndAccountButton()
        {
            Assert.That(header.IsLogoDisplayed(), "Logo is not displayed");
            Assert.That(header.GetLogoHeight(), Is.EqualTo("75"));
            Assert.That(header.GetLogoWidth(), Is.EqualTo("250"));

            header.ClickLogo();

            Assert.That(header.IsAccountButtonDisplayed(), "Account button not visible");
            Assert.That(header.GetAccountButtonHeight(), Is.EqualTo("16.5px"));
            Assert.That(header.GetAccountButtonWidth(), Is.EqualTo("65.6875px"));
        }

        [Test]
        public void CartButton_ShouldBeVisibleAndHaveZeroCount()
        {
            Assert.That(header.IsCartButtonDisplayed(), "Cart button not visible");
            Assert.That(header.GetCartCountText(), Is.EqualTo("0"), "Cart count should be 0");
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