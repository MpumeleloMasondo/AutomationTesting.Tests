using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AutomationTesting.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            
            driver = new FirefoxDriver("E:/inetpub/wwwroot/TestAutomation/AutomationTesting.Tests/AutomationTesting.Tests/bin/Debug"); // Launches browser
            driver.Manage().Window.Maximize(); // Maximise browser window
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // Set locatorTimeout to be 20n secs at max
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
