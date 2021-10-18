using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : AuthTestBase
    {
        [Test]
        public void UserCreationTest()
        {
            UserData user = new UserData("firstName2", "lastName2");
            List<UserData> oldContacts = applicationManager.Contacts.GetUserList();
            applicationManager.Contacts.Create(user);
            List<UserData> newContacts = applicationManager.Contacts.GetUserList();
            oldContacts.Add(user);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
