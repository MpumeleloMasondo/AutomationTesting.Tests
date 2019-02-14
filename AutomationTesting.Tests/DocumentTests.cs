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
    class DocumentTests : TestBase
    {
        [Test]
        public void DocumentIndexView()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Documents")).Click();

            List<IWebElement> elements = new List<IWebElement>();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                elements = driver.FindElements(By.LinkText("Download")).ToList();

            if (elements.Count > 0)
            {
                Random rnd = new Random();
                int elementNum = rnd.Next(1, elements.Count + 1);
                var element = elements[elementNum];

                element.Click();
                Thread.Sleep(2000);

                element.Click();

                Thread.Sleep(5000);

            }
        }
    }
}
