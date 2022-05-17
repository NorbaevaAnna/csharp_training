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

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newDataContact = new ContactData("test_updated")
            {
                Middlename = "yyy",
                Lastname = "f1"
            };
            app.Contacts.ModifyContact(1, newDataContact);

            if (!app.Contacts.ThereIsAContacts(1))
            {
                app.Contacts.CreateContact(new ContactData("zz1"));
            }
        }
    }
}
