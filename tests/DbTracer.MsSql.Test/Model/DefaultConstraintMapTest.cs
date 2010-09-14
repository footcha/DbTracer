using System;
using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class DefaultConstraintMapTest : SqlObjectTest<DefaultConstraint>, ICodeTest
    {
        private DefaultConstraint testedObject;
        private Table expectedTable;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                testedObject = session.CreateCriteria<DefaultConstraint>()
                    .Add(Restrictions.Eq("Name", "DF_test_table_test"))
                    .UniqueResult<DefaultConstraint>();
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
            }
        }

        [RowTest,
        Row("IsSystemNamed", false),
        ]
        public void CheckProperty(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, testedObject);
        }

        [Test]
        public void CheckDefinition()
        {
            TestUtils.TestSqlObjectDefinition(ExpectedObject.Definition, testedObject.Definition);
        }

        protected override DefaultConstraint ExpectedObject
        {
            get
            {
                var schema = new Schema { Id = 1 };
                return new DefaultConstraint
                {
                    CreateDate = DateTime.Now,
                    Definition = "(getdate())",
                    ModifyDate = DateTime.Now,
                    Name = "DF_test_table_test",
                    ParentObject = expectedTable,
                    Schema = schema,
                    Type = SqlObjectType.DefaultConstraint
                };
            }
        }

        protected override DefaultConstraint TestedObject
        {
            get { return testedObject; }
        }
    }
}