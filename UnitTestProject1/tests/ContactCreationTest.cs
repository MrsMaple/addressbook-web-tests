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
        public void ContactCreationTests()
        {
            ContactData contact = new ContactData("Robert", "Braun");
            app.Contacts.Create(contact);
        }


    }
}
