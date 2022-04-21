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
    public class ApplicationManager
        {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper gHelper;
        protected ContactHelper contHelper;

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            gHelper = new GroupHelper(this);
            contHelper = new ContactHelper(this);
        }
        public IWebDriver Driver
        {
            get { return driver; }
        }
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public LoginHelper auth
        {
            get
            { return loginHelper; }
        }
        public NavigationHelper navi
        {
            get
            { return navigator; }
        }
        public GroupHelper groups
        {
            get { return gHelper; }
        }
        public ContactHelper contacts
        {
            get { return contHelper; }
        }
    }
}
