using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class IndexMapTest : ASqlObjectTestBase
    {
        private Index index;
        private Table expectedTable;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                index = session.CreateCriteria<Index>()
                    .Add(Restrictions.Eq("Name", "PK_test_table"))
                    .UniqueResult<Index>();
                expectedTable = session.CreateCriteria<Table>()
                    .Add(Restrictions.Eq("Name", "test_table"))
                    .UniqueResult<Table>();
            }
        }

        [RowTest,
        Row("IndexId", 1),
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
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, index);
        }

        [Test]
        public void IndexTypeTest()
        {
            Assert.AreEqual(IndexType.Clustered, index.IndexType);
        }

        [Test]
        public void TableTest()
        {
            Assert.AreEqual(expectedTable, index.Table);
        }
    }
}