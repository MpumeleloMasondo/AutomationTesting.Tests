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
    class TestDriveTests : TestBase
    {
        [Test]
        public void TestDriveIndexView()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            //Should scroll through the page till it gets to the 'Test Drives' link
            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Test Drives")).Click();

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

                element.Click();
            }
        }
    }
}
