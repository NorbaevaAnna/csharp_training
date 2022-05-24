using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData NewContactData = new ContactData("new_cont");
            NewContactData.Middlename = "555";
            NewContactData.Lastname = "666";

            if (app.Contacts.ThereIsAContacts(1) == false)
                if (!app.Contacts.ThereIsAContacts(1))
                {
                    app.Contacts.CreateContact(new ContactData("Aa1"));
                }
            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.ModifyContact(0, NewContactData);
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact[0].Firstname = NewContactData.Firstname;
            oldContact[0].Lastname = NewContactData.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}
