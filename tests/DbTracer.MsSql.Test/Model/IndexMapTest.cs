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
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, testedObject);
        }

        [Test]
        public void IndexTypeTest()
        {
            Assert.AreEqual(IndexType.Clustered, testedObject.IndexType);
        }

        [Test]
        public void ParentObjectTest()
        {
            Assert.IsNotNull(testedObject.ParentObject);
            Assert.AreEqual(expectedTable, testedObject.ParentObject);
            // Assert.AreSame(expectedTable, testedObject.ParentObject); // not working
        }

        [Test]
        public void ColumnsTest()
        {
            var columns = testedObject.Columns.ToList();
            Assert.AreEqual(3, columns.Count);
            Assert.AreEqual("id", columns[0].Name);
            Assert.AreEqual("test2", columns[1].Name);
            Assert.AreEqual("test", columns[2].Name);
        }
    }
}