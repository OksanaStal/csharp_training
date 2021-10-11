using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class UserRemovalTests : TestBase
    {
        [Test]
        public void UserRemovalTest()
        {
            applicationManager.Contacts.Remove(1);
        }

        [Test]
        public void AllUsersRemovalTest()
        {
            applicationManager.Contacts.RemoveAll();
        }
    }
}
