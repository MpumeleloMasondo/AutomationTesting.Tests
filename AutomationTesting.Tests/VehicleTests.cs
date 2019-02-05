using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTesting.Tests
{
    [TestFixture]
    public class VehicleTests : TestBase
    {
        //Completed
        [Test]
        public void VehicleIndexView()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Vehicle")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                Thread.Sleep(2000);
        }

        [Test]
        public void VehicleCreate()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Vehicle")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                // driver.FindElement(By.ClassName("tb-add-32")).Click();

                //EmailAddress UserName Password ConfirmPassword
                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                
                driver.FindElement(By.Id("VehicleLicenseNo")).SendKeys("132gROP");
                driver.FindElement(By.Id("VehicleMake")).SendKeys("BMW");
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "VehicleStatusId", "2"));
                driver.FindElement(By.Id("VehicleIdentificationNumber")).SendKeys("123");
                driver.FindElement(By.Id("VehicleModel")).SendKeys("325i");
                driver.FindElement(By.Id("VehicleColor")).SendKeys("Pink");
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This INternalNote is written using automation for documents."));

                Thread.Sleep(4000);

                driver.FindElement(By.ClassName("save-button")).Click();

            }

        }

        [Test]
        public void VehicleEdit()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Vehicle")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                List<IWebElement> elements = new List<IWebElement>();

                elements = driver.FindElements(By.CssSelector("a[class='Toolbar']")).ToList();

                if (elements.Count > 0)
                {
                    Random rnd = new Random();
                    int elementNum = rnd.Next(1, elements.Count + 1);
                    var element = elements[elementNum];
                    element.Click();
                    Thread.Sleep(2000);
                    var pageId = element.GetAttribute("data-item");

                    driver.Url = "http://client.racsystems.co.za/Admin/vehicle/edit/152603"; //+ Convert.ToInt32(pageId);
                }
            }

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                //EmailAddress UserName Password ConfirmPassword 
                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "VehicleStatusId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This InternalNote is written using automation for documents."));

                Thread.Sleep(4000);

                driver.FindElement(By.LinkText("Documents")).Click();
                driver.FindElement(By.LinkText("Add Document")).Click();

                if (Helpers.CheckIfElementIsVisible(By.ClassName("k-overlay"), driver))
                {
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "pDocumentVehicleRelationshipTypeId", "1"));

                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "DocumentStatusId", "4"));
                    driver.FindElement(By.Id("DocumentName")).SendKeys("New Document Test");
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "DocumentTypeId", "3"));
                    driver.FindElement(By.Id("IsPublic")).Click();

                    executor.ExecuteScript("document.getElementById('DocumentExpiry').value='2019/02/28'");

                    driver.FindElement(By.Id("ExternalDocumentLink")).SendKeys("www.collar.co.za");
                    IWebElement _docFile = driver.FindElement(By.Id("files"));
                    executor.ExecuteScript("arguments[0].click();", _docFile);
                    Thread.Sleep(2000);
                    SendKeys.SendWait(@"theme-error.JPG");
                    SendKeys.SendWait(@"{Enter}");
                    Thread.Sleep(3000);

                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "Description", "This description is written using automation for documents."));

                    driver.FindElement(By.Id("btnSubmit")).Click();
                }

                //Need to add document function and delete function
                //Need to add people delete function on people tab

                if (Helpers.CheckIfElementInvisible(By.ClassName("k-overlay"), driver))
                    driver.FindElement(By.ClassName("save-button")).Click();

            }

        }

        [Test]
        public void VehicleDetails()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Vehicle")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                List<IWebElement> elements = new List<IWebElement>();

                elements = driver.FindElements(By.CssSelector("a[class='Toolbar']")).ToList();

                if (elements.Count > 0)
                {
                    Random rnd = new Random();
                    int elementNum = rnd.Next(1, elements.Count + 1);
                    var element = elements[elementNum];
                    element.Click();
                    Thread.Sleep(2000);
                    var pageId = element.GetAttribute("data-item");

                    driver.Url = "http://client.racsystems.co.za/Admin/vehicle/details/152603"; //+ Convert.ToInt32(pageId);
                }
            }

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                driver.FindElement(By.LinkText("Access History")).Click();

                driver.FindElement(By.LinkText("Access Lifecycles")).Click();
                driver.FindElement(By.Id("btnFetchAccessLifecycles")).Click();

                driver.FindElement(By.LinkText("Load History")).Click();
                driver.FindElement(By.Id("btnFetchLoadHistory")).Click();

                driver.FindElement(By.LinkText("Driver History")).Click();
                driver.FindElement(By.Id("btnFetchDriverHistory")).Click();

                driver.FindElement(By.LinkText("Linked People")).Click();
                driver.FindElement(By.Id("btnFetchLinkedPeople")).Click();

                driver.FindElement(By.LinkText("Profile Footprint")).Click();

                driver.FindElement(By.LinkText("Documents")).Click();
                driver.FindElement(By.Id("btnFetchDocuments")).Click(); 

                driver.FindElement(By.LinkText("Credentials")).Click();

                driver.FindElement(By.LinkText("Person Access Transactions")).Click();
                driver.FindElement(By.Id("btnFetchPersonAccessTransactions")).Click();
            }

        }
         
    }
}
