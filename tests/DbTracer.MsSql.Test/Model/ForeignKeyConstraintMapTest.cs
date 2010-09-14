using System;
using System.Collections.Generic;
using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;
using System.Linq;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class ForeignKeyConstraintMapTest : KeyConstraintMapTest<ForeignKeyConstraint>
    {
        private ForeignKeyConstraint testedObject;
        private Table expectedSourceTable;
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
                expectedSourceTable = session.CreateCriteria<Table>()
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
        public void CheckPropertySpecialForForeignKey(string propertyName)
        {
            var expectedValue = GetValue(propertyName, ExpectedObject);
            TestUtils.TestProperty(propertyName, expectedValue, TestedObject);
        }

        [Test]
        public void CheckReferencedObject()
        {
            Assert.IsNotNull(TestedObject.ReferencedObject);
            Assert.AreEqual(expectedReferencedTable, TestedObject.ReferencedObject);
            Assert.AreSame(expectedReferencedTable, TestedObject.ReferencedObject);
        }

        [Test]
        public void CheckColumns()
        {
            var testedColumnReferences = testedObject.Columns.ToList();
            var expectedParentColumns = GetColumnsByName(expectedSourceTable, "test", "id2");
            var expectedReferencedColumns = GetColumnsByName(expectedReferencedTable, "test", "id2");

            Assert.AreEqual(2, testedColumnReferences.Count, "Count of columns is not valid.");
            for (var i = 0; i < testedColumnReferences.Count; ++i )
            {
                var testedColumnReference = testedColumnReferences[i];
                var expectedParentColumn = expectedParentColumns[i];
                var expectedReferencedColumn = expectedReferencedColumns[i];
                Assert.AreSame(expectedParentColumn, testedColumnReference.Source);
                Assert.AreSame(expectedReferencedColumn, testedColumnReference.Reference);
            }
        }

        private static List<Column> GetColumnsByName(Table table, params string[] names)
        {
            var columns = new List<Column>();
            foreach (var name in names)
            {
                var nameLocal = name;
                var column = (table.Columns.Where(col => col.Name == nameLocal)).Single();
                columns.Add(column);
            }
            return columns;
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
                    ParentObject = expectedSourceTable,
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