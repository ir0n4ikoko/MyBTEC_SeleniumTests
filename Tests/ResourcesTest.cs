using NUnit.Framework;

namespace Edi.Advance.BTEC.UiTests.Tests
{
    public class ResourcesTest : TestBase
    {
        [Test]
        [TestCase("test_assessor@learntodive.org.uk", "5B56C3E")]
        [TestCase("test_internalverifier@learntodive.org.uk", "C9D4D43")]
        [TestCase("test_courseleader@learntodive.org.uk", "2CD767B")]
        [TestCase("test_leadinternalverifier@learntodive.org.uk", "D65D939")]
        [TestCase("test_qn@learntodive.org.uk", "FBE4BD5")]
        [TestCase("test_teacher@learntodive.org.uk", "67546B6")]
        [TestCase("test_2@learntodive.org.uk", "D374B8D")]
        public void CheckCentreUsersCanSeeResources(string login, string password)
        {
            Start
                .LoginWithAndGoToHomePage(login, password)
                .CheckBasketBox(false)
                .GoToResources();
        }

        [Test]
        [TestCase("test_ddm@learntodive.org.uk", "7FF2F6A")]
        [TestCase("test_editor@learntodive.org.uk", "4CDABFC")]
        [TestCase("test_tester@learntodive.org.uk", "335A7F6")]
        public void CheckPearsonUsersCanSeeResources(string login, string password)
        {
            Start
                .LoginWithAndGoToHomePage(login, password)
                .CheckBasketBox(false)
                .GoToResources();
        }

        [Test]
        [TestCase("test_support@learntodive.org.uk", "C38AB37")]
        [TestCase("test_pearsonmanager@learntodive.org.uk", "FBEF932")]
        public void CheckUsersCanNotSeeResources(string login, string password)
        {
            Start
                .LoginWithAndGoToHomePage(login, password)
                .CheckBasketBox(false)
                .CheckResourcesNotAccessible();
        }
    }
}