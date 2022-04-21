using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class СontaсtCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {

            ContactData contactData = new ContactData("Anna1", "Norbaeva1");
            ContactData contact = contactData;
            contact.Title = "89039532332";
            contact.Address = "Tomsk";
            contact.Email = "ladyann@sibmail.com";
            contact.Company = "VSK1";
            contact.Mobile = "89039532332";
            
            app.contacts.CreateContact(contact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {

            ContactData contactData = new ContactData("", "");
            ContactData contact = contactData;
            contact.Title = "";
            contact.Address = "";
            contact.Email = "";
            contact.Company = "";
            contact.Mobile = "";

            app.contacts.CreateContact(contact);
        }
    }
}
