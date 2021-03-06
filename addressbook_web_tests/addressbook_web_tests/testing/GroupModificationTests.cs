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

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {    
        [Test]
        public void GroupModificationTest()
        {
        GroupData newData = new GroupData("zz");
            newData.Footer = "xx";
            newData.Header = "cc";

            if (!app.Groups.ThereIsAGroup(1))
            {
                app.Groups.Create(new GroupData("zz1"));
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            List<GroupData> newGroups = app.Groups.GetGroupList();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
