using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationTesting.Tests
{
    [TestFixture]
    class FacilityBookingTests : TestBase
    {
        //Completed
        [Test]
        public void FacilityBookingIndexView()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Facility Bookings")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                var elements = driver.FindElements(By.CssSelector("td[role='gridcell']"));

                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "FacilityId", "1"));

                if (elements.Count > 0)
                {

                    var element = elements[elements.Count - 1];
                    if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                        element.Click();

                }

                Thread.Sleep(3000);
                Random rndNo = new Random();
                var _elements = driver.FindElements(By.ClassName("rac-list-group-item"));

                if (_elements.Count != 1)
                {

                    int elementNum = rndNo.Next(1, _elements.Count);
                    var elementN = _elements[elementNum];
                    elementN.Click();
                }
                else
                {
                    var elementN = _elements[0];
                    elementN.Click();
                }

                Thread.Sleep(3000);

                Thread.Sleep(5000);
                driver.FindElement(By.Id("BookingDateSlot")).SendKeys("2019/02/26");
                driver.FindElement(By.Id("btnCheckAvailable")).Click();
                Thread.Sleep(3000);

                var _availableSlots = driver.FindElements(By.ClassName("AvailableTimeSlot"));
                int slot = rndNo.Next(1, _availableSlots.Count);
                var _slot = _availableSlots[slot];
                _slot.Click();

                Thread.Sleep(5000);
                driver.FindElement(By.ClassName("tb-save-32")).Click();
            }
        }
    }
}
