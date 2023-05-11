using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace MicrosoftLearning.eShopOnWeb_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAccess()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://eshoponweb-devops-canary.azurewebsites.net/";

            //string msg = driver.FindElement(By.ClassName("esh-identity-name esh-identity-name--upper")).Text;
            string msg = driver.FindElement(By.CssSelector(".esh-identity-name.esh-identity-name--upper")).Text;
            //driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            Assert.AreEqual("LOGIN", msg);
            driver.Close();
        }

        [TestMethod]
        public void TestLoginFail()
        {
            string email = "admin@microsoft.com";
            string pass = "1234abcd";

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://eshoponweb-devops-canary.azurewebsites.net/Identity/Account/Login";

            driver.FindElement(By.Id("Input_Email")).SendKeys(email);
            driver.FindElement(By.Id("Input_Password")).SendKeys(pass);
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            //driver.FindElement(By.ClassName("btn btn-default")).Click();

            string message = driver.FindElement(By.ClassName("esh-identity-name")).Text;
            Assert.AreNotEqual("admin@microsoft.com", message);

            driver.Close();
        }

        [TestMethod]
        public void TestLoginPass()
        {
            string email = "admin@microsoft.com";
            string pass = "Pass@word1";

            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://eshoponweb-devops-canary.azurewebsites.net/Identity/Account/Login";

            driver.FindElement(By.Id("Input_Email")).SendKeys(email);
            driver.FindElement(By.Id("Input_Password")).SendKeys(pass);
            driver.FindElement(By.CssSelector(".btn.btn-default")).Click();
            //driver.FindElement(By.ClassName("btn btn-default")).Click();

            string message = driver.FindElement(By.ClassName("esh-identity-name")).Text;
            Assert.AreEqual("admin@microsoft.com", message);

            driver.Close();
        }

        [TestMethod]
        public void AddBasket()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://eshoponweb-devops-canary.azurewebsites.net/";

            string old_value = driver.FindElement(By.ClassName("esh-basketstatus-badge")).Text;
            driver.FindElement(By.ClassName("esh-catalog-button")).Click();

            string new_value = driver.FindElement(By.ClassName("esh-basketstatus-badge")).Text;

            Assert.AreEqual((int.Parse(old_value) + 1).ToString(), new_value);

            driver.Close();
        }

        [TestMethod]
        public void TestMenu()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://eshoponweb-devops-canary.azurewebsites.net/";

            IWebElement dropdownElement = driver.FindElement(By.Id("CatalogModel_BrandFilterApplied"));
            SelectElement dropdown = new SelectElement(dropdownElement);
            dropdown.SelectByValue("2");

            driver.FindElement(By.ClassName("esh-catalog-send")).Click();
            driver.Close();
        }
    }
}