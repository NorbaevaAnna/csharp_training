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

    public class NavigationHelper : HelperBase

    {
        public string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }


        public void OpenHomePage()
        {
            // открытие домашней страницы
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupsPage()
        {
            //Переход на страницу групп
            if (driver.Url == baseURL + "group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void ExitFromAddressbook()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        public void ReturnToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php"
                           && IsElementPresent(By.Name("new")))
            {
                return;
            };
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void ClickHomeButton()
        {
            //возврат на домашнюю страницу 
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
