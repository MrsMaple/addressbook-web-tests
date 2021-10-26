using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "qqq";
            group.Footer = "www";

            app.Groups.Remove(1, group);
        }
    }
}
