using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation_Web
{
    public class WebdriverBase
    {
        protected WebDriver driver;

        public WebdriverBase()
        {

        }

        public WebdriverBase(WebDriver driver)
        {
            this.driver = driver;
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
            driver.FindElement(element).Click();
        }

        public string Title()
        {
            var title = driver.FindElement(By.ClassName("entry-title"));
            return title.Text;
        }
    }
}
