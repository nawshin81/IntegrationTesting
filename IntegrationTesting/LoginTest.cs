using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace IntegrationTesting
{
    public class LoginTest
    {
        public IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void LoginMethod()
        {
            driver.Url = "https://www.esheba.cnsbd.com/#/login";
            Thread.Sleep(2000);
            IWebElement element = driver.FindElement(By.Id("email"));
            element.SendKeys("ulfatnawshin@gmail.com");
            Thread.Sleep(1000);
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("1234567");

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div/section/div/div/div/div/div[2]/div/form/div[4]/div/button")).Click();

            String at = driver.Title;

            String et = "Bangladesh Railway";

            if (at == et)
            {
                Console.WriteLine("test successful");
                IWebElement element2 = driver.FindElement(By.XPath("/html/body/div/section/div/div/div/div/div[2]/div[2]/form/div[4]/div/button"));
                element2.Click();

            }
            else
            {
                Console.WriteLine("failed");
            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
