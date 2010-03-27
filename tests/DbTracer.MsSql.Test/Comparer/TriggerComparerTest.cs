using DbTracer.MsSql.Comparer;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Comparer
{
    [TestFixture]
    public class TriggerComparerTest : ComparerTestBase<Trigger, TriggerComparer>
    {
        [SetUp]
        public void Setup()
        {
            TestedObject1 = new Trigger
            {
                Definition = "CREATE TRIGGER trigger1", 
                Name = "trigger1", 
                ParentObject = new Table()
            };
            TestedObject2 = new Trigger
            {
                Definition = "CREATE TRIGGER trigger2", 
                Name = "trigger2", 
                ParentObject = new Table()
            };
        }

        [Test]
        public void TestNameTest()
        {
            var x = new TriggerComparer(TestedObject1, TestedObject2);

            var result = x.Compare();
            Assert.AreEqual("ALTER TRIGGER trigger1", result.ToSqlSourceToDestination());
        }

        [Test]
        public void TestName2Test()
        {
            TestedObject2 = null;

            var x = new TriggerComparer(TestedObject1, TestedObject2);
            var result = x.Compare();
            Assert.AreEqual("CREATE TRIGGER trigger1", result.ToSqlSourceToDestination());
        }

        [Test]
        public void TestName3Test()
        {
            TestedObject1 = null;

            var x = new TriggerComparer(TestedObject1, TestedObject2);
            var result = x.Compare();
            Assert.AreEqual("DROP TRIGGER trigger2", result.ToSqlSourceToDestination());
        }
    }
}