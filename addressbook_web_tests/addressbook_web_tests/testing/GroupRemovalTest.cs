using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.ThereIsAGroup(1))
            {
                app.Groups.Create(new GroupData("zz4", "zz5", "qq6"));
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            //удаляем самый первый элемент из старого списка
            oldGroups.RemoveAt(0);
            //сравниваем списки после удаления элемента
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
