using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void FirstGroupRemovalTest()
        {
            
            List<GroupData> oldGroups = GroupData.GetAll();
            if (oldGroups.Count == 0)
            {
                GroupData group = new GroupData("MyNewGroup2", "GroupHeader2", "MyGroupFooter2");
                applicationManager.Groups.Create(group);
                oldGroups = GroupData.GetAll();
            }
            GroupData toBeRemoved = oldGroups[0];
            applicationManager.Groups.Remove(toBeRemoved);
            List<GroupData> newGroups = GroupData.GetAll();
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

            List<GroupData> oldGroups = GroupData.GetAll();
            if (oldGroups.Count <= 1)
            {
                applicationManager.Groups.Create(group);
                if (oldGroups.Count == 0)
                {
                    applicationManager.Groups.Create(group);
                }
                oldGroups = GroupData.GetAll();
            }
            GroupData toBeRemoved1 = oldGroups[0];
            GroupData toBeRemoved2 = oldGroups[1];
            applicationManager.Groups.RemoveTwoGroups(oldGroups[0], oldGroups[1]);
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.RemoveRange(0, 2);
            Assert.AreEqual(oldGroups, newGroups);
        }


    }
}
