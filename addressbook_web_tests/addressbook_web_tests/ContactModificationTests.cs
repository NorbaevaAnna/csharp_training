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
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newDataContact = new ContactData("rrr");
            newDataContact.Middlename = "yyy";
            newDataContact.Lastname = "f1";

            app.contacts.ModifyContact(1, newDataContact);
        }
    }
}
