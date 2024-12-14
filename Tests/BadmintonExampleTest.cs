
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
        public void Test()
        {
            home.Navigate(NavButtons.About_Us)
                .Close();

        }
    }
}
