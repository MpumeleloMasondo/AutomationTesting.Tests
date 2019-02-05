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
    public class StandTests : TestBase
    {
        [Test]
        public void StandView()
        {

            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Stand")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                // need to add binding of grid loader 
                driver.FindElement(By.LinkText("Advertised")).Click();
                if (Helpers.CheckIfElementInvisible(By.ClassName("K-loading-image"), driver))
                    Thread.Sleep(2000);
                //SpinWait

                driver.FindElement(By.LinkText("On Show")).Click();
                if (Helpers.CheckIfElementInvisible(By.ClassName("K-loading-image"), driver))
                    Thread.Sleep(2000);

                driver.FindElement(By.LinkText("Map View")).Click();
                Thread.Sleep(2000);
            }
        }

        [Test]
        public void StandCreate()
        {

            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Stand")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "StandTypeId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "SiteLocationId", "2"));
                driver.FindElement(By.Id("StreetNumber")).SendKeys("12311");
                driver.FindElement(By.Id("StandNumber")).SendKeys("271");
                driver.FindElement(By.Id("ERFNumber")).SendKeys("217");
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "BedroomCount", "4"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "BathroomCount", "2"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "ReceptionRoomCount", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "StudyCount", "2"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "VehicleGarageCount", "2"));
                driver.FindElement(By.Id("HasStaffQuarters")).Click();
                driver.FindElement(By.Id("HasPool")).Click();
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "StandStatusId", "2"));

                IWebElement _siteImage = driver.FindElement(By.Id("ImageName"));
                executor.ExecuteScript("arguments[0].click();", _siteImage);
                Thread.Sleep(2000);
                SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                SendKeys.SendWait(@"{Enter}");

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "OrderIndex", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "Description", "This Description is written using automation."));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This InternalNote is written using automation."));
                Thread.Sleep(5000);
            }

            driver.FindElement(By.ClassName("save-button")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                Thread.Sleep(2000);

                driver.FindElement(By.LinkText("Photo Gallery")).Click();
                Thread.Sleep(2000);

                if (Helpers.CheckIfElementIsVisible(By.LinkText("Sale Photo Gallery"), driver))
                    driver.FindElement(By.LinkText("Sale Photo Gallery")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.LinkText("Map View")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.LinkText("People")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStandPersonList")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Meters")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStandMeters")).Click();
                Thread.Sleep(5000);

                if (Helpers.CheckIfElementIsVisible(By.LinkText("Pre-Clearances"), driver))
                {
                    driver.FindElement(By.LinkText("Pre-Clearances")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.Id("btnFetchStandPreClearence")).Click();
                    Thread.Sleep(5000);
                }

                driver.FindElement(By.LinkText("Access History")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStandAccessHistory")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Documents")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStandDocuments")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Communication")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStandCommunications")).Click();
                Thread.Sleep(5000);

            }
        }

        [Test]
        public void StandEdit()
        {

            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Stand")).Click();

            List<IWebElement> elements = new List<IWebElement>();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                elements = driver.FindElements(By.CssSelector("a[class='Toolbar']")).ToList();

            if (elements.Count > 0)
            {
                Random rnd = new Random();
                int elementNum = rnd.Next(1, elements.Count + 1);
                var element = elements[elementNum];

                element.Click();
                Thread.Sleep(2000);

                var pageId = element.GetAttribute("data-item");
                driver.Url = "http://client.racsystems.co.za/Admin/stand/edit/5647"; //+ Convert.ToInt32(pageId);

            }

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "StandTypeId", "2"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "SiteLocationId", "3"));
                driver.FindElement(By.Id("StreetNumber")).SendKeys("122311");
                driver.FindElement(By.Id("StandNumber")).SendKeys("1271");
                driver.FindElement(By.Id("ERFNumber")).SendKeys("1217");
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "BedroomCount", "5"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "BathroomCount", "3"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "ReceptionRoomCount", "2"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "StudyCount", "2"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "VehicleGarageCount", "3"));
                driver.FindElement(By.Id("HasStaffQuarters")).Click();
                driver.FindElement(By.Id("HasPool")).Click();
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "StandStatusId", "4"));

                IWebElement _siteImage = driver.FindElement(By.Id("ImageName"));
                executor.ExecuteScript("arguments[0].click();", _siteImage);
                Thread.Sleep(2000);
                SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                SendKeys.SendWait(@"{Enter}");

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "OrderIndex", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "Description", "This Description is written using automation."));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This InternalNote is written using automation."));
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Photo Gallery")).Click();
                Thread.Sleep(2000);
                IWebElement _galleryImage = driver.FindElement(By.Id("GalleryPhoto"));
                executor.ExecuteScript("arguments[0].click();", _galleryImage);
                Thread.Sleep(2000);
                SendKeys.SendWait(@"‪theme-error.jpg");
                SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(3000);

                driver.FindElement(By.LinkText("Documents")).Click();
                driver.FindElement(By.LinkText("Add Document")).Click();

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "pDocumentStandRelationshipTypeId", "1"));

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

                //Need to add document function and delete function
                //Need to add people delete function on people tab

                if (Helpers.CheckIfElementInvisible(By.ClassName("k-overlay"), driver))
                    driver.FindElement(By.ClassName("save-button")).Click();

            }
        }

        [Test]
        public void StandDetails()
        {

            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Stand")).Click();

            List<IWebElement> elements = new List<IWebElement>();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                elements = driver.FindElements(By.CssSelector("a[class='Toolbar']")).ToList();

            if (elements.Count > 0)
            {
                Random rnd = new Random();
                int elementNum = rnd.Next(1, elements.Count + 1);
                var element = elements[elementNum];

                element.Click();
                Thread.Sleep(2000);

                var pageId = element.GetAttribute("data-item");
                driver.Url = "http://client.racsystems.co.za/Admin/stand/details/5647"; //+ Convert.ToInt32(pageId);

            }

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                Thread.Sleep(2000);

                driver.FindElement(By.LinkText("Zoom")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.ClassName("pp_close")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.LinkText("Photo Gallery")).Click();
                Thread.Sleep(2000);

                if (Helpers.CheckIfElementIsVisible(By.LinkText("Sale Photo Gallery"), driver))
                    driver.FindElement(By.LinkText("Sale Photo Gallery")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.LinkText("Map View")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.LinkText("People")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStandPersonList")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Meters")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStandMeters")).Click();
                Thread.Sleep(5000);

                if (Helpers.CheckIfElementIsVisible(By.LinkText("Pre-Clearances"), driver))
                {
                    driver.FindElement(By.LinkText("Pre-Clearances")).Click();
                    Thread.Sleep(2000);
                    driver.FindElement(By.Id("btnFetchStandPreClearence")).Click();
                    Thread.Sleep(5000);
                }

                driver.FindElement(By.LinkText("Access History")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStandAccessHistory")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Documents")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStandDocuments")).Click();
                Thread.Sleep(5000);

                List<IWebElement> _docElements = new List<IWebElement>();

                if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                    _docElements = driver.FindElements(By.LinkText("Download")).ToList();

                if (elements.Count > 0)
                {
                    Random rnd = new Random();
                    int elementNum = rnd.Next(1, _docElements.Count + 1);
                    var element = _docElements[elementNum];

                    element.Click();
                    Thread.Sleep(2000);
                }

                driver.FindElement(By.LinkText("Communication")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStandCommunications")).Click();
                Thread.Sleep(5000);

            }
        }

        [Test]
        public void StandDelete()
        {

            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Stand")).Click();

            List<IWebElement> elements = new List<IWebElement>();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                elements = driver.FindElements(By.CssSelector("a[class='Toolbar']")).ToList();

            if (elements.Count > 0)
            {
                Random rnd = new Random();
                int elementNum = rnd.Next(1, elements.Count + 1);
                var element = elements[elementNum];

                element.Click();
                Thread.Sleep(2000);

                var pageId = element.GetAttribute("data-item");
                driver.Url = "http://client.racsystems.co.za/Admin/stand/delete/5647"; //+ Convert.ToInt32(pageId);

            }

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                Thread.Sleep(2000);
                driver.FindElement(By.ClassName("save-button")).Click();
            }
        }
    }
}