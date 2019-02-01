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

            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Companies")).Click();

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
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "Description", "This Description is written using automation."));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This InternalNote is written using automation."));
                driver.FindElement(By.ClassName("save-button")).Click();

            }
        }

        [Test]
        public void CompanyEdit()
        { 

            //driver.Url = "http://client.racsystems.co.za/admin/company";

            var elements = driver.FindElements(By.CssSelector("a[class='Toolbar']"));

            if (elements.Count > 0)
            {
                Random rnd = new Random();
                int elementNum = rnd.Next(1, elements.Count + 1);
                var element = elements[elementNum];

                if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                {

                    element.Click();
                    Thread.Sleep(2000);

                    var tooltipElements = driver.FindElements(By.ClassName("tool-container"));
                    var tt = driver.FindElements(By.CssSelector("div[class='tool-container gradient tool-left tool-rounded']"));

                }

                var pageId = element.GetAttribute("data-item");
                driver.Url = "http://client.racsystems.co.za/admin/company/edit/232"; //+ Convert.ToInt32(pageId);
                System.Diagnostics.Debug.Write("Company type edit with " + Convert.ToInt32(pageId) + " " + " id");

                if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                {

                    IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "CompanyTypeId", "2"));

                    driver.FindElement(By.Id("RegistrationNumber")).SendKeys("-1112");
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "CompanyStatusId", "1"));
                    var image = driver.FindElement(By.Id("ImageName"));

                    // Declaring a JavaScriptExecutor  to enable image uploader click function and open the window dialog
                    executor.ExecuteScript("arguments[0].click();", image);
                    Thread.Sleep(5000);

                    //Set image name from the dialog
                    SendKeys.SendWait(@"‪Racnet-Logo‪.jpg");
                    SendKeys.SendWait(@"{Enter}");

                    driver.FindElement(By.Id("ExpiryDate")).SendKeys("12/12/2031");
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "Description", "This Description is edited using automation."));
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This InternalNote is edited using automation."));

                    //Edit contact details 
                    driver.FindElement(By.LinkText("Contact Details")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.CssSelector("a[class='k-button k-button-icontext k-grid-add']")).Click();
                    Thread.Sleep(2000);
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "ContactInformationTypeId", "3"));
                    driver.FindElement(By.Id("InformationValue")).SendKeys("email@gmil.com");
                    //driver.FindElement(By.Id("OrderIndex")).SendKeys("2");
                    //executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "OrderIndex", "2"));
                    // executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "Contact details create InternalNote is edited using automation."));
                    //driver.FindElement(By.LinkText("Create")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.CssSelector("a[class='k-button k-button-icontext k-primary k-grid-update']")).Click();
                    //Thread.Sleep(2000);

                    if (Helpers.CheckIfElementInvisible(By.CssSelector("div[class='k-overlay']"), driver))
                        driver.FindElement(By.ClassName("save-button")).Click();

                }
            }
        }
    }
}
