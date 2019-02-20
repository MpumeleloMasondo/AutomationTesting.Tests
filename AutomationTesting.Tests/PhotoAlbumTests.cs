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
    public class PhotoAlbumTests : TestBase
    {
        [Test]
        public void PhotoAlbumCreate()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Photo Galleries")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.ClassName("tb-add-32")).Click();

            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                Thread.Sleep(5000);
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "PhotoAlbumCategoryId", "1"));
                Thread.Sleep(3000);
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "PhotoAlbumStatusId", "1"));

                driver.FindElement(By.Id("AlbumName")).SendKeys("First Test");

                driver.FindElement(By.Id("CommentsAllowed")).Click();
                driver.FindElement(By.Id("IsPublic")).Click();

                var image = driver.FindElement(By.Id("ImageName"));
                executor.ExecuteScript("arguments[0].click();", image);
                Thread.Sleep(2000);

                //Set image name from the dialog
                SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                SendKeys.SendWait(@"{Enter}");
                executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "Description", "This Description is written using automation."));
            }

            driver.FindElement(By.ClassName("tb-save-32")).Click();
        }

        [Test]
        public void PhotoAlbumEdit()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Photo Galleries")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                var elements = driver.FindElements(By.CssSelector("a[class='Toolbar']"));


                if (elements.Count > 0)
                {
                    Random rnd = new Random();
                    int elementNum = rnd.Next(1, elements.Count + 1);
                    var element = elements[elementNum];

                    if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                    {

                        element.Click();
                        Thread.Sleep(2000);

                        var tooltipElements = driver.FindElements(By.ClassName("tool-container"));
                        var tt = driver.FindElements(By.CssSelector("div[class='tool-container gradient tool-left tool-rounded']"));

                    }

                    var pageId = element.GetAttribute("data-item");
                    driver.Url = "http://client.racsystems.co.za/admin/photoalbum/edit/" + pageId;

                }
            }

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                IJavaScriptExecutor executor = driver as IJavaScriptExecutor;

                if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                {
                    Thread.Sleep(5000);
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "PhotoAlbumCategoryId", "1"));
                    Thread.Sleep(3000);
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoDropDownList').value('{1}')", "PhotoAlbumStatusId", "1"));

                    driver.FindElement(By.Id("AlbumName")).SendKeys("First Test");

                    driver.FindElement(By.Id("CommentsAllowed")).Click();
                    driver.FindElement(By.Id("IsPublic")).Click();

                    var image = driver.FindElement(By.Id("ImageName"));
                    executor.ExecuteScript("arguments[0].click();", image);
                    Thread.Sleep(2000);

                    //Set image name from the dialog
                    SendKeys.SendWait(@"‪Racnet-Logo.jpg");
                    SendKeys.SendWait(@"{Enter}");
                    executor.ExecuteScript(string.Format("$('#{0}').data('kendoEditor').value('{1}')", "Description", "This Description is written using automation."));
                }

                driver.FindElement(By.ClassName("tb-save-32")).Click();
            }

        }

        [Test]
        public void PhotoAlbumDelete()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Photo Galleries")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                var elements = driver.FindElements(By.CssSelector("a[class='Toolbar']"));
                 
                if (elements.Count > 0)
                {
                    Random rnd = new Random();
                    int elementNum = rnd.Next(1, elements.Count + 1);
                    var element = elements[elementNum];

                    if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                    {

                        element.Click();
                        Thread.Sleep(2000);

                        var tooltipElements = driver.FindElements(By.ClassName("tool-container"));
                        var tt = driver.FindElements(By.CssSelector("div[class='tool-container gradient tool-left tool-rounded']"));
                    }

                    var pageId = element.GetAttribute("data-item");
                    driver.Url = "http://client.racsystems.co.za/admin/photoalbum/delete/" + pageId;
                }
            }

            driver.FindElement(By.ClassName("tb-garbage-32")).Click();

        }

        [Test]
        public void PhotoAlbumDetails()
        {
            driver.FindElement(By.Id("AdminCard")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                driver.FindElement(By.LinkText("Photo Galleries")).Click();

            if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
            {
                var elements = driver.FindElements(By.CssSelector("a[class='Toolbar']"));

                if (elements.Count > 0)
                {
                    Random rnd = new Random();
                    int elementNum = rnd.Next(1, elements.Count + 1);
                    var element = elements[elementNum];

                    if (Helpers.CheckIfElementInvisible(By.Id("PageLoader"), driver))
                    {

                        element.Click();
                        Thread.Sleep(2000);

                        var tooltipElements = driver.FindElements(By.ClassName("tool-container"));
                        var tt = driver.FindElements(By.CssSelector("div[class='tool-container gradient tool-left tool-rounded']"));
                    }

                    var pageId = element.GetAttribute("data-item");
                    driver.Url = "http://client.racsystems.co.za/admin/photoalbum/details/" + pageId;
                }
            } 

        }
    }
}