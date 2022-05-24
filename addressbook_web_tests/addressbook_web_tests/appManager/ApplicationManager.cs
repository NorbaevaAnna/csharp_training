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
using System.Collections.Generic;
using System.Linq;

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


        public static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public ApplicationManager()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            gHelper = new GroupHelper(this);
            contHelper = new ContactHelper(this);
        }

         ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navi.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }


        public IWebDriver Driver
        {
            get { return driver; }
        }

        public LoginHelper Auth
        {
            get
            { return loginHelper; }
        }
        public NavigationHelper Navi
        {
            get
            { return navigator; }
        }
        public GroupHelper Groups
        {
            get { return gHelper; }
        }
        public ContactHelper Contacts
        {
            get { return contHelper; }
        }
    }
}
