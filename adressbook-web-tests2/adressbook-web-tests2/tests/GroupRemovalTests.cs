using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void FirstGroupRemovalTest()
        {
            if (!(applicationManager.Groups.IsGroupExist()))
            {
                GroupData group = new GroupData("MyNewGroup2", "GroupHeader2", "MyGroupFooter2");
                applicationManager.Groups.Create(group);
            }
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            applicationManager.Groups.Remove(0);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }

        [Test]
        public void TwoGroupsRemovalTest()
        {
            GroupData group = new GroupData("MyNewGroup2", "GroupHeader2", "MyGroupFooter2");

            if (!(applicationManager.Groups.IsGroupExist()))
            {
                applicationManager.Groups.Create(group);
                applicationManager.Groups.Create(group);
            }
            else
            {
                if (!(applicationManager.Groups.AreTwoGroupsExist()))
                {
                    applicationManager.Groups.Create(group);
                }
            }
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            applicationManager.Groups.RemoveTwoGroups(0,1);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups.RemoveRange(0, 2);
            Assert.AreEqual(oldGroups, newGroups);
        }


    }
}
