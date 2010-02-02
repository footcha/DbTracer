using DbTracer.Core.Reflection;
using DbTracer.Core.Schema.Model;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Model
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