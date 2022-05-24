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
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.ThereIsAContacts(1))
            {
                app.Contacts.CreateContact(new ContactData("Aa1"));
            }
            List<ContactData> oldContact = app.Contacts.GetContactList();
            app.Contacts.RemoveContact(0);
            List<ContactData> newContact = app.Contacts.GetContactList();
            oldContact.RemoveAt(0);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
        }
    }
}

