using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        private string allPhones;
        private string allEmails;
        private string allInfoFormattedForDetailsPage;
        StringBuilder sb;
        Boolean flagDataIsPresent;
        Boolean flagDataInLineIsPresent;
        Boolean noBirthdayAnniversaryDay;

        public UserData()
        {
            FirstName = "defaultFirstName";
            LastName = "defaultLastName";
            MiddleName = "defaultMiddleName";
            NickName = "defaultNickName";
            Title = "defaultTitle";
            Company = "defaultCompany";
            Address = "defaultAddress";
            HomeTelephone = "defaultHomeTelephone";
            MobileTelephone = "defaultMobileTelephone";
            WorkTelephone = "defaultWorkTelephone";
            FaxTelephone = "defaultFaxTelephone";
            Email = "defaultEmail";
            Email2 = "defaultEmail2";
            Email3 = "defaultEmail3";
            Homepage = "defaultHomePage";
            BirthdayDay = "1";
            BirthdayMonth = "January";
            BirthdayYear = "1980";
            AnniversaryDay = "1";
            AnniversaryMonth = "January";
            AnniversaryYear = "2000";
            SecondaryAddress = "defaultSecondaryAddress";
            SecondaryHome = "defaultSecondaryHome";
            Notes = "defaultNotes";
        }
        public UserData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = "defaultMiddleName";
            NickName = "defaultNickName";
            Title = "defaultTitle";
            Company = "defaultCompany";
            Address = "defaultAddress";
            HomeTelephone = "defaultHomeTelephone";
            MobileTelephone = "defaultMobileTelephone";
            WorkTelephone = "defaultWorkTelephone";
            FaxTelephone = "defaultFaxTelephone";
            Email = "defaultEmail";
            Email2 = "defaultEmail2";
            Email3 = "defaultEmail3";
            Homepage = "defaultHomePage";
            BirthdayDay = "1";
            BirthdayMonth = "January";
            BirthdayYear = "1980";
            AnniversaryDay = "1";
            AnniversaryMonth = "January";
            AnniversaryYear = "2000";
            SecondaryAddress = "defaultSecondaryAddress";
            SecondaryHome = "defaultSecondaryHome";
            Notes = "defaultNotes";
        }

        public bool Equals(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName && LastName == LastName);
        }

        override public int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        override public string ToString()
        {
            return "user = " + FirstName + " " + LastName;
        }

        public int CompareTo(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            else
            {
                return LastName.CompareTo(other.LastName);
            }
        }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomeTelephone { get; set; }

        [Column(Name = "mobile")]
        public string MobileTelephone { get; set; }

        [Column(Name = "work")]
        public string WorkTelephone { get; set; }

        [Column(Name = "fax")]
        public string FaxTelephone { get; set; }

        public string AllPhones 
        {
            get 
            { 
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomeTelephone) + CleanUp(MobileTelephone) + CleanUp(WorkTelephone) + CleanUp(SecondaryHome)).Trim();
                }
            }
            set
            {
                allPhones = value;
            } 
        }

        
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(phone, "[ --()]", "") + "\r\n";
            }
        }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (TransformEmail(Email) + TransformEmail(Email2) + TransformEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string TransformEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            else
            {
                return email + "\r\n";
            }
        }

        public string AllInfoFormattedForDetalesPage
        {
            get
            {
                if (allInfoFormattedForDetailsPage != null)
                {
                    return allInfoFormattedForDetailsPage;
                }
                else
                {
                    flagDataIsPresent = false;
                    flagDataInLineIsPresent = false;
                    noBirthdayAnniversaryDay = true;
                    sb = new StringBuilder("");
                    AddRecord(this.FirstName);
                    AddRecord(this.MiddleName);
                    AddRecord(this.LastName);
                    FinishLineWithFIO();
                    AddRecordWithNewLine(this.NickName);
                    AddRecordWithNewLine(this.Title);
                    AddRecordWithNewLine(this.Company);
                    AddRecordWithNewLine(this.Address);
                    AddNewLine();
                    AddRecordWithNewLine("H: ", this.HomeTelephone);
                    AddRecordWithNewLine("M: ", this.MobileTelephone);
                    AddRecordWithNewLine("W: ", this.WorkTelephone);
                    AddRecordWithNewLine("F: ", this.FaxTelephone);
                    AddNewLine();
                    AddRecordWithNewLine(this.Email);
                    AddRecordWithNewLine(this.Email2);
                    AddRecordWithNewLine(this.Email3);
                    if (this.Homepage != "")
                    {
                        AddRecordWithNewLine("Homepage:");
                    }
                    AddRecordWithNewLine(this.Homepage);
                    AddNewLine();
                    AddRecordWithNewLine("Birthday ", FormatDateWithAge(this.BirthdayDay, this.BirthdayMonth, this.BirthdayYear));
                    AddRecordWithNewLine("Anniversary ", FormatDateWithAge(this.AnniversaryDay, this.AnniversaryMonth, this.AnniversaryYear));
                    AddNewLine();
                    if (noBirthdayAnniversaryDay)
                    {
                        sb.Append("\r\n");
                        flagDataIsPresent = false;
                    }
                    AddRecordWithNewLine(this.SecondaryAddress);
                    AddNewLine();
                    AddRecordWithNewLine("P: ", this.SecondaryHome);
                    AddNewLine();
                    sb.Append(this.Notes);
                    return sb.ToString().Trim();
                }
            }
            set
            {
                allInfoFormattedForDetailsPage = value;
            }
        }

        private string FormatDateWithAge(string day, string month, string year)
        {
            string result = "";
            
            if (day != "0")
            {
                result = day + ". ";
            }
            if (month != "-")
            {
                result = result + month + " ";
            }
            if (year != "")
            {
                result = result + year + " (" + CalculateAge(day, month, year) + ")";
            }
            if (result != "")
            {
                noBirthdayAnniversaryDay = false;
            }
            return result.Trim();
        }

        private string CalculateAge(string day, string month, string year)
        {
            if (day == "0")
            {
                day = "1";
            }
            if (month == "-")
            {
                month = "January";
            }
            DateTime birth = DateTime.Parse(day + " " + month + " " + year);
            DateTime today = DateTime.Today;
            int age = today.Year - birth.Year;
            if (today.Month < birth.Month ||
                ((today.Month == birth.Month) && (today.Day < birth.Day)))
            {
                age--;  
            }

            return age.ToString(); 
        }

        private void AddRecord(string str)
        {
            if (str != "")
            {
                if (flagDataInLineIsPresent)
                {
                    sb.Append(" ");
                }
                sb.Append(str);
                flagDataInLineIsPresent = true;
                flagDataIsPresent = true;
            }
        }
        private void AddRecordWithNewLine(string str)
        {
            AddRecordWithNewLine("", str);
        }

        private void AddRecordWithNewLine(string prefix, string str)
        {
            if (str != "")
            {
                sb.Append(prefix);
                sb.Append(str);
                sb.Append("\r\n");
                flagDataInLineIsPresent = false;
                flagDataIsPresent = true;
            }
        }

        private void FinishLineWithFIO()
        {
            if (flagDataIsPresent)
            {
                sb.Append("\r\n");
                flagDataInLineIsPresent = false;
            }
        }
        private void AddNewLine()
        {
            if (flagDataIsPresent)
            {
                sb.Append("\r\n");
                flagDataIsPresent = false;
                flagDataInLineIsPresent = false;
            }
        }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string BirthdayDay { get; set; }

        [Column(Name = "bmonth")]
        public string BirthdayMonth { get; set; }

        [Column(Name = "byear")]
        public string BirthdayYear { get; set; }

        [Column(Name = "aday")]
        public string AnniversaryDay { get; set; }

        [Column(Name = "amonth")]
        public string AnniversaryMonth { get; set; }

        [Column(Name = "ayear")]
        public string AnniversaryYear { get; set; }

        [Column(Name = "address2")]
        public string SecondaryAddress { get; set; }

        [Column(Name = "phone2")]
        public string SecondaryHome { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<UserData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from u in db.Contacts select u).ToList();
            }
        }

    }
}
