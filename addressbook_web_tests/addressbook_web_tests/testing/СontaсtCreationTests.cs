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

            ContactData contact = new ContactData("new_new");
            contact.Middlename = "dddddd";
            contact.Lastname = "ffffffff";

            app.contacts.CreateContact(contact);
        }
        [Test]
        public void EmptyContactCreationTest()
        {

            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";

            app.contacts.CreateContact(contact);
        }
    }
}
