using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("Robert", "Braun");
            ContactData newData = new ContactData("Dave", "Adams");
            app.Contacts.Modify(newData, contact);
        }

    }
}

