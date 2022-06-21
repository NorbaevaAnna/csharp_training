using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allData;
        public ContactData(string firstname)
        {
            Firstname = firstname;
        }

        public ContactData()
        {
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname
                 && Lastname == other.Lastname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return " Firstname = " + Firstname + "\n" + "Lastname=" + Lastname;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname) != 0 ? Firstname.CompareTo(other.Firstname) : Lastname.CompareTo(other.Lastname);
        }
        private string CleanUp(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            return Regex.Replace(value, "[ ()-]", "") + "\r\n";
        }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string NickName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string FaxPhone { get; set; }
        public string Id { get; internal set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set { allPhones = value; }
        }

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
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set { allEmails = value; }
        }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    return
                    DetailFullNameBlock(Firstname, Middlename, Lastname) +
                    DetailFields(DetailFullNameBlock(Firstname, Middlename, Lastname), NickName) +
                    DetailFields(NickName, Address) +
                    DetailPhonesBlock(HomePhone, MobilePhone, WorkPhone, FaxPhone) +
                    DetailEmailsBlock(Email, Email2, Email3);
                }
            }
            set { allData = value; }
        }

        private string DetailPhonesBlock(string homePhone, string mobilePhone, string workPhone, string faxPhone)
        {
            string phones = "\r\n";
            if (homePhone == null || homePhone == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"\r\nH: {homePhone}";
            }
            if (mobilePhone == null || mobilePhone == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"\r\nM: {mobilePhone}";
            }
            if (workPhone == null || workPhone == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"\r\nW: {workPhone}";
            }
            if (faxPhone == null || faxPhone == "")
            {
                phones += $"";
            }
            else
            {
                phones += $"\r\nF: {faxPhone}";
            }
            if ((homePhone == null || homePhone == "") && (mobilePhone == null || mobilePhone == "") && (workPhone == null || workPhone == "") && (faxPhone == null || faxPhone == ""))
            {
                return $"";
            }
            else
            {
                return phones;
            }
        }

        private string DetailEmailsBlock(string email, string email2, string email3)
        {
            string emails = "\r\n";
            if (email == null || email == "")
            {
                emails += $"";
            }
            else
            {
                emails += $"\r\n{email}";
            }
            if (email2 == null || email2 == "")
            {
                emails += $"";
            }
            else
            {
                emails += $"\r\n{email2}";
            }
            if (email3 == null || email3 == "")
            {
                emails += $"";
            }
            else
            {
                emails += $"\r\n{email3}";
            }
            if ((email == null || email == "") && (email2 == null || email2 == "") && (email3 == null || email3 == ""))
            {
                return $"";
            }
            else
            {
                return emails;
            }
        }

        public string DetailFields(string beforefield, string value)
        {
            if (value == null || value == "")
            {
                return $"";
            }
            else
            {
                if (beforefield == null || beforefield == "")
                {
                    return $"{value}";
                }
                else
                {
                    return $"\r\n{value}";
                }
            }
        }
        public string DetailFullNameBlock(string firstname, string middlename, string lastname)
        {
            string fullname = $"";

            if (firstname == null || firstname == "")
            {
                fullname += $"";
            }
            else
            {
                fullname += $"{firstname}";
            }

            if (middlename == null || middlename == "")
            {
                fullname += $"";
            }
            else
            {
                if (firstname == null || firstname == "")
                {
                    fullname += $"{middlename}";
                }
                else
                {
                    fullname += $" {middlename}";
                }
            }

            if (lastname == null || lastname == "")
            {
                fullname += $"";
            }
            else
            {
                if ((firstname == null || firstname == "") && (middlename == null || middlename == ""))
                {
                    fullname += $"{lastname}";
                }
                else
                {
                    fullname += $" {lastname}";
                }
            }
            return fullname;
        }
    }
}
