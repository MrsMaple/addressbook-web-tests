using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("AAA");
            newData.Header = "QQQ";
            newData.Footer = "WWW";

            GroupData group = new GroupData("aaa");
            group.Header = "qqq";
            group.Footer = "www";

            app.Groups.Modify(1, newData, group);
        }

    }
}
