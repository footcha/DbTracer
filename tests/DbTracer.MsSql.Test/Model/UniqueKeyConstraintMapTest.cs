using System;
using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class UniqueKeyConstraintMapTest : KeyConstraintMapTest<UniqueKeyConstraint>
    {
        private UniqueKeyConstraint testedObject;
        private Table expectedTable;
        private Index expectedIndex;

        [FixtureSetUp]
        public void FixtureSetUp()
        {
            using (var session = SessionFactory.OpenSession())
            {
                testedObject = session.CreateCriteria<UniqueKeyConstraint>()
                    .Add(Restrictions.Eq("Name", "UK_test_table"))
                    .UniqueResult<UniqueKeyConstraint>();
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
                expectedIndex = session.CreateCriteria<Index>()
                    .Add(Restrictions.Eq("Name", "UK_test_table"))
                    .UniqueResult<Index>();
            }
        }

        protected override Index ExpectedIndex
        {
            get { return expectedIndex; }
        }

        protected override UniqueKeyConstraint ExpectedObject
        {
            get
            {
                var schema = new Schema { Id = 1 };
                return new UniqueKeyConstraint
                {
                    CreateDate = DateTime.Now,
                    IsSystemNamed = false,
                    Name = "UK_test_table",
                    ModifyDate = DateTime.Now,
                    ParentObject = expectedTable,
                    Schema = schema,
                    Type = SqlObjectType.UniqueConstraint
                };
            }
        }

        protected override UniqueKeyConstraint TestedObject
        {
            get { return testedObject; }
        }
    }
}