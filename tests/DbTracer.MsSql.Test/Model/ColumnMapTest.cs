using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class ColumnMapTest : ASqlObjectTestBase
    {
        private Column column;
        private Type expectedType;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var table = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
                column = session.CreateCriteria<Column>()
                    .Add(Restrictions.Eq("Name", "test"))
                    .Add(Restrictions.Eq("Table", table.Id))
                    .UniqueResult<Column>();
                expectedType = TypeMapTest.GetTypeByName("varchar");
            }
        }

        [RowTest,
        Row("Name", "test"),
        Row("Id", 2),
        Row("MaxLength", 50),
        Row("Precision", 0),
        Row("Scale", 0),
        Row("Collation", "Czech_CI_AS"),
        Row("IsNullable", true),
        Row("IsAnsiPadded", true),
        Row("IsRowGuidCol", false),
        Row("IsIdentity", false),
        Row("IsComputed", false),
        Row("IsFileStream", false),
        Row("IsReplicated", false),
        Row("IsNonSqlSubscribed", false),
        Row("IsMergePublished", false),
        Row("IsDtsReplicated", false),
        Row("IsXmlDocument", false),
        Row("XmlCollectionId", 0),
        Row("DefaultObjectId", 0),
        Row("RuleObjectId", 0),
        ]
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, column);
        }

        [Test]
        public void SystemTypeTest()
        {
            Assert.AreEqual(expectedType, column.SystemType);
        }

        [Test]
        public void UserTypeTest()
        {
            Assert.AreEqual(expectedType, column.UserType);
        }
    }
}