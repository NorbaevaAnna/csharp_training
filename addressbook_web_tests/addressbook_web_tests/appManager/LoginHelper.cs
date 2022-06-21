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
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {
        }
        public void Login(AccountData account)
        {   
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();

            }
            Type(By.Name(nameToFind: "user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                           && GetLoggetUserName() == account.Username;
        }
        public string GetLoggetUserName()
        {
            string text = driver.FindElement(By.XPath("//form[@name=\"logout\"]/b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Logout"));
        }

        public LoginHelper Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                return this;
            }
            return this;
        }
    }
}
