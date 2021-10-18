using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class UserModificationTests : AuthTestBase
    {
        [Test]
        public void UserModificationTest()
        {
            if (applicationManager.Contacts.NoContacts())
            {
                UserData user = new UserData("firstName1", "lastName1");
                applicationManager.Contacts.Create(user);
            }
            UserData newUserData = new UserData("NewfirstName2", "NewlastName2");
            List<UserData> oldContacts = applicationManager.Contacts.GetUserList();
            applicationManager.Contacts.Modify(0, newUserData);
            List<UserData> newContacts = applicationManager.Contacts.GetUserList();
            oldContacts[0].FirstName = newUserData.FirstName;
            oldContacts[0].LastName = newUserData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
