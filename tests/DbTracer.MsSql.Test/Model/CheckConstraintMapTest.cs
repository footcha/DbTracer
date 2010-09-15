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

        [FixtureSetUp]
        public void FixtureSetUp()
        {
            using (var session = SessionFactory.OpenSession())
            {
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
                constraint = session.CreateCriteria<CheckConstraint>()
                    .Add(Restrictions.Eq("Name", "CK_test_table"))
                    .UniqueResult<CheckConstraint>();
                expectedParentColumn = session.CreateCriteria<Column>()
                    .Add(Restrictions.Eq("Name", "id"))
                    .CreateCriteria("ParentObject").Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Column>();
            }
        }

        [Test,
        Row("IsDisabled", true),
        Row("IsNotForReplication", true),
        Row("IsNotTrusted", true),
        Row("UsesDatabaseCollation", true),
        Row("IsSystemNamed", false),
        ]
        public void CheckProperty(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, constraint);
        }

        [Test]
        public void CheckDefinition()
        {
            TestUtils.TestSqlObjectDefinition(ExpectedObject.Definition, constraint.Definition);
        }

        [Test]
        public void CheckParentColumn()
        {
            Assert.IsNotNull(constraint.ParentColumn, "ParentColumn cannot be null");
            Assert.AreEqual(expectedParentColumn, constraint.ParentColumn);
            Assert.AreSame(expectedParentColumn, constraint.ParentColumn);
        }

        [Test]
        public void CheckParentObject()
        {
            Assert.IsNotNull(constraint.ParentObject, "Object cannot be null.");
            Assert.AreEqual(expectedTable, constraint.ParentObject);
            Assert.AreSame(expectedTable, constraint.ParentObject);
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