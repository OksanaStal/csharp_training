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
            applicationManager.Groups.Remove(1);
        }

        [Test]
        public void TwoGroupsRemovalTest()
        {
            applicationManager.Groups.RemoveTwoGroups(1,2);
        }


    }
}
