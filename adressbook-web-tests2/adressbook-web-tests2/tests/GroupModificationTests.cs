using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData tempGroup = new GroupData("Group2", "Header2", "Footer2");
            if (!(applicationManager.Groups.IsGroupExist()))
            {
                applicationManager.Groups.Create(tempGroup);
            }
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];
            GroupData newData = new GroupData("MyNewGroup5", "GroupHeader5", "MyGroupFooter5");
            applicationManager.Groups.Modify(0, newData);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
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
