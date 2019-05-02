using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BJL.DVDCentral.BL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void SeedTest()
        {
            User user = new User();
            user.Seed();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LoginTestSucceed()
        {
            User user = new User("b-lemke", "maple");
            Assert.IsTrue(user.Login());
        }

        [TestMethod]
        public void LoginTestFail()
        {
            try
            {

                User user = new User("b-lemke", "pine");
                bool login = false;
                login = user.Login();

                Assert.Fail("Fail");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Cannot login with these credentials. We are watching you. IP address logged. Goodbye.", ex.Message);
            }

        }
    }
}
