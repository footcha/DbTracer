using DbTracker.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracker.MsSql.Test.Model
{
    [TestFixture]
    public class TypeMapTest : ASqlObjectTestBase
    {
        private Type type;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                type = session.CreateCriteria<Type>()
                    .Add(Restrictions.Eq("Name", "sysname"))
                    .UniqueResult<Type>();
            }
        }

        [RowTest,
        Row("Name", "sysname"),
        //Row("Schema", 4), // TODO test
        Row("Id", 256),
        Row("SystemTypeId", 231),
        Row("MaxLength", 256),
        Row("Precision", 0),
        Row("Scale", 0),
        Row("Collation", "Czech_CI_AS"),
        Row("IsNullable", false),
        Row("IsUserDefined", false),
        Row("IsAssemblyType", false),
        Row("DefaultObjectId", 0),
        Row("RuleObjectId", 0),
        ]
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, type);
        }
    }
}