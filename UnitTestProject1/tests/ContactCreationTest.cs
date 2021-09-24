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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToNewContactsPage();
            ContactData contact = new ContactData("Robert", "Braun");
            app.Groups.FillContactForm(contact);
            app.Groups.SubmitContactCreation();
            app.Groups.ReturnToHomePage();
        }


    }
}
