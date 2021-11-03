using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class UserModificationTests : UserTestBase
    {
        [Test]
        public void UserModificationTest()
        {
            UserData newUserData = new UserData("NewfirstName2", "NewlastName2");
            List<UserData> oldContacts = UserData.GetAll();
            if (oldContacts.Count() == 0)
            {
                UserData user = new UserData("firstName1", "lastName1");
                applicationManager.Contacts.Create(user);
                oldContacts = UserData.GetAll();
            }
            UserData userToModify = oldContacts[0];
            applicationManager.Contacts.Modify(userToModify, newUserData);
            List<UserData> newContacts = UserData.GetAll();
            userToModify.FirstName = newUserData.FirstName;
            userToModify.LastName = newUserData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
