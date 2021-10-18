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
            GroupData group = new GroupData("Group2", "Header2", "Footer2");
            if (!(applicationManager.Groups.IsGroupExist()))
            {
                applicationManager.Groups.Create(group);
            }
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();
            GroupData newData = new GroupData("MyNewGroup5", "GroupHeader5", "MyGroupFooter5");
            applicationManager.Groups.Modify(0, newData);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

       
    }
}
