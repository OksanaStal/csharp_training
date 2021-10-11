using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class UserModificationTests : TestBase
    {
        [Test]
        public void UserModificationTest()
        {
            UserData newUserData = new UserData("NewfirstName2", "NewlastName2");
            applicationManager.Contacts.Modify(1, newUserData);
        }

    }
}
