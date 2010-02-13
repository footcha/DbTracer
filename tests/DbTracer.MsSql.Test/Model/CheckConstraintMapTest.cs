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
                // possible bug: if expected table is loaded AFTER constraint to session cache
                constraint = session.CreateCriteria<CheckConstraint>()
                    .Add(Restrictions.Eq("Name", "CK_test_table"))
                    .UniqueResult<CheckConstraint>();
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
                expectedParentColumn = session.CreateCriteria<Column>()
                    .Add(Restrictions.Eq("Name", "id"))
                    .CreateCriteria("ParentObject").Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Column>();
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
            Assert.AreEqual(expectedParentColumn, constraint.ParentColumn);
            Assert.AreSame(expectedParentColumn, constraint.ParentColumn);
        }

        [Test]
        public void ParentObjectTest()
        {
            Assert.IsNotNull(constraint.ParentObject, "Object cannot be null.");
            Assert.AreEqual(expectedTable, constraint.ParentObject);
            // Assert.AreSame(expectedTable, constraint.ParentObject); // not works
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
                    Definition = "([id]>(0))",
                    ParentObject = expectedTable
                };
            }
        }

        protected override CheckConstraint TestedObject
        {
            get { return constraint; }
        }
    }
}