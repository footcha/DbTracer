using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;
using System.Linq;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class IndexMapTest : ASqlObjectTestBase
    {
        private Index testedObject;
        private Table expectedTable;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                testedObject = session.CreateCriteria<Index>()
                    .Add(Restrictions.Eq("Name", "PK_test_table"))
                    .UniqueResult<Index>();
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
            }
        }

        [RowTest,
        Row("Id", 1),
        Row("Name", "PK_test_table"),
        Row("IsUnique", true),
        Row("IgnoreDuplicityKey", false),
        Row("IsPrimaryKey", true),
        Row("IsUniqueConstraint", false),
        Row("FillFactor", 0),
        Row("IsPadded", false),
        Row("IsDisabled", false),
        Row("IsHypothetical", false),
        Row("AllowRowLocks", true),
        Row("AllowPageLocks", true),
        ]
        public override void CheckProperty(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, testedObject);
        }

        [Test]
        public void CheckIndexType()
        {
            Assert.AreEqual(IndexType.Clustered, testedObject.IndexType);
        }

        [Test]
        public void CheckParentObject()
        {
            Assert.IsNotNull(testedObject.ParentObject);
            Assert.AreEqual(expectedTable, testedObject.ParentObject);
            // Assert.AreSame(expectedTable, testedObject.ParentObject); // not working
        }

        [RowTest,
        Row("id", 0, 0, false, false),
        Row("test2", 1, 0, true, false),
        Row("test", 2, 0, false, false),
        ]
        public void CheckColumns(string columnName, int columnIndex,
            int partitionOrdinal, bool isDescendingKey, bool isIncludedColumn)
        {
            Assert.AreEqual(3, testedObject.IndexColumns.Count);
            var column = testedObject.IndexColumns.ToList()[columnIndex];
            var keyOrdinal = columnIndex + 1;
            Assert.AreEqual(columnName, column.Column.Name);
            Assert.AreEqual(keyOrdinal, column.KeyOrdinal);
            Assert.AreEqual(partitionOrdinal, column.PartitionOrdinal);
            Assert.AreEqual(isDescendingKey, column.IsDescendingKey);
            Assert.AreEqual(isIncludedColumn, column.IsIncludedColumn);
        }
    }
}