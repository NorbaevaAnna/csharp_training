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
    public class СontaсtCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {

            ContactData contactData = new ContactData("new_new");
            ContactData contact = contactData;
            contact.Middlename = "dddddd";
            contact.Lastname = "ffffffff";

            app.Contacts.CreateContact(contact);
        }
        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contactData = new ContactData("new_new");
            ContactData contact = contactData;
            contact.Middlename = "";
            contact.Lastname = "";

            app.Contacts.CreateContact(contact);
        }
    }
}
