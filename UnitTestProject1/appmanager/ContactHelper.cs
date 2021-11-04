using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToNewContactsPage();

            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.OpenHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
            foreach (IWebElement element in elements)
            {
                IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                string firstname = cells[2].Text;
                string lastname = cells[1].Text;
                contacts.Add(new ContactData(cells[2].Text, cells[1].Text));
            }
            return contacts;
        }

        public ContactHelper Modify(ContactData newData, ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            ValidateContact(contact);
            EditContact();
            FillContactForm(newData);
            UpdateContactCreation();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            ValidateContact(contact);
            SelectContact();
            RemoveContact();
            driver.SwitchTo().Alert().Accept();
            driver.FindElement(By.CssSelector("div.msgbox"));
            return this;
        }



        public ContactHelper ValidateContact(ContactData contact)
        {
            if (IsContact())
            {
                return this;
            }
            else
            {
                manager.Contacts.Create(contact);
                return this;
            }
        }
        public bool IsContact()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }
        public ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public ContactHelper UpdateContactCreation()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
    }
}
