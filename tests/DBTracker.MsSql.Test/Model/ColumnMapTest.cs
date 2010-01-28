using DbTracker.MsSql.Model;
using MbUnit.Framework;
using NHibernate;
using NHibernate.Criterion;

namespace DbTracker.MsSql.Test.Model
{
    [TestFixture]
    public class ColumnMapTest : ASqlObjectTestBase
    {
        private Column column;

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
                    .Add(Restrictions.Eq("Id", table.Id))
                    .UniqueResult<Column>();
            }
        }

        [RowTest,
        Row("Name", "test"),
        Row("ColumnId", 2),
            //Row("SystemType", ),
            //Row("UserType", ),
            //Row("Schema", ),
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
            using (var session = SessionFactory.OpenSession())
            {
                var testingObject = session.CreateCriteria<Type>()
                    .Add(Restrictions.Eq("Id", 167))
                    .UniqueResult<Type>();
                Assert.AreEqual(testingObject, column.SystemType);
            }
        }

        [Test]
        public void UserTypeTest()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var testingObject = session.CreateCriteria<Type>()
                    .Add(Restrictions.Eq("Id", 167))
                    .UniqueResult<Type>();
                Assert.AreEqual(testingObject, column.UserType);
            }
        }
    }
}