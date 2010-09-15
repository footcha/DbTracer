using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class SchemaMapTest : ASqlObjectTestBase
    {
        private Schema schema;

        [FixtureSetUp]
        public void FixtureSetUp()
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                schema = session.Get<Schema>(1);
            }
        }

        [Test,
        Row("Name", "dbo"),
        Row("Id", 1),
        Row("PrincipalId", 1),
        ]
        public override void CheckProperty(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, schema);
        }

        public static Schema CreateDboSchema()
        {
            return new Schema
            {
                Id = 1,
                Name = "dbo",
                PrincipalId = 1,
            };
        }

        public static Schema CreateSysSchema()
        {
            return new Schema
            {
                Id = 4,
                Name = "dbo",
                PrincipalId = 4,
            };
        }
    }
}