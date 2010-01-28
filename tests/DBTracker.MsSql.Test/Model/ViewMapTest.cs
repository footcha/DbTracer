using System.Linq;
using DbTracker.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracker.MsSql.Test.Model
{
    [TestFixture]
    public class ViewMapTest : ASqlObjectTestBase, ICodeTest
    {
        private View view;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                view = session.CreateCriteria<View>()
                    .Add(Restrictions.Eq("Name", "test_view"))
                    .UniqueResult<View>();
            }
        }

        [RowTest,
        Row("Name", "test_view"),
        ]
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, view);
        }

        //[Test]
        //public override void TypeTest()
        //{
        //    Assert.AreEqual(SqlObjectType.View, view.Type);
        //}

        [Test]
        public void DefinitionTest()
        {
            const string expectedDefinition = "CREATE VIEW [dbo].[test_view]  AS  SELECT * FROM dbo.test_table";
            TestUtils.TestSqlObjectDefinition(expectedDefinition, view.Definition);
        }

        [Test]
        public void TriggersTest()
        {
            Assert.AreEqual(1, view.Triggers.Count);
            var testedTrigger = (from t in view.Triggers select t.Value).First();
            using (var session = SessionFactory.OpenSession())
            {
                var testingTrigger = session.CreateCriteria<Trigger>()
                    .Add(Restrictions.Eq("Name", "test_view_trigger"))
                    .UniqueResult<Trigger>();
                Assert.AreEqual(testingTrigger, testedTrigger);
            }
        }
    }
}