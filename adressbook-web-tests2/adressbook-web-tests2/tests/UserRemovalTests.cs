using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class UserRemovalTests : AuthTestBase
    {
        [Test]
        public void UserRemovalTest()
        {
            if (applicationManager.Contacts.NoContacts())
            {
                UserData user = new UserData("firstName1", "lastName1");
                applicationManager.Contacts.Create(user);
            }
            List<UserData> oldContacts = applicationManager.Contacts.GetUserList();
            applicationManager.Contacts.Remove(0);
            List<UserData> newContacts = applicationManager.Contacts.GetUserList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void AllUsersRemovalTest()
        {
            if (applicationManager.Contacts.NoContacts())
            {
                UserData user = new UserData("firstName1", "lastName1");
                applicationManager.Contacts.Create(user);
            }
            applicationManager.Contacts.RemoveAll();
            List<UserData> newContacts = applicationManager.Contacts.GetUserList();
            Assert.IsEmpty(newContacts);
        }
    }
}
