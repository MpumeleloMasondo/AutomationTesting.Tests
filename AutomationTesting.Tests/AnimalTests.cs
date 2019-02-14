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
    public class AnimalTests : TestBase
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
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "pAnimalTypeId", "1"));
                Thread.Sleep(3000);
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "AnimalBreedId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "GenderId", "3"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "AnimalAgeGroupId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "StandId", "2"));
                Thread.Sleep(3000);
                 
                driver.FindElement(By.Id("FirstName")).SendKeys("Rocking");
                driver.FindElement(By.Id("LastName")).SendKeys("Riz");
                driver.FindElement(By.Id("DateOfBirth")).SendKeys("2013/01/29");
                driver.FindElement(By.Id("DateAcquired")).SendKeys("2013/02/29");
                driver.FindElement(By.Id("PreferredVetName")).SendKeys("Rizy");
                driver.FindElement(By.Id("PreferredVetContactInformation")).SendKeys("0788811112");
                //driver.FindElement(By.Id("IsNeutered")).Click();
                //driver.FindElement(By.Id("IsInoculated")).Click();
                //driver.FindElement(By.Id("IsOnMedicalScheme")).Click();

                driver.FindElement(By.Id("MedicalSchemeProvider")).SendKeys("Mendoza");
                driver.FindElement(By.Id("MedicalSchemePolicyNumber")).SendKeys("20112398798");

                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "AnimalStatusId", "1"));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "InternalNote", "This Internal note is written using automation."));
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "Description", "This Description is written using automation."));

                //need attention especially when adding a disability
                //driver.FindElement(By.LinkText("Disabilities")).Click();

                //driver.FindElement(By.LinkText("Add new record")).Click();

                //executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "DisabilityId", "1"));
                //driver.FindElement(By.Id("EmergencyContactPerson")).SendKeys("Cole");
                //driver.FindElement(By.Id("EmergencyContactPhoneNumber")).SendKeys("0812123323");
                //driver.FindElement(By.LinkText("Create")).Click();

            }
            Thread.Sleep(3000);

            driver.FindElement(By.ClassName("save-button")).Click();
        }
    }
}
