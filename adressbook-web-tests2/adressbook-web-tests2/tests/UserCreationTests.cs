using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : AuthTestBase
    {
        public static IEnumerable<UserData> RandomUserDataProvider()
        {
            List<UserData> users = new List<UserData>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new UserData(GenerateRandomString(5), GenerateRandomString(5)));
            }
            return users;
        }

        public static IEnumerable<UserData> UserDataFromCsvFile()
        {
            List<UserData> contacts = new List<UserData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new UserData(parts[0], parts[1]));
            }
            return contacts;
        }

        public static IEnumerable<UserData> UserDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<UserData>>(File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<UserData> UserDataFromXmlFile()
        {
            return (List<UserData>)new XmlSerializer(typeof(List<UserData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        [Test, TestCaseSource("UserDataFromCsvFile")]
        public void UserCreationTest(UserData user)
        {
            List<UserData> oldContacts = applicationManager.Contacts.GetUserList();
            applicationManager.Contacts.Create(user);
            List<UserData> newContacts = applicationManager.Contacts.GetUserList();
            oldContacts.Add(user);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
