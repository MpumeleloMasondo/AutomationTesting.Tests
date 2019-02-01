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
    public class SiteTests : TestBase
    {
        [Test]
        public void SiteEdit()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Site")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-edit-32")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "SiteTypeId", "1"));

                driver.FindElement(By.Id("SiteName")).SendKeys("Edit");
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "FutureActivityDisplayPeriod", "91")); //from 90
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "FacilityBookingLimit", "11")); //from 10

                //Code below will be commented out 
                //IWebElement _siteImage = driver.FindElement(By.Id("ImageName"));
                //executor.ExecuteScript("arguments[0].click();", _siteImage);
                //Thread.Sleep(2000);
                //SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                //SendKeys.SendWait(@"{Enter}");

                //IWebElement _appImage = driver.FindElement(By.Id("AppImageName"));
                //executor.ExecuteScript("arguments[0].click();", _appImage);
                //Thread.Sleep(2000);
                //SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                //SendKeys.SendWait(@"{Enter}"); 

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "Description", "This Description is written using automation."));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This InternalNote is written using automation."));

                //Edit Pre-Clearance tab
                driver.FindElement(By.LinkText("Pre-Clearance")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.Id("SMSShortCode")).SendKeys("Edit");
                driver.FindElement(By.Id("SMSISOCode")).SendKeys("Edit");
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "AccessPinLength", "7")); //from 90
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "AccessCodeValidityDay", "2")); //from 90
                driver.FindElement(By.Id("AccessTransactionAutoCheckOut")).Click(); //it was true initially
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoNumericTextBox').value('{1}')", "AccessTransactionCheckOutInterval", "13")); //increased by 1
                driver.FindElement(By.Id("AccessCodeMessage")).SendKeys("{0} welcomes {1}. Access Code for {3} is {2} valid for {4} visit. ID/D Licence req for entry. Speed limit 40km/h enforced by camera. { 5}. Testing");
                Thread.Sleep(5000);

                // Edit Integrations tab
                driver.FindElement(By.LinkText("Integrations")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.Id("HasImproService")).Click(); //it was true initially
                driver.FindElement(By.Id("ImproHasKeypadEntry")).Click(); //it was false initially
                driver.FindElement(By.Id("ImproHasKeypadExit")).Click(); //it was false initially
                driver.FindElement(By.Id("ImproServiceUrl")).SendKeys("Edit"); //it was http://barrac.dyndns.biz:420/api/ initially

                // Edit Importer Mapping tab
                driver.FindElement(By.LinkText("Importer Mapping")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.Id("PersonXMLMap")).Click();
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "pPersonTypeId", "1"));
                IWebElement _xmlFileImporter = driver.FindElement(By.Id("FileName"));
                executor.ExecuteScript("arguments[0].click();", _xmlFileImporter);
                Thread.Sleep(2000);
                SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                SendKeys.SendWait(@"{Enter}");

                Thread.Sleep(3000);
                driver.FindElement(By.Id("btnCancelPersonXMLMap")).Click();
                Thread.Sleep(2000);

                // Edit Map View tab
                driver.FindElement(By.LinkText("Map View")).Click();
                Thread.Sleep(5000);

                // Edit Custom Properties tab
                driver.FindElement(By.LinkText("Custom Properties")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.Id("customPerson")).Click();
                driver.FindElement(By.Id("customVehicle")).Click();
                driver.FindElement(By.Id("customStand")).Click();
                driver.FindElement(By.Id("customSite")).Click();

                // Edit Settings tab
                driver.FindElement(By.LinkText("Settings")).Click();
                Thread.Sleep(2000);

                // need to add code for the following settings contacts additional information


            }

            driver.FindElement(By.ClassName("save-button")).Click();

        }

        [Test]
        public void SiteView()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Site")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                // need to add binding of grid loader 
                driver.FindElement(By.LinkText("People")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchPersonList")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Companies")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchCompanies")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Zones")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchZones")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Gates")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchGates")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Locations")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchLocations")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Stand")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("btnFetchStand")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Site Map View")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Settings")).Click();
                Thread.Sleep(5000);

                driver.FindElement(By.LinkText("Contacts")).Click();
                Thread.Sleep(5000);

            }

        }
    }
}
