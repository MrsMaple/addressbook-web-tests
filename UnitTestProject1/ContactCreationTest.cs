using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
        [Test]
        public void GroupCreationTests()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToNewContactsPage();
            ContactData contact = new ContactData("Robert", "Braun");
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
        }


    }
}
