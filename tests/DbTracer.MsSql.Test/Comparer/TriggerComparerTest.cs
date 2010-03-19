using DbTracer.MsSql.Comparer;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Comparer
{
    [TestFixture]
    public class TriggerComparerTest : ComparerTestBase<Trigger, TriggerComparer>
    {
        [Test]
        public void TestNameTest()
        {
            var x = new TriggerComparer(new Trigger {Definition = "CREATE TRIGGER xxxx"});
            var result = x.Compare(new Trigger());
            Assert.AreEqual("ALTER TRIGGER xxxx", result.ToSqlSourceToDestination());
        }

        [Test]
        public void TestName2Test()
        {
            var x = new TriggerComparer(new Trigger {Definition = "CREATE TRIGGER xxxx"});
            var result = x.Compare(null);
            Assert.AreEqual("CREATE TRIGGER xxxx", result.ToSqlSourceToDestination());
        }
    }
}