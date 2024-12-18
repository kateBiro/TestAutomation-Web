
namespace Tests
{
    public class BadmintonExampleTest
    {
        BadmintonHome home;

        [SetUp]
        public void SetUp()
        {
            home = new BadmintonHome();
        }

        [Test]
        public void AboutUsPage()
        {
            var title = home
                .Navigate()
                .GoToAboutUs()
                .Title()
                ;
            Console.WriteLine("Title: " + title);
            Assert.That(title == "About Us");

        }

        [Test]
        public void RegistrationPage()
        {
            var title = home
                .Navigate(NavButtons.Membership)
                .Title();
            Console.WriteLine("Title: " + title);
            Assert.That(title == "Register for Badminton");
        }

        [Test]
        [TestCase(NavButtons.About_Us, "About Us")]
        [TestCase(NavButtons.Membership, "Register for Badminton")]
        public void PageTitles(NavButtons navbuttons, string title)
        {
            var titleValue = home
                .Navigate(navbuttons)
                .Title();

            Console.WriteLine("Expect Title: " + title);
            Console.WriteLine("Actual Title: " + titleValue);
            Assert.That(titleValue == title);
        }

        [Test]
        public void AccordianOpenFunctional()
        {

            Assert.That(home.Navigate()
                .GoToFAQ()
                .ValidateAccordiansOpen());

        }

        [TearDown]
        public void TearDown()
        {
            home.Close();
        }
    }
}
