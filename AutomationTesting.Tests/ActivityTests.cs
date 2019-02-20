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
    public class ActivityTests : TestBase
    {
        [Test]
        public void AnimalCreate()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Animal")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                Thread.Sleep(5000);
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "ActivityTypeId", "1"));
                Thread.Sleep(3000);
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "AnimalBreedId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "GenderId", "3"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "AnimalAgeGroupId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "StandId", "2"));
                Thread.Sleep(3000);

                driver.FindElement(By.Id("ActivityName")).SendKeys("Rocking");
                driver.FindElement(By.Id("Location")).SendKeys("Ascent");
                driver.FindElement(By.Id("ContactPerson")).SendKeys("2013/01/29");
                driver.FindElement(By.Id("MobileNumber")).SendKeys("0851234587");
                driver.FindElement(By.Id("LandlineNumber")).SendKeys("012631254");
                driver.FindElement(By.Id("EmailAddress")).SendKeys("0788811112@mail.com"); 

                driver.FindElement(By.Id("IsPublic")).Click();
                driver.FindElement(By.Id("IsFeatured")).Click();
                driver.FindElement(By.Id("CommentsAllowed")).Click();
                driver.FindElement(By.Id("IsPublic")).Click();
                driver.FindElement(By.Id("IsAllDayActivity")).Click();

                driver.FindElement(By.Id("ActivityStartTime")).SendKeys("2019/02/27");
                driver.FindElement(By.Id("ActivityEndTime")).SendKeys("2019/02/27");

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "pRecurrenceType", "2"));

                var image = driver.FindElement(By.Id("ImageName"));

                // Declaring a JavaScriptExecutor  to enable image uploader click function and open the window dialog
                executor.ExecuteScript("arguments[0].click();", image);
                Thread.Sleep(5000);

                //Set image name from the dialog
                SendKeys.SendWait(@"‪Racnet-Logo‪.jpg");
                SendKeys.SendWait(@"{Enter}");

                var icon = driver.FindElement(By.Id("IconName"));
                executor.ExecuteScript("arguments[0].click();", icon);
                Thread.Sleep(5000);

                //Set image name from the dialog
                SendKeys.SendWait(@"‪Racnet-Logo‪.jpg");
                SendKeys.SendWait(@"{Enter}");

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This Internal note is written using automation."));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "Description", "This Description is written using automation."));

            }
            Thread.Sleep(3000);

            driver.FindElement(By.ClassName("save-button")).Click();
        }
    }
}
