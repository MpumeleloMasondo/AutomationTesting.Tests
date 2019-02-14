using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTesting.Tests
{
    [TestFixture]
    public class GuardTests : TestBase
    {
        [Test]
        public void GuardIndexView()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Guards")).Click();

        }

        [Test]
        public void GuardCreate()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Guards")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "pGuardTypeId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "CompanyId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "TitleId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "GenderId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "EthnicityId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "pGuardStatusId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "GuardGradeId", "1"));

                driver.FindElement(By.Id("FirstName")).SendKeys("Moana");
                driver.FindElement(By.Id("LastName")).SendKeys("Testra");
                driver.FindElement(By.Id("IdNumber")).SendKeys("9009123346233");
                driver.FindElement(By.Id("AllowFirearm")).Click();
                driver.FindElement(By.Id("DateOfBirth")).SendKeys("12/12/1990");

                var _guardImage = driver.FindElement(By.Id("ImageName"));
                executor.ExecuteScript("arguments[0].click();", _guardImage);
                Thread.Sleep(5000);

                //Set image name from the dialog
                SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                SendKeys.SendWait(@"{Enter}");

                driver.FindElement(By.Id("ExpiryDate")).SendKeys("12/12/2030");
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This InternalNote is written using automation."));

                //driver.FindElement(By.LinkText("Nationalities")).Click();
                //driver.FindElement(By.LinkText("Add new record")).Click();
                //executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "NationalityId", "10"));
                //driver.FindElement(By.Id("PassportNumber")).SendKeys("102931232134");
                //driver.FindElement(By.Id("OriginNationality")).Click(); 

            }

            //driver.FindElement(By.LinkText("Create")).Click();

            // Thread.Sleep(2000);

            //if (!Helpers.CheckIfElementIsVisible(By.ClassName("k-window"), driver))
            driver.FindElement(By.ClassName("tb-save-32")).Click();

        }

        [Test]
        public void GuardEdit()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Guards")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "pGuardTypeId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "CompanyId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "TitleId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "GenderId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "EthnicityId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "pGuardStatusId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "GuardGradeId", "1"));

                driver.FindElement(By.Id("FirstName")).SendKeys("Moaga");
                driver.FindElement(By.Id("LastName")).SendKeys("Testra");
                driver.FindElement(By.Id("IdNumber")).SendKeys("9009123346233");
                driver.FindElement(By.Id("AllowFirearm")).Click();
                driver.FindElement(By.Id("DateOfBirth")).SendKeys("12/12/1990");

                var _guardImage = driver.FindElement(By.Id("ImageName"));
                executor.ExecuteScript("arguments[0].click();", _guardImage);
                Thread.Sleep(5000);

                //Set image name from the dialog
                SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                SendKeys.SendWait(@"{Enter}");

                driver.FindElement(By.Id("ExpiryDate")).SendKeys("12/12/2030");
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This InternalNote is written using automation."));

                driver.FindElement(By.LinkText("Nationalities")).Click();
                driver.FindElement(By.LinkText("Add new record")).Click();
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "NationalityId", "1"));

                driver.FindElement(By.Id("PassportNumber")).SendKeys("102931232134");
                driver.FindElement(By.Id("OriginNationality")).Click();

            }

            driver.FindElement(By.LinkText("Create")).Click();
            Thread.Sleep(2000);

            if (Helpers.CheckIfElementInvisible(By.ClassName("k-overlay"), driver))
                driver.FindElement(By.ClassName("save-button")).Click();

        }

    }
}
