using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests

{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public ContactHelper CreateContact(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }


        public ContactHelper RemoveContact(int v)
        {
            SelectContact(v);
            CLickDeleteButton();
            CloseAlertMessage();
            manager.Navi.ClickHomeButton();
            return this;
        }


        public ContactHelper ModifyContact(int v, ContactData newDataContact)
        {

            SelectModifyContact(v);
            FillContactForm(newDataContact);
            UpdateContact();
            manager.Navi.ClickHomeButton();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper CLickDeleteButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[@name='entry'][" + (index + 1) + "]/ td/input")).Click();
            return this;
        }
        public ContactHelper CloseAlertMessage()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper SelectModifyContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Edit'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("//input[@value='Update'][2]")).Click();
            return this;
        }

        public bool ThereIsAContacts(int v)
        {
            return IsElementPresent(By.XPath("//tr[@name='entry'][" + v + "]//img[@title='Edit']"));
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contactlist = new List<ContactData>();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
            foreach (IWebElement element in elements)
            {
                contactlist.Add(new ContactData(element.FindElement(By.XPath("./td[3]")).Text)
                {
                    Lastname = element.FindElement(By.XPath("./ td[2]")).Text
                });
            }
            return new List<ContactData>();
        }
    }
}
