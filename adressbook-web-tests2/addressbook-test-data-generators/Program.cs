using System;
using System.IO;
using WebAddressbookTests;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string dataType = args[0];
            string filename = args[2];
            string format = args[3];
            if (dataType == "group")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
                }
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }
            else if (dataType == "contacts")
            {
                List<UserData> contacts = new List<UserData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new UserData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
                }
                if (format == "csv")
                {
                    WriteUsersToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    WriteUsersToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteUsersToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized data type " + dataType);
            }
 
            writer.Close();
            
            
        }

        static void WriteUsersToJsonFile(List<UserData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteUsersToXmlFile(List<UserData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<UserData>)).Serialize(writer, contacts);
        }

        static void WriteUsersToCsvFile(List<UserData> contacts, StreamWriter writer)
        {
            foreach (UserData user in contacts)
            {
                writer.WriteLine(String.Format("${0},${1}", user.FirstName, user.LastName));
            }
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}", group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

    }
}
