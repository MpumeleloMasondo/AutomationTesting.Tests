using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace AutomationTesting.Tests
{
    [TestFixture]
    public class CompanyTypeTests : TestBase
    {

        [Test]
        public void CompanyTypeCreate()
        {
            
            driver.Url = "http://client.racsystems.co.za/admin/companytype";

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
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
            driver.Url = "http://client.racsystems.co.za/admin/companytype";

            var elements = driver.FindElements(By.CssSelector("a[class='Toolbar']"));

            if (elements.Count > 0)
            {
                Random rnd = new Random();
                int elementNum = rnd.Next(1, elements.Count + 1);

                var element = elements[elementNum];
                var pageId = element.GetAttribute("data-item");
                driver.Url = "http://client.racsystems.co.za/admin/companytype/edit/" + Convert.ToInt32(pageId);
                System.Diagnostics.Debug.Write("Company type edit with " + Convert.ToInt32(pageId) + " " + " id");

                if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                {
                    driver.FindElement(By.Id("TypeName")).SendKeys(" Edit");

                    var checkBox = driver.FindElement(By.Id("IsPublic"));

                    if (!checkBox.Selected)
                        checkBox.Click();

                    // Image selection , instantiating an image
                    var image = driver.FindElement(By.Id("ImageName"));

                    // Declaring a JavaScriptExecutor  to enable image uploader click function and open the window dialog
                    IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                    executor.ExecuteScript("arguments[0].click();", image);
                    Thread.Sleep(5000);

                    //Set image name from the dialog
                    SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                    SendKeys.SendWait(@"{Enter}");

                    driver.FindElement(By.Id("default-value")).Clear();
                    driver.FindElement(By.Id("default-value")).SendKeys("#eee");
                    var colorCodePanel = driver.FindElement(By.ClassName("minicolors-panel"));

                    IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                    js.ExecuteScript("arguments[0].style='display: none;'", colorCodePanel);

                }
            }

            driver.FindElement(By.ClassName("save-button")).Click();
        }
    }
}
