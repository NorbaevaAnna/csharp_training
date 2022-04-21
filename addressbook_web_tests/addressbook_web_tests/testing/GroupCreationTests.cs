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
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData = new GroupData("h", "d", "p");
            app.groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData = new GroupData("", "", "");
            app.groups.Create(group);
        }
    }
}

