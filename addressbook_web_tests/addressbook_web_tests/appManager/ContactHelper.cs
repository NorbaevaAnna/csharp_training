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
    public class ContactHelper : HelperBase
    {
        public string baseURL;
        public bool acceptNextAlert = true;

        public ContactHelper(IWebDriver driver, string baseURL, bool acceptNextAlert) : base(driver)
        {
            this.baseURL = baseURL;
            this.acceptNextAlert = acceptNextAlert;
        }
        public void ProofRemoveContact()
        {
            //Подтверждение удаления контакта
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
        }
        public void RemoveContact()
        {
            //удаление контакта
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }
        public void SelectContact()
        {
            //выбор контакта для удаления
            acceptNextAlert = true;
            driver.FindElement(By.Id(idToFind: "9")).Click();
        }
        public void ReturnToHomePage()
        {
            //возврат на домашнюю страницу 
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void InitNewContactCreation()
        {
            //Инициация создания нового контакта
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void FillContactForm(ContactData contact)
        {
            //Заполнение формы контакта
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);
        }
        public void SubmitContactCreation()
        {
            //Подтверждение создания контакта
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
