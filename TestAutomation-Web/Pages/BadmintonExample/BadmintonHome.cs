using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace TestAutomation_Web.Pages.BadmintonExample
{
    public class BadmintonHome : WebdriverBase
    {
        string homeUrl = "https://www.cambridgebadmintonclub.com/";
        //WebDriver driver;


        public BadmintonHome()
        {

            var config = new ChromeConfig();

            new DriverManager().SetUpDriver(config);

            driver = new ChromeDriver();

            GoTo(homeUrl);
        }
        public BadmintonHome(WebDriver driver)
        {
            this.driver = driver;
        }

        public WebdriverBase Navigate(NavButtons navButtons)
        {
            var button = By.Id("menu-item-" + ((int)navButtons));

            Click(button);

            switch (navButtons)
            {
                case NavButtons.Home:
                    return new BadmintonHome(driver);
                case NavButtons.About_Us:
                    return new AboutUs(driver);
                case NavButtons.FAQ:
                    return new FAQPage(driver);
            }

            return this;
        }


    }

    public enum NavButtons
    {
        Home = 24,
        About_Us = 21,
        Membership = 112,
        Events,
        House_League,
        FAQ,
        Contact_Us
    }
}
