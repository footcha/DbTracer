using System;
using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class PrimaryKeyConstraintMapTest : KeyConstraintMapTest<PrimaryKeyConstraint>
    {
        private PrimaryKeyConstraint testedObject;
        private Table expectedTable;
        private Index expectedIndex;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                testedObject = session.CreateCriteria<PrimaryKeyConstraint>()
                    .Add(Restrictions.Eq("Name", "PK_test_table"))
                    .UniqueResult<PrimaryKeyConstraint>();
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
                expectedIndex = session.CreateCriteria<Index>()
                    .Add(Restrictions.Eq("Name", "PK_test_table"))
                    .UniqueResult<Index>();
            }
        }

        protected override Index ExpectedIndex
        {
            get { return expectedIndex; }
        }

        protected override PrimaryKeyConstraint ExpectedObject
        {
            get
            {
                var schema = new Schema { Id = 1 };
                return new PrimaryKeyConstraint
                {
                    CreateDate = DateTime.Now,
                    IsSystemNamed = false,
                    Name = "PK_test_table",
                    ModifyDate = DateTime.Now,
                    ParentObject = expectedTable,
                    Schema = schema,
                    Type = SqlObjectType.PrimaryKeyConstraint
                };
            }
        }

        protected override PrimaryKeyConstraint TestedObject
        {
            get { return testedObject; }
        }
    }
}