using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            applicationManager.Navigator.GoToGroupsPage();
            applicationManager.Groups
                .InitGroupCreation()
                .FillGroupForm(new GroupData("MyNewGroup2", "GroupHeader2", "MyGroupFooter2"))
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
            applicationManager.Logout.Logout();
        }

    }
}

