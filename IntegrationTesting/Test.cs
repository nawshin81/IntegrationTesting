using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace IntegrationTesting
{
    public class Test
    {
        public IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void TestMethod()
        {
            driver.Url = "https://www.esheba.cnsbd.com/#/login";
            IWebElement element = driver.FindElement(By.Id("email"));
            element.SendKeys("ulfatnawshin@gmail.com");

            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("naw7shin");
            //driver.FindElement(By.ClassName("btn btn-primary")).Click();
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
