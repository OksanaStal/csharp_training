using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        private GroupData defaultGroup = new GroupData("DefaultGroupName", "DefaultHeader", "DefaultFooter"); 
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                GroupData group = new GroupData(element.Text);
                groups.Add(group);
            }
            return groups;

        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper RemoveTwoGroups(int p, int s)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            SelectGroup(s);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"),group.Header);
            Type(By.Name("group_footer"),group.Footer);
            return this;
        }

        public GroupHelper FillGroupForm()
        {
            Type(By.Name("group_name"), "DefaultGroupName");
            Type(By.Name("group_header"), "DefaultGroupHeader");
            Type(By.Name("group_footer"), "DefaultGroupFooter");
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

         private GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        private GroupHelper SelectGroup(int p)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (p + 1) + "]/input")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public bool IsGroupExist()
        {
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.XPath("//span[@class='group']"));
        }

        public bool AreTwoGroupsExist()
        {
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.XPath("//span[@class='group'][2]"));
        }
    }
}
