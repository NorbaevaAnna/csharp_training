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
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.ReturnToHomePage();
            app.Navigator.GoHomePage();
            app.Contacts.SelectContact();
            app.Contacts.RemoveContact();
            app.Contacts.ProofRemoveContact();
            app.Navigator.ReturnToHomePage();
        }
    }
}

