using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class UserData
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string nickName;
        private string title;
        private string company;
        private string address;
        private string homeTelephone;
        private string mobileTelephone;
        private string workTelephone;
        private string faxTelephone;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private string birthdayDay;
        private string birthdayMonth;
        private string birthdayYear;
        private string anniversaryDay;
        private string anniversaryMonth;
        private string anniversaryYear;
        private string secondaryAddress;
        private string secondaryHome;
        private string notes;

        public UserData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = "defaultMiddleName";
            this.nickName = "defaultNickName";
            this.title = "defaultTitle";
            this.company = "defaultCompany";
            this.address = "defaultAddress";
            this.homeTelephone = "defaultHomeTelephone";
            this.mobileTelephone = "defaultMobileTelephone";
            this.workTelephone = "defaultWorkTelephone";
            this.faxTelephone = "defaultFaxTelephone";
            this.email = "defaultEmail";
            this.email2 = "defaultEmail2";
            this.email3 = "defaultEmail3";
            this.homepage = "defaultHomePage";
            this.birthdayDay = "1";
            this.birthdayMonth = "January";
            this.birthdayYear = "1980";
            this.anniversaryDay = "1";
            this.anniversaryMonth = "January";
            this.anniversaryYear = "2000";
            this.secondaryAddress = "defaultSecondaryAddress";
            this.secondaryHome = "defaultSecondaryHome";
            this.notes = "defaultNotes";
        }       

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName ;
            }
            set
            {
                middleName = value;
            }
        }

        public string NickName
        {
            get
            {
                return nickName;
            }
            set
            {
                nickName = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string HomeTelephone
        {
            get
            {
                return homeTelephone;
            }
            set
            {
                homeTelephone = value;
            }
        }

        public string MobileTelephone
        {
            get
            {
                return mobileTelephone;
            }
            set
            {
                mobileTelephone = value;
            }
        }

        public string WorkTelephone
        {
            get
            {
                return workTelephone;
            }
            set
            {
                workTelephone = value;
            }
        }

        public string FaxTelephone
        {
            get
            {
                return faxTelephone;
            }
            set
            {
                faxTelephone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }

        public string BirthdayDay
        {
            get
            {
                return birthdayDay;
            }
            set
            {
                birthdayDay = value;
            }
        }

        public string BirthdayMonth
        {
            get
            {
                return birthdayMonth;
            }
            set
            {
                birthdayMonth = value;
            }
        }

        public string BirthdayYear
        {
            get
            {
                return birthdayYear;
            }
            set
            {
                birthdayYear = value;
            }
        }

        public string AnniversaryDay
        {
            get
            {
                return anniversaryDay;
            }
            set
            {
                anniversaryDay = value;
            }
        }

        public string AnniversaryMonth
        {
            get
            {
                return anniversaryMonth;
            }
            set
            {
                anniversaryMonth = value;
            }
        }

        public string AnniversaryYear
        {
            get
            {
                return anniversaryYear;
            }
            set
            {
                anniversaryYear = value;
            }
        }

        public string SecondaryAddress
        {
            get
            {
                return secondaryAddress;
            }
            set
            {
                secondaryAddress = value;
            }
        }

        public string SecondaryHome
        {
            get
            {
                return secondaryHome;
            }
            set
            {
                secondaryHome = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        

    }
}
