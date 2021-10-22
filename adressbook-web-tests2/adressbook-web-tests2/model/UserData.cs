using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        private string allPhones;
        private string allEmails;

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

        public string FirstName { get; set; }
           
        public string LastName { get; set; }
        

        public string MiddleName { get; set; }
       
        public string NickName { get; set; }
       
        public string Title { get; set; }
        
        public string Company { get; set; }
        
        public string Address { get; set; }
        
        public string HomeTelephone { get; set; }
        
        public string MobileTelephone { get; set; }
        
        public string WorkTelephone { get; set; }
        
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

        public string Email { get; set; }
        
        public string Email2 { get; set; }
        
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

        public string Homepage { get; set; }
        
        public string BirthdayDay { get; set; }
        
        public string BirthdayMonth { get; set; }
        
        public string BirthdayYear { get; set; }
        
        public string AnniversaryDay { get; set; }
        
        public string AnniversaryMonth { get; set; }
        
        public string AnniversaryYear { get; set; }
        
        public string SecondaryAddress { get; set; }
        
        public string SecondaryHome { get; set; }
        

        public string Notes { get; set; }
 
    }
}
