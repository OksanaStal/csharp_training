using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("MyNewGroup2", "GroupHeader2", "MyGroupFooter2");
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            applicationManager.Groups.Create(group);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("", "", "");
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            applicationManager.Groups.Create(group);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}

