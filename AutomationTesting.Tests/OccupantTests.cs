using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTesting.Tests
{
    [TestFixture]
    public class OccupantTests : TestBase
    {
        [Test]
        public void OccupantIndexView()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Visitors")).Click();

        }

        [Test]
        public void OccupantEdit()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Visitors")).Click();

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
                driver.Url = "http://client.racsystems.co.za/Admin/occupant/edit/183368"; //+ Convert.ToInt32(pageId);

            }

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                //Can an occupant to a person  by clicking the below element
                //driver.FindElement(By.LinkText("Convert To Person")).Click()
                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "OccupantStatusId", "2"));

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This Description is written using automation."));

                // need to add binding of grid loader 
                driver.FindElement(By.LinkText("Contact Details")).Click();
                driver.FindElement(By.LinkText("Add new record")).Click();

                if (Helpers.CheckIfElementIsVisible(By.ClassName("k-overlay"), driver))
                {
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "ContactInformationTypeId", "2"));
                    driver.FindElement(By.Id("InformationValue")).SendKeys("0119971234");
                    //executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This Description is written using automation."));
                }

                driver.FindElement(By.ClassName("k-grid-update")).Click();

                if (Helpers.CheckIfElementInvisible(By.ClassName("k-overlay"), driver))
                    driver.FindElement(By.ClassName("save-button")).Click();
            }
        }

        [Test]
        public void OccupantDetails()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Visitors")).Click();

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
                driver.Url = "http://client.racsystems.co.za/Admin/occupant/details/183368"; //+ Convert.ToInt32(pageId);

            }

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                //Can an occupant to a person  by clicking the below element
                //driver.FindElement(By.LinkText("Convert To Person")).Click()

                // need to add binding of grid loader 
                driver.FindElement(By.LinkText("Contact Details")).Click();
                driver.FindElement(By.Id("btnFetchOccupantContactInformation")).Click();
                //SpinWait

                driver.FindElement(By.LinkText("Access History")).Click();
                driver.FindElement(By.Id("btnFetchAccesssTransactions")).Click();

                driver.FindElement(By.LinkText("Vehicle History")).Click();
                driver.FindElement(By.Id("btnFetchVehicleTransactions")).Click();

                driver.FindElement(By.LinkText("Profile Footprint")).Click();

            }
        }
    }
}
