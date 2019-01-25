using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace AutomationTesting.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {

            //System.setProperty("webdriver.chrome.driver", "C:/path/chromedriver.exe");
            //WebDriver driver = new ChromeDriver();
            //driver.get("https://chercher.tech/selenium-webdriver-sample");
            //// clicks the button which has id = 'button'
            //String idAttribute = driver.findElement(By.tagName("button")).getAttribute("id");

            driver = new FirefoxDriver("E:/inetpub/wwwroot/TestAutomation/AutomationTesting.Tests/AutomationTesting.Tests/bin/Debug"); // Launches browser
            driver.Manage().Window.Maximize(); // Maximise browser window
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); // Set locatorTimeout to be 20n secs at max

            driver.Url = "http://client.racsystems.co.za/Account/Login";

            //Enter credentials
            driver.FindElement(By.Id("LoginName")).SendKeys(""); //Password
            driver.FindElement(By.Id("Password")).SendKeys("");
            driver.FindElement(By.ClassName("btn-login")).Click();
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }

   public class Helpers
    {
        public static bool CheckIfElementInvisible(By by, IWebDriver driver)
        {
            var _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            try
            {
                _wait.Until(drv => !drv.FindElement(by).Displayed);
                System.Diagnostics.Debug.Write("Element" + " " + @by + " " + "is visible");

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("Element" + " " + @by + " " + "is not found |" + " " + e.Message);
                return false;
            }

            return true;
        }
    }
}
