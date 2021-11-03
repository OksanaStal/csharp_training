using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class UserRemovalTests : UserTestBase
    {
        [Test]
        public void UserRemovalTest()
        {
            List<UserData> oldContacts = UserData.GetAll();
            if (oldContacts.Count == 0)
            {
                UserData user = new UserData("firstName1", "lastName1");
                applicationManager.Contacts.Create(user);
                oldContacts = UserData.GetAll();
            }
            UserData userToRemove = oldContacts[0];
            applicationManager.Contacts.Remove(userToRemove);
            List<UserData> newContacts = UserData.GetAll();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void AllUsersRemovalTest()
        {
            if (UserData.GetAll().Count == 0)
            {
                UserData user = new UserData("firstName1", "lastName1");
                applicationManager.Contacts.Create(user);
            }
            applicationManager.Contacts.RemoveAll();
            List<UserData> newContacts = UserData.GetAll();
            Assert.IsEmpty(newContacts);
        }
    }
}
