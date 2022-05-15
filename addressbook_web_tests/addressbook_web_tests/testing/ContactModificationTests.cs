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
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest(ContactData newDataContact)
        {
            newDataContact.Middlename = "yyy";
            newDataContact.Lastname = "f1";
            app.Contacts.ModifyContact(1, newDataContact);
        }
    }
}
