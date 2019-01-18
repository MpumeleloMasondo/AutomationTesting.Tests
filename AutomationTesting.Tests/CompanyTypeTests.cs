using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTesting.Tests
{
    [TestFixture]
    public class CompanyTypeTests : TestBase
    {

        [Test]
        public void CompanyTypeCreate()
        {
            driver.Url = "http://client.racsystems.co.za/Account/Login";

            //Enter credentials
            driver.FindElement(By.Id("LoginName")).SendKeys(""); //Password
            driver.FindElement(By.Id("Password")).SendKeys("");

            driver.FindElement(By.ClassName("btn-login")).Click();

            //enter validations
            //Assert.That()
            driver.Url = "http://client.racsystems.co.za/admin/companytype";

            //driver.FindElement(By.ClassName("tb-add-32")).Click();

            // var isInvisible = CheckIfElementInvisible(By.Id("PageLoader"), driver);

            if (CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            if (CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                driver.FindElement(By.Id("TypeName")).SendKeys("Sewing Dep");
                driver.FindElement(By.Id("default-value")).SendKeys("#fff");
                driver.FindElement(By.Id("IsPublic")).SendKeys("true");
                driver.FindElement(By.ClassName("save-button")).Click();
            } 

        }
         
        [Test]
        public void CompanyTypeEdit()
        {
            driver.Url = "http://client.racsystems.co.za/Account/Login";

            //Enter credentials
            driver.FindElement(By.Id("LoginName")).SendKeys(""); //Password
            driver.FindElement(By.Id("Password")).SendKeys("");

            driver.FindElement(By.ClassName("btn-login")).Click();

            //enter validations
            //Assert.That()
            driver.Url = "http://client.racsystems.co.za/admin/companytype";

            //driver.FindElement(By.ClassName("tb-add-32")).Click();

            // var isInvisible = CheckIfElementInvisible(By.Id("PageLoader"), driver);
           

            if (CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                //driver.FindElement(By.)
                driver.FindElement(By.ClassName("tb-add-32")).Click();
            }

            //List<IWebElement> el = new List<IWebElement>(); el.AddRange(driver.FindElements(By.CssSelector("*")));

            //List<string> ag = new List<string>();
            //for (int b = 0; b < el.Count; b++)
            //{
            //    ag.Add(el[b].GetAttribute("outerHTML"));
            //}

            var elements = driver.FindElements(By.CssSelector("a[class='Toolbar']"));// .GetAttribute("data-item");

            if (CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                driver.FindElement(By.Id("TypeName")).SendKeys("Sewing Dep");
                driver.FindElement(By.Id("default-value")).SendKeys("#fff");
                driver.FindElement(By.Id("IsPublic")).SendKeys("true");
                driver.FindElement(By.ClassName("save-button")).Click();
            }

          //  driver.FindElement(By.XPath("[@gl-command='transaction']")).Click();
        }

        public static bool CheckIfElementInvisible(By by, IWebDriver driver)
        {
            var _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                _wait.Until(drv => !drv.FindElement(by).Displayed);
                System.Diagnostics.Debug.Write("Element" + " " + @by + " " + "is visible");

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("Element" + " " + @by + " " + "is not found |" + " " + e.Message);
                return false;
            }

            return true;
        } 

    }
}
