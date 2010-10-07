using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class ColumnMapTest : ASqlObjectTestBase
    {
        private Column column;
        private Type expectedType;
        private Table expectedTable;
        private ISession session;

        [FixtureSetUp]
        public void FixtureSetUp()
        {
            session = SessionFactory.OpenSession();
            expectedTable = session.QueryOver<Table>()
                .And(e => e.Name == "test_table")
                .SingleOrDefault();
            column = session.QueryOver<Column>()
                .And(e => e.Name == "test")
                .And(e => e.ParentObject == expectedTable)
                .SingleOrDefault();
            expectedType = TypeMapTestBase.GetTypeByName("varchar", session);
        }

        [TearDown]
        public void FixtureTearDown()
        {
            session.Dispose();
        }

        [Test,
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
        public override void CheckProperty(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, column);
        }

        [Test]
        public void CheckParentObject()
        {
            Assert.IsNotNull(expectedTable);
            Assert.AreSame(expectedTable, column.ParentObject);
        }

        [Test]
        public void CheckSystemType()
        {
            Assert.IsNotNull(expectedType);
            Assert.AreSame(expectedType, column.SystemType);
        }

        [Test]
        public void CheckUserType()
        {
            Assert.IsNotNull(expectedType);
            Assert.AreSame(expectedType, column.UserType);
        }

        [Test]
        public void CheckDefaultConstraint()
        {
            Assert.IsNotNull(column.Default);
            Assert.AreEqual(column, column.Default.Column);
            Assert.AreEqual("(getdate())", column.Default.Definition);
            Assert.AreSame(column, column.Default.Column); // TODO test is not working
        }

        [Test,
        Ignore("Create test type containing rule object setting")
        ]
        public void CheckRule()
        {
            Assert.IsNotNull(column.Rule);
        }
    }
}