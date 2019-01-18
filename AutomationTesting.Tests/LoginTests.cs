using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTesting.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {

        [Test]
        public void VerifyValidLogin()
        {
            driver.Url = "http://client.racsystems.co.za/Account/Login";

            //Enter credentials
            driver.FindElement(By.Id("LoginName")).SendKeys(""); //Password
            driver.FindElement(By.Id("Password")).SendKeys("");

            driver.FindElement(By.ClassName("btn-login")).Click();

            //enter validations
            //Assert.That()
            driver.Url = "http://client.racsystems.co.za/admin";
        }
        [Test]
        public void VerifyInValidLogin()
        {
            driver.Url = "http://client.racsystems.co.za/Account/Login";

            //Enter credentials
            driver.FindElement(By.Id("LoginName")).SendKeys(""); //Password
            driver.FindElement(By.Id("Password")).SendKeys("ri12coc123");

            driver.FindElement(By.ClassName("btn-login")).Click();

            //enter validations
            //Assert.That()
            driver.Url = "http://client.racsystems.co.za/admin";
        }
    }
}
