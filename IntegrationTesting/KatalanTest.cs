using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace IntegrationTesting
{
    [TestFixture]
    public class  KatalanTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [Test]
        public void TheKatalanTest()
        {
            driver.Navigate().GoToUrl("https://www.esheba.cnsbd.com/#/");
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("ulfatnawshin@gmail.com");
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("naw7shin");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.LinkText("Dashboard")).Click();
            driver.FindElement(By.LinkText("Update User Profile")).Click();
            driver.FindElement(By.LinkText("Change Password")).Click();
            driver.FindElement(By.LinkText("Change Mobile Number")).Click();
            driver.FindElement(By.LinkText("Change E-mail")).Click();
            driver.FindElement(By.LinkText("Upcoming Journeys")).Click();
            driver.FindElement(By.LinkText("Current Journey")).Click();
            driver.FindElement(By.LinkText("Previous Journeys")).Click();
            driver.FindElement(By.LinkText("Purchase History")).Click();
            driver.FindElement(By.LinkText("Verify Ticket")).Click();
            driver.FindElement(By.LinkText("Contact Us")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
    }
}
