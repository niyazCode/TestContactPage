using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestContactPage.StepDefinitions
{
    [Binding]
    public class ValidatingContactSectionInCodafitApplicationStepDefinitions
    {
        WebDriver driver = new ChromeDriver();

        [Given(@"the user launching the Codafit app")]
        public void GivenTheUserLaunchingTheCodafitApp()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
            driver.Navigate().GoToUrl("https://codafit.com/");
        }

        [When(@"user click on the ContactUs link at the (header|middlePage|bottomPage)")]
        public void WhenUserClickOnTheContactUsLink(String position)
        {
            switch (position)
            {
                case "header":
                    driver.FindElement(By.XPath("//a[@class='qodef-search-opener']//preceding-sibling::nav//li//span[text()='Contact']")).Click();
                    break;
                case "middlePage":
                    driver.FindElement(By.XPath("//span[text()='Contact Us']")).Click();
                    break;
                case "bottomPage":
                    IWebElement con = driver.FindElement(By.XPath("//span[text()='Get in Touch']"));
                    ((IJavaScriptExecutor)driver)
                 .ExecuteScript("arguments[0].scrollIntoView(true);", con);
                    con.Click();
                    break;
            }
        }

        [When(@"user navigate to homePage")]
        public void WhenUserNavigateToHomePage()
        {
            driver.Navigate().Back();
        }

        [When(@"the user submit the contact form")]
        public void theUserSubmitTheContactForm()
        {
            Thread.Sleep(5000);
            IWebElement element = driver.FindElement(By.XPath("//input[@value='Send message']//preceding::input[@type='checkbox']"));
            ((IJavaScriptExecutor)driver)
         .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
            driver.FindElement(By.XPath("//input[@value='Send message']")).Click();
        }


        [Then(@"verify the Title of the Contact page")]
        [Then(@"verify the navigation of the ContactUs page")]
        public void ThenVerifyTheNavigationOfAllTheContactUsLinkFromTheHomePage()
        {
            Thread.Sleep(6000);
            String pageTitle = driver.Title;
            Assert.AreEqual(pageTitle, "Let's talk business - Codafit");
        }

        [Then(@"verify the error message in the contact form")]
        public void ThenVerifyErrorMessageInContactForm()
        {
            IWebElement errorMsg = driver.FindElement(By.XPath("//input[@name='your-name']/following-sibling::span"));
            ((IJavaScriptExecutor)driver)
         .ExecuteScript("arguments[0].scrollIntoView(true);", errorMsg);
            String text = errorMsg.Text;
            Assert.AreEqual(text, "Please fill in the required field.");

        }

        [AfterScenario("TestRun1")]
        public void DeleteTestItem()
        {
            driver.Quit();
        }
    }
}