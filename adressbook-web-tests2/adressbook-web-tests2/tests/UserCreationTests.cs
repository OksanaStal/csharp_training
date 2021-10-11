using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : TestBase
    {
        [Test]
        public void UserCreationTest()
        {
            UserData user = new UserData("firstName2", "lastName2");
            applicationManager.Contacts.Create(user);
        }
    }
}
