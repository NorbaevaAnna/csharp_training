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
    public class GroupHelper : HelperBase
    {

        public string baseURL;

        public GroupHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
        }

        public void ReturnToGroupsPage()
        {
            //Возвращение на страницу со списком групп
            driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        public void InitNewGroupCreation()
        {
            //Инициация создания новой группы
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("new")).Click();
        }
        public void FillGroupForm(GroupData group)
        {
            //Заполняются поля формы создания групп
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        public void SubmitGroupCreation()
        {
            //Подтверждение создания группы
            driver.FindElement(By.Name("submit")).Click();
        }
        public void RemoveGroup()
        {
            //Удаление группы
            driver.FindElement(By.Name("delete")).Click();
        }
        public void SelectGroup(int index)
        {
            //Выбор группы для удаления
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
        }
    }
}
