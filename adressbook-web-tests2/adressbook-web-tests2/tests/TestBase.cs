using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;

        [SetUp]
        protected void SetupTest()
        {
            applicationManager = new ApplicationManager();
            applicationManager.Navigator.OpenHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        protected void TeardownTest()
        {
            applicationManager.Stop();   
        }
    }
}
