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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData, group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
