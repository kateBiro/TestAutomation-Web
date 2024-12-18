using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation_Web.Pages.BadmintonExample
{
    public class Navigate : WebdriverBase
    {
        public Navigate(WebDriver driver)
        {
            this.driver = driver;
        }

        public BadmintonHome GoToHome ()
        {
            var button = By.Id("menu-item-" + ((int)NavButtons.Home));

            Click(button);
            return new BadmintonHome(driver);
        }

        public AboutUs GoToAboutUs()
        {
            var button = By.Id("menu-item-" + ((int)NavButtons.About_Us));

            Click(button);
            return new AboutUs(driver);
        }

        public FAQPage GoToFAQ()
        {
            var button = By.Id("menu-item-" + ((int)NavButtons.FAQ));
            //var button = By.Id("menu-item-92");

            Click(button);
            return new FAQPage(driver);
        }

    }
}
