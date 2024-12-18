using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation_Web.Pages.BadmintonExample;

namespace TestAutomation_Web
{
    public class WebdriverBase
    {
        protected WebDriver driver;
        protected WebDriverWait wait;

        public WebdriverBase()
        {
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        }

        public WebdriverBase(WebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

        }

        public bool IsDisplayed(By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            } 
            catch(NoSuchElementException)
            {
                return false;
            }
        }

        protected void WaitUntilDisplayed(By by)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(driver => IsDisplayed(by));
           
        }

        public WebdriverBase GoTo(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            return this;
        }

        public void Close()
        {
            driver.Close();
        }

        public void Click(By element)
        {
            try
            {
                driver.FindElement(element).Click();

            }
            catch (ElementClickInterceptedException e)
            {
                Console.WriteLine(element.ToString() + " " + e.Message);
            }
        }

        public string Title()
        {
            var title = driver.FindElement(By.ClassName("entry-title"));
            return title.Text;
        }

        public Navigate Navigate()
        {
            return new Navigate(driver);
        }

    }
}
