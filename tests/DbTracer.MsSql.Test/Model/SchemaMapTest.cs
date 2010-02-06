using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class SchemaMapTest : ASqlObjectTestBase
    {
        private Schema schema;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                schema = session.Get<Schema>(1);
            }
        }

        [RowTest,
        Row("Name", "dbo"),
        Row("Id", 1),
        Row("PrincipalId", 1),
        ]
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, schema);
        }
    }
}