using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData tempGroup = new GroupData("Group2", "Header2", "Footer2");
            List<GroupData> oldGroups = GroupData.GetAll();
            if (oldGroups.Count == 0)
            {
                applicationManager.Groups.Create(tempGroup);
                oldGroups = GroupData.GetAll();
            }
            GroupData oldData = oldGroups[0];
            GroupData newData = new GroupData("MyNewGroup5", "GroupHeader5", "MyGroupFooter5");
            applicationManager.Groups.Modify(oldData, newData);
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }

       
    }
}
