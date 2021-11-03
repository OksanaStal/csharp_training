using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert = true;

        public UserData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePageViaLink();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new UserData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails                
            };
        }

        public UserData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePageViaLink();
            InitiateUserModificate(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string secondaryPhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");

            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string birthDay = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string birthMonth = FirstLetterToUpper(driver.FindElement(By.Name("bmonth")).GetAttribute("value"));
            string birthYear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string aDay = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string aMonth = FirstLetterToUpper(driver.FindElement(By.Name("amonth")).GetAttribute("value"));
            string aYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string secondaryAddress = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");


            return new UserData(firstName, lastName)
            {
                Address = address,
                HomeTelephone = homePhone,
                MobileTelephone = mobilePhone,
                WorkTelephone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                SecondaryHome = secondaryPhone,
                MiddleName = middleName,
                NickName = nickName,
                Company = company,
                Title = title,
                FaxTelephone = fax,
                Homepage = homepage,
                BirthdayDay = birthDay,
                BirthdayMonth = birthMonth,
                BirthdayYear = birthYear,
                AnniversaryDay = aDay,
                AnniversaryMonth = aMonth,
                AnniversaryYear = aYear,
                SecondaryAddress = secondaryAddress,
                Notes = notes,
            };
        }

        private string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper(); ;
        }

        internal UserData GetContactInformationFromDetailsPage(int index)
        {
            manager.Navigator.GoToHomePageViaLink();
            OpenUserDetailsPage(index);
            string fullInfoAboutUser = driver.FindElement(By.Id("content")).Text;
            return new UserData()
            {
                AllInfoFormattedForDetalesPage = fullInfoAboutUser,
            };    
        }

        private ContactHelper OpenUserDetailsPage(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/table/tbody/tr[" + (index + 2) + "]//img[@title=\"Details\"]")).Click();
            return this;
        }

        private UserData defaultUser = new UserData("defaultFirstName", "defaultLastName");

        private List<UserData> userCache = null;

        public List<UserData> GetUserList()
        {
            if (userCache == null)
            {
                userCache = new List<UserData>();
                manager.Navigator.GoToHomePageViaLink();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                if (elements.Count > 0)
                {
                    foreach (IWebElement element in elements)
                    {
                        IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                        UserData user = new UserData(cells.ElementAt(2).Text, cells.ElementAt(1).Text);
                        userCache.Add(user);
                    }
                }
            }
            return userCache;
        }

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper RemoveAll()
        {
            manager.Navigator.GoToHomePageViaLink();
            if (NoContacts())
            {
                Create(defaultUser);
            }
            SelectAllUsers();
            RemoveUser();
            manager.Navigator.GoToHomePageViaLink();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePageViaLink();
            SelectUser(p);
            RemoveUser();
            manager.Navigator.GoToHomePageViaLink();
            return this;
        }

        public ContactHelper Remove(UserData userToDelete)
        {
            manager.Navigator.GoToHomePageViaLink();
            SelectUser(userToDelete.Id);
            RemoveUser();
            manager.Navigator.GoToHomePageViaLink();
            return this;
        }

        public ContactHelper Create(UserData user)
        {
            manager.Navigator.GoToHomePageViaLink();
            InitUserCreation();
            FillUserForm(user);
            SubmitUserCreation();
            manager.Navigator.GoToHomePageViaLink();
            return this;
        }

        public ContactHelper Modify(int p, UserData newUserData)
        {
            manager.Navigator.GoToHomePageViaLink();
            InitiateUserModificate(p);
            FillUserForm(newUserData);
            SubmitUserModification();
            manager.Navigator.GoToHomePageViaLink();
            return this;
        }

        public ContactHelper Modify(UserData userToModify, UserData newUserData)
        {
            manager.Navigator.GoToHomePageViaLink();
            InitiateUserModificate(userToModify.Id);
            FillUserForm(newUserData);
            SubmitUserModification();
            manager.Navigator.GoToHomePageViaLink();
            return this;
        }

        public ContactHelper SubmitUserModification()
        {
            driver.FindElement(By.Name("update")).Click();
            userCache = null;
            return this;
        }

        public ContactHelper InitiateUserModificate(int p)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/table/tbody/tr[" + (p + 2) + "]//img[@title=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper InitiateUserModificate(string id)
        {
            //driver.FindElement(By.XPath("//div[@id='content']/form/table/tbody/tr[" + (p + 2) + "]//img[@title=\"Edit\"]")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form/table/tbody/tr/td/input[@type='checkbox' and @id='" + id + "']/../..//img[@title='Edit']")).Click();
            return this;
        }

        public ContactHelper InitUserCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        
        public ContactHelper FillUserForm(UserData user)
        {
            Type(By.Name("firstname"), user.FirstName);
            Type(By.Name("middlename"), user.MiddleName);
            Type(By.Name("lastname"), user.LastName);
            Type(By.Name("nickname"), user.NickName);
            Type(By.Name("title"), user.Title);
            Type(By.Name("company"), user.Company);
            Type(By.Name("address"), user.Address);
            Type(By.Name("home"), user.HomeTelephone);
            Type(By.Name("mobile"), user.MobileTelephone);
            Type(By.Name("work"), user.WorkTelephone);
            Type(By.Name("fax"), user.FaxTelephone);
            Type(By.Name("email"), user.Email);
            Type(By.Name("email2"), user.Email2);
            Type(By.Name("email3"), user.Email3);
            Type(By.Name("homepage"), user.Homepage);
            //Type(By.Name("photo"), "C:\\AutoTesting\\Foto.jpg");
            SelectFromList(By.Name("bday"), user.BirthdayDay);
            SelectFromList(By.Name("bmonth"), user.BirthdayMonth);
            Type(By.Name("byear"), user.BirthdayYear);
            SelectFromList(By.Name("aday"), user.AnniversaryDay);
            SelectFromList(By.Name("amonth"), user.AnniversaryMonth);
            Type(By.Name("ayear"), user.AnniversaryYear);
            Type(By.Name("address2"), user.SecondaryAddress);
            Type(By.Name("phone2"), user.SecondaryHome);
            Type(By.Name("notes"), user.Notes);
            return this;
        }

        public ContactHelper SubmitUserCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            userCache = null;
            return this;
        }

        public ContactHelper RemoveUser()
        {
            driver.FindElement(By.XPath("//input[@type='button' and @value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete . addresses[\\s\\S]$"));
            driver.FindElement(By.CssSelector("div.msgbox"));
            userCache = null;
            return this;
        }

        public ContactHelper SelectUser(int p)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/table//tr[" + (p+2) +"]/td/input")).Click();
            return this;
        }

        public ContactHelper SelectUser(string id)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/table//tr/td/input[@id=" + id + " and @type='checkbox']")).Click();
            return this;
        }

        public ContactHelper SelectAllUsers()
        {
            driver.FindElement(By.XPath("//input[@id='MassCB']")).Click();
            return this;
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public bool NoContacts()
        {
            manager.Navigator.GoToHomePageViaLink();
            return IsElementPresent(By.XPath("//strong[contains(text(),'Number of results: ')]/span[@id=\"search_count\"][.='0']"));
        } 
    }
}
