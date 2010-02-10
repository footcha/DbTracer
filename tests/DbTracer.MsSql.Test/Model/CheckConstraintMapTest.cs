using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class CheckConstraintMapTest : SqlObjectTest<CheckConstraint>, ICodeTest
    {
        private CheckConstraint constraint;
        private Column expectedParentColumn;
        private Table expectedTable;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                constraint = session.CreateCriteria<CheckConstraint>()
                    .Add(Restrictions.Eq("Name", "CK_test_table"))
                    .UniqueResult<CheckConstraint>();
                expectedParentColumn = session.CreateCriteria<Column>()
                    .Add(Restrictions.Eq("Name", "id"))
                    .CreateCriteria("Table").Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Column>();
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
            }
        }

        [RowTest,
        Row("IsDisabled", true),
        Row("IsNotForReplication", true),
        Row("IsNotTrusted", true),
        Row("UsesDatabaseCollation", true),
        Row("IsSystemNamed", false),
        ]
        public void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, constraint);
        }

        [Test]
        public void DefinitionTest()
        {
            TestUtils.TestSqlObjectDefinition(ExpectedObject.Definition, constraint.Definition);
        }

        [Test]
        public void ParentColumnTest()
        {
            Assert.IsNotNull(constraint.ParentColumn, "ParentColumn cannot be null");
            Assert.AreSame(expectedParentColumn, constraint.ParentColumn);
        }

        [Test]
        public void TableTest()
        {
            Assert.AreSame(expectedTable, constraint.Table);
        }

        protected override CheckConstraint ExpectedObject
        {
            get
            {
                var schema = new Schema { Id = 1 };
                return new CheckConstraint
                {
                    Name = "CK_test_table",
                    IsNotForReplication = true,
                    Schema = schema,
                    Type = SqlObjectType.CheckConstraint,
                    Definition = "([id]>(0))"
                };
            }
        }

        protected override CheckConstraint TestedObject
        {
            get { return constraint; }
        }
    }
}