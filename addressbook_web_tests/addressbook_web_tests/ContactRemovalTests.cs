﻿using System;
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
            GoHomePage();
            Login(new AccountData("admin", "secret"));
            ReturnToHomePage();
            GoHomePage();
            SelectContact();
            RemoveContact();
            ProofRemoveContact();
            ReturnToHomePage();
        }
    }
}

