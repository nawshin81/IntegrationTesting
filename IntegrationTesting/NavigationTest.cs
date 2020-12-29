using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IntegrationTesting
{
    public class NavigationTest:INavigation
    {
        public INavigation Navigation;
           public IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }
        [Test]
        public void NavigationTestMethod()
        {
            driver.Url = "https://www.esheba.cnsbd.com/#/";
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://www.esheba.cnsbd.com/#/register");
            //driver.Url = "https://www.esheba.cnsbd.com/#/register";
            Thread.Sleep(1000);
            IWebElement element = driver.FindElement(By.Id("name"));
            element.SendKeys("nawshin");
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://www.esheba.cnsbd.com/#/contact");
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(1000);

            driver.Navigate().Forward();
            Thread.Sleep(1000);
        }

        public void Back()
        {
            Navigation.Back();
        }

        public void Forward()
        {
            Navigation.Forward();
        }

        public void GoToUrl(string url)
        {
            Navigation.GoToUrl(url);
        }

        public void GoToUrl(Uri url)
        {
            Navigation.GoToUrl(url);
        }

        public void Refresh()
        {
            Navigation.Refresh();
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
