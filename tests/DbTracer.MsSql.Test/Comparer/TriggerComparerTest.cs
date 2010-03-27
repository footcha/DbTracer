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
            TestedObject1 = new Trigger
            {
                Definition = "CREATE TRIGGER trigger1", 
                Name = "trigger1", 
                ParentObject = new Table(),
                Schema = schema
            };
            TestedObject2 = new Trigger
            {
                Definition = "CREATE TRIGGER trigger2", 
                Name = "trigger2", 
                ParentObject = new Table(),
                Schema = schema
            };
        }

        private TriggerComparer CreateComparer()
        {
            return new TriggerComparer(TestedObject1, TestedObject2)
            {
                SourceToDestinationGenerator = new TriggerGenerator(TestedObject1),
                DestinationToSourceGenerator = new TriggerGenerator(TestedObject2)
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
            TestedObject2 = null;

            var x = CreateComparer();
            var result = x.Compare();
            Assert.AreEqual("CREATE TRIGGER trigger1", result.ToSqlSourceToDestination());
        }

        [Test]
        public void TestName3Test()
        {
            TestedObject1 = null;

            var x = CreateComparer();
            //x.DestinationToSourceGenerator.FullNameBuilder = new FullNameWithSchemaBuilder(x.SourceToDestinationGenerator.KeywordEncoder);
            var result = x.Compare();
            //Assert.AreEqual("DROP TRIGGER testSchema.trigger2", result.ToSqlSourceToDestination());
            Assert.AreEqual("DROP TRIGGER trigger2", result.ToSqlSourceToDestination());
        }
    }
}