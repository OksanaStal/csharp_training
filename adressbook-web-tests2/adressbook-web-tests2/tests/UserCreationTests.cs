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
        public static IEnumerable<UserData> RandomUserDataProvider()
        {
            List<UserData> users = new List<UserData>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new UserData(GenerateRandomString(5), GenerateRandomString(5)));
            }
            return users;
        }

        [Test, TestCaseSource("RandomUserDataProvider")]
        public void UserCreationTest(UserData user)
        {
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
