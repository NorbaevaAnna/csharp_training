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

        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
        }


        public void OpenHomePage()
        {
            // открытие домашней страницы
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupsPage()
        {
            //Переход на страницу групп
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void ExitFromAddressbook()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void ClickHomeButton()
        {
            //возврат на домашнюю страницу 
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
