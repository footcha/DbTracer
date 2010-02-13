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
        private Table expectedTable;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
                column = session.CreateCriteria<Column>()
                    .Add(Restrictions.Eq("Name", "test"))
                    .Add(Restrictions.Eq("ParentObject", expectedTable))
                    .UniqueResult<Column>();
                expectedType = TypeMapTestBase.GetTypeByName("varchar", session);
            }
        }

        [RowTest,
        Row("Name", "test"),
        Row("Id", 2),
        Row("MaxLength", 50),
        Row("Precision", 0),
        Row("Scale", 0),
        Row("Collation", "Czech_CI_AS"),
        Row("IsNullable", false),
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
        ]
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, column);
        }

        [Test]
        public void ParentObjectTest()
        {
            Assert.AreSame(expectedTable, column.ParentObject);
        }

        [Test]
        public void SystemTypeTest()
        {
            Assert.AreSame(expectedType, column.SystemType);
        }

        [Test]
        public void UserTypeTest()
        {
            Assert.AreSame(expectedType, column.UserType);
        }

        [Test,
        Ignore("Create test type containing default object setting")
        ]
        public void DefaultTest()
        {
            Assert.IsNotNull(column.Default);
        }

        [Test,
        Ignore("Create test type containing rule object setting")
        ]
        public void RuleTest()
        {
            Assert.IsNotNull(column.Rule);
        }
    }
}