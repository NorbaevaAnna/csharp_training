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


        public void GoHomePage()
        {
            // открытие домашней страницы
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupsPage()
        {
            //Переход на страницу групп
            driver.FindElement(By.LinkText("groups")).Click();

        }
        public void ReturnToHomePage()
        {
            //возврат на домашнюю страницу 
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
