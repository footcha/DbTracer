using System;
using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class ForeignKeyConstraintMapTest : KeyConstraintMapTest<ForeignKeyConstraint>
    {
        private ForeignKeyConstraint testedObject;
        private Table expectedTable;
        private Index expectedIndex;
        private Table expectedReferencedTable;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                expectedReferencedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table_2"))
                    .UniqueResult<Table>();
                testedObject = session.CreateCriteria<ForeignKeyConstraint>()
                    .Add(Restrictions.Eq("Name", "FK_test_table_test_table_2"))
                    .UniqueResult<ForeignKeyConstraint>();
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
                expectedIndex = session.CreateCriteria<Index>()
                    .Add(Restrictions.Eq("Name", "IX_test_table_2"))
                    .UniqueResult<Index>();
            }
        }

        [RowTest,
         Row("IsDisabled"),
         Row("IsNotForReplication"),
         Row("IsNotTrusted"),
         Row("DeleteReferentialAction"),
         Row("UpdateReferentialAction")
        ]
        public void PropertyTest(string propertyName)
        {
            var expectedValue = GetValue(propertyName, ExpectedObject);
            TestUtils.TestProperty(propertyName, expectedValue, TestedObject);
        }

        [Test]
        public void ReferencedObjectTest()
        {
            Assert.IsNotNull(TestedObject.ReferencedObject);
            Assert.AreEqual(expectedReferencedTable, TestedObject.ReferencedObject);
            Assert.AreSame(expectedReferencedTable, TestedObject.ReferencedObject);
        }

        [Test]
        public void ColumnsTest()
        {
            Assert.Fail("Not implemented. (sys.foreign_key_columns)");
        }

        protected override Index ExpectedIndex
        {
            get { return expectedIndex; }
        }

        protected override ForeignKeyConstraint ExpectedObject
        {
            get
            {
                var schema = new Schema { Id = 1 };
                return new ForeignKeyConstraint
                {
                    CreateDate = DateTime.Now,
                    DeleteReferentialAction = 3,
                    IsSystemNamed = false,
                    IsDisabled = true,
                    IsNotTrusted = true,
                    Name = "FK_test_table_test_table_2",
                    ModifyDate = DateTime.Now,
                    ParentObject = expectedTable,
                    Schema = schema,
                    Type = SqlObjectType.ForeignKeyConstraint,
                    UpdateReferentialAction = 1
                };
            }
        }

        protected override ForeignKeyConstraint TestedObject
        {
            get { return testedObject; }
        }
    }
}