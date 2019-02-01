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
                driver.Url = "http://client.racsystems.co.za/Admin/stand/details/5647"; //+ Convert.ToInt32(pageId);

            }

            //    Random rnd = new Random();
            //int elementNum = rnd.Next(1, elements.Count + 1);
            //var element = elements[elementNum]; e


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
    }
}