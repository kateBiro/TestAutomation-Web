using OpenQA.Selenium;

namespace TestAutomation_Web.Pages.BadmintonExample
{
    public class FAQPage : WebdriverBase
    {
        private List<Accordian> Accordians { get; set; }
        public FAQPage(WebDriver driver)
        {
            this.driver = driver;

            SetAccordianList();
        }

        //accordian structure
        //get accordian list
        private void SetAccordianList()
        {
            Accordians = new List<Accordian>();

            var classItems = driver.FindElements(By.ClassName("c-accordion__title"));

            int i = 0;

            foreach ( var classItem in classItems )
            {
                var item = new Accordian();

                item.Text = classItem.Text;
                item.Id = classItem.GetAttribute("id");
                item.Number = i;

                Accordians.Add(item);

                i++;

            }
            
        }

        /// <summary>
        /// Find and Validate Open/Close Functionality of All Accordians on page
        /// </summary>
        /// <returns></returns>
        public bool ValidateAccordiansOpen()
        {
            bool pass = true;
            foreach (var accordian in Accordians)
            {
                if (!OpenAccordian(accordian))
                {
                    pass = false; break;
                }
            }

            return pass;
        }

        //open accordian
        private bool OpenAccordian(Accordian accordian)
        {
            //Assume failure:
            bool ok = false;


            string id = accordian.Id.Substring(3, accordian.Id.Length - 3);
            By element = By.Id(accordian.Id);

            driver.FindElement(element).SendKeys("");
            Thread.Sleep(1000);                        

            var content = driver.FindElement(By.Id("ac-" + id));

            Click(element);

            //Is content displayed, only continue if true:
            if(content.Displayed)
            {
                ok = true;

                Click(By.Id(accordian.Id));
                Thread.Sleep(1000);
                //is content hidden again
                if (!content.Displayed)
                {
                    ok = true;
                }
            }      

            //return true only if both actions are true
            return ok;
        }

    };

    public class Accordian
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public string Id { get; set; }
    }
}
