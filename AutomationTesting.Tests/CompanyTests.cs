using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTesting.Tests
{
    [TestFixture]
    public class CompanyTests : TestBase
    {
        [Test]
        public void CompanyCreate()
        {
            driver.Url = "http://client.racsystems.co.za/Account/Login";

            //Enter credentials
            driver.FindElement(By.Id("LoginName")).SendKeys(""); //Password
            driver.FindElement(By.Id("Password")).SendKeys("pu]as");
            driver.FindElement(By.ClassName("btn-login")).Click();
            driver.Url = "http://client.racsystems.co.za/admin/company";

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.Id("btnCompanyCreate")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "CompanyTypeId", "1"));

                driver.FindElement(By.Id("CompanyName")).SendKeys("New Company 1");
                driver.FindElement(By.Id("RegistrationNumber")).SendKeys("F312Tetn123");
                driver.FindElement(By.Id("VatNo")).SendKeys("123346233");
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "CompanyStatusId", "1"));
                var image = driver.FindElement(By.Id("ImageName"));
                executor.ExecuteScript("arguments[0].click();", image);
                Thread.Sleep(5000);

                //Set image name from the dialog
                SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                SendKeys.SendWait(@"{Enter}");

                driver.FindElement(By.Id("ExpiryDate")).SendKeys("12/12/2030");
                //driver.FindElement(By.Id("Description")).SendKeys("Data for description");
                //driver.FindElement(By.Id("InternalNote")).SendKeys("Data for internal note");
                driver.FindElement(By.ClassName("save-button")).Click();
            }
        }

        [Test]
        public void CompanyEdit()
        {
            driver.Url = "http://client.racsystems.co.za/Account/Login";

            //Enter credentials
            driver.FindElement(By.Id("LoginName")).SendKeys(""); //Password
            driver.FindElement(By.Id("Password")).SendKeys("pu]as");
            driver.FindElement(By.ClassName("btn-login")).Click();
            driver.Url = "http://client.racsystems.co.za/admin/company";


            var elements = driver.FindElements(By.CssSelector("a[class='Toolbar']"));

            if (elements.Count > 0)
            {
                Random rnd = new Random();
                int elementNum = rnd.Next(1, elements.Count + 1);

                var element = elements[elementNum];
                var pageId = element.GetAttribute("data-item");
                driver.Url = "http://client.racsystems.co.za/admin/company/edit/" + Convert.ToInt32(pageId);
                System.Diagnostics.Debug.Write("Company type edit with " + Convert.ToInt32(pageId) + " " + " id");

                if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                {

                    IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "CompanyTypeId", "2"));

                    // IJavaScriptExecutor.ExecuteSc(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "Type", value));

                   // driver.FindElement(By.Id("CompanyName")).SendKeys("Edit");
                    driver.FindElement(By.Id("RegistrationNumber")).SendKeys("-1");
                    //driver.FindElement(By.Id("VatNo")).SendKeys("-er");
                    //driver.FindElement(By.Id("CompanyStatusId")).SendKeys("true");
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "CompanyStatusId", "1"));
                    //driver.FindElement(By.Id("ImageName")).SendKeys("true");
                    var image = driver.FindElement(By.Id("ImageName"));

                    // Declaring a JavaScriptExecutor  to enable image uploader click function and open the window dialog
                    //    IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                    executor.ExecuteScript("arguments[0].click();", image);
                    Thread.Sleep(5000);

                    //Set image name from the dialog
                    SendKeys.SendWait(@"‪payroll.jpg");
                    SendKeys.SendWait(@"{Enter}");

                    driver.FindElement(By.Id("ExpiryDate")).SendKeys("12/12/2030");
                    //driver.FindElement(By.Id("Description")).SendKeys("Data for description");
                    //driver.FindElement(By.Id("InternalNote")).SendKeys("Data for internal note");
                    driver.FindElement(By.ClassName("save-button")).Click();
                }
            }
        }

    }
}
