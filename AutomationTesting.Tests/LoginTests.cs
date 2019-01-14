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
            driver.FindElement(By.Id("LoginName")).SendKeys("sp12ikeyhair4me"); //Password
            driver.FindElement(By.Id("Password")).SendKeys("ricroc123");

            driver.FindElement(By.ClassName("btn-login")).Click();

            //enter validations
            //Assert.That()
        }
        [Test]
        public void VerifyInValidLogin()
        {

        }
    }
}
