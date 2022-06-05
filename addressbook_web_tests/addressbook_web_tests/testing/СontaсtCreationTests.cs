using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class СontaсtCreationTests : ContactTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData("new_N");
            ContactData contact = contactData;
            contact.Middlename = "ddd1";
            contact.Lastname = "fff1";

            List<ContactData> oldContact = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contactData = new ContactData("new_new");
            ContactData contact = contactData;
            contact.Middlename = "";
            contact.Lastname = "";

            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }

        [Test]
        public void BadNameContactTest()
        {

            ContactData contact = new ContactData("d'fdf");
            contact.Middlename = "hh'hh";
            contact.Lastname = "jj'jj";

            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.CreateContact(contact);
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
