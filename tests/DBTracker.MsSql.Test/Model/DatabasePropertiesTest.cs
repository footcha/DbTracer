using DbTracker.Core.Reflection;
using DbTracker.Core.Schema.Model;
using DbTracker.MsSql.Model;
using MbUnit.Framework;

namespace DbTracker.MsSql.Test.Model
{
    [TestFixture]
    public class DatabasePropertiesTest : ATestBase
    {
        [Test]
        public void PropertiesCountTest()
        {
            var ps = Search.GetPropertiesWithAttribute<DatabasePropertyAttribute>(typeof(DatabaseProperties));
            Assert.AreEqual(32, ps.Count);
        }
    }
}