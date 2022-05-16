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
    public class GroupModificationTests : AuthTestBase
    {    
        [Test]
        public void GroupModificationTest()
        {
        GroupData newData = new GroupData("zz", "zz", "qq");
            app.Groups.Modify(1, newData);
        }
    }
}
