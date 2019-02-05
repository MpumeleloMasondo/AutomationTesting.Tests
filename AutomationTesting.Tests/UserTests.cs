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
    public class UserTests : TestBase
    {
        [Test]
        public void UserIndexView()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Users")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                driver.FindElement(By.LinkText("Person Users")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.LinkText("Guard Users")).Click();
                Thread.Sleep(2000);

            }

        }

        [Test]
        public void UserCreate()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Users")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                // driver.FindElement(By.ClassName("tb-add-32")).Click();

                //EmailAddress UserName Password ConfirmPassword

                driver.FindElement(By.Id("EmailAddress")).SendKeys("email@testingus.com");
                driver.FindElement(By.Id("UserName")).SendKeys("Mrekzo");
                driver.FindElement(By.Id("Password")).SendKeys("Major123!");
                driver.FindElement(By.Id("ConfirmPassword")).SendKeys("Major123!");
                driver.FindElement(By.Id("Roles_0__IsInRole")).Click();
                driver.FindElement(By.Id("Roles_1__IsInRole")).Click();
                driver.FindElement(By.Id("Roles_2__IsInRole")).Click();
                driver.FindElement(By.Id("Roles_3__IsInRole")).Click();
                driver.FindElement(By.Id("Roles_4__IsInRole")).Click();
                driver.FindElement(By.Id("Roles_5__IsInRole")).Click();
                driver.FindElement(By.Id("Roles_6__IsInRole")).Click();

                Thread.Sleep(4000);

                driver.FindElement(By.ClassName("save-button")).Click();

            }

        }

        [Test]
        public void UserEdit()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Users")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                List<IWebElement> elements = new List<IWebElement>();

                //elements = driver.FindElements(By.CssSelector("a[class='Toolbar']")).ToList();

                if (elements.Count > 0)
                {
                    //Random rnd = new Random();
                    //int elementNum = rnd.Next(1, elements.Count + 1);
                    //var element = elements[elementNum];

                    //element.Click();
                    //Thread.Sleep(2000);

                    //var pageId = element.GetAttribute("data-item");


                }
                driver.Url = "http://client.racsystems.co.za/Admin/User/edit/85ce3d76-c99e-479c-924f-87480ec9bf68"; //+ Convert.ToInt32(pageId);
            }

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                driver.FindElement(By.Id("EmailAddress")).Clear();
                driver.FindElement(By.Id("EmailAddress")).SendKeys("email@testingusedit.com");
                driver.FindElement(By.Id("UserName")).SendKeys("Edit");
                driver.FindElement(By.Id("MobileNumber")).SendKeys("0817474744");
                driver.FindElement(By.Id("Roles_0__IsInRole")).Click();
                driver.FindElement(By.Id("Roles_1__IsInRole")).Click();
                //driver.FindElement(By.Id("Roles_2__IsInRole")).Click();
                driver.FindElement(By.Id("Roles_3__IsInRole")).Click();
                driver.FindElement(By.Id("Roles_4__IsInRole")).Click();
                driver.FindElement(By.Id("Roles_5__IsInRole")).Click();
                //driver.FindElement(By.Id("Roles_6__IsInRole")).Click();

                Thread.Sleep(4000);

                //Navigate to privileges tab 
                driver.FindElement(By.LinkText("Privileges")).Click();

                int _rowCount = driver.FindElements(By.XPath("//table[@id='privilegeEntityCollection']/tbody/tr")).Count();

                System.Diagnostics.Debug.Write("Number of row in the table is:" + _rowCount);

                for (var i = 0; i < _rowCount; i++)
                {
                    Random rnd = new Random();
                    int rndNum = rnd.Next(1, 7);

                    if (rndNum == 6 || rndNum == 5)
                    {
                        driver.FindElement(By.Id("rowNumber_" + rndNum)).Click();
                    }
                    else
                    {
                        int colRnd = rnd.Next(1, rndNum + 1);

                        for (var j = 0; j < colRnd; j++)
                        {
                            int rndCol = rnd.Next(1, 6);

                            if (rndCol == 1)
                                driver.FindElement(By.Id(string.Format("UserPrivileges_{0}__ViewAll", i))).Click();
                            if (rndCol == 2)
                                driver.FindElement(By.Id(string.Format("UserPrivileges_{0}__ViewItem", i))).Click();
                            if (rndCol == 3)
                                driver.FindElement(By.Id(string.Format("UserPrivileges_{0}__CreateItem", i))).Click();
                            if (rndCol == 4)
                                driver.FindElement(By.Id(string.Format("UserPrivileges_{0}__EditItem", i))).Click();
                            if (rndCol == 5)
                                driver.FindElement(By.Id(string.Format("UserPrivileges_{0}__DeleteItem", i))).Click();
                        }
                    }
                }
            }
            driver.FindElement(By.ClassName("save-button")).Click();
        }


        [Test]
        public void UserDetails()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Users")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                List<IWebElement> elements = new List<IWebElement>();

                //elements = driver.FindElements(By.CssSelector("a[class='Toolbar']")).ToList();

                if (elements.Count > 0)
                {
                    //Random rnd = new Random();
                    //int elementNum = rnd.Next(1, elements.Count + 1);
                    //var element = elements[elementNum];

                    //element.Click();
                    //Thread.Sleep(2000);

                    //var pageId = element.GetAttribute("data-item");


                }
                driver.Url = "http://client.racsystems.co.za/Admin/User/details/85ce3d76-c99e-479c-924f-87480ec9bf68"; //+ Convert.ToInt32(pageId);
            }

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                driver.FindElement(By.LinkText("Privileges")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.LinkText("Login History")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.LinkText("Audit Entries")).Click();
                Thread.Sleep(2000);
            }
        }

        [Test]
        public void UserDelete()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Users")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {

                List<IWebElement> elements = new List<IWebElement>();

                //elements = driver.FindElements(By.CssSelector("a[class='Toolbar']")).ToList();

                if (elements.Count > 0)
                {
                    //Random rnd = new Random();
                    //int elementNum = rnd.Next(1, elements.Count + 1);
                    //var element = elements[elementNum];
                    //element.Click();
                    //Thread.Sleep(2000);
                    //var pageId = element.GetAttribute("data-item");
                }

                driver.Url = "http://client.racsystems.co.za/Admin/User/delete/85ce3d76-c99e-479c-924f-87480ec9bf68"; //+ Convert.ToInt32(pageId);
            }

           // if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                //driver.FindElement(By.ClassName("save-button")).Click();
        }
    }
}
