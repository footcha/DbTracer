using DbTracer.MsSql.Comparer;
using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Comparer
{
    [TestFixture]
    public class TriggerComparerTest : ComparerTestBase<Trigger, TriggerComparer>
    {
        [SetUp]
        public void Setup()
        {
            var schema = new Schema
            {
                Name = "testSchema"
            };
            SourceDatabaseObject = new Trigger
            {
                Definition = "CREATE TRIGGER trigger1", 
                Name = "trigger1", 
                ParentObject = new Table(),
                Schema = schema
            };
            DestinationDatabaseObject = new Trigger
            {
                Definition = "CREATE TRIGGER trigger2", 
                Name = "trigger2", 
                ParentObject = new Table(),
                Schema = schema
            };
        }

        private TriggerComparer CreateComparer()
        {
            return new TriggerComparer(SourceDatabaseObject, DestinationDatabaseObject)
            {
                SourceToDestinationGenerator = new TriggerGenerator(SourceDatabaseObject),
                DestinationToSourceGenerator = new TriggerGenerator(DestinationDatabaseObject)
            };
        }

        [Test]
        public void TestNameTest()
        {
            var x = CreateComparer();

            var result = x.Compare();
            Assert.AreEqual("ALTER TRIGGER trigger1", result.ToSqlSourceToDestination());
        }

        [Test]
        public void TestName2Test()
        {
            DestinationDatabaseObject = null;

            var x = CreateComparer();
            var result = x.Compare();
            Assert.AreEqual("CREATE TRIGGER trigger1", result.ToSqlSourceToDestination());
        }

        [Test]
        public void TestName3Test()
        {
            SourceDatabaseObject = null;

            var x = CreateComparer();
            //x.DestinationToSourceGenerator.FullNameBuilder = new FullNameWithSchemaBuilder(x.SourceToDestinationGenerator.KeywordEncoder);
            var result = x.Compare();
            //Assert.AreEqual("DROP TRIGGER testSchema.trigger2", result.ToSqlSourceToDestination());
            Assert.AreEqual("DROP TRIGGER trigger2", result.ToSqlSourceToDestination());
        }
    }
}