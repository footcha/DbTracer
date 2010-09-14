using System.Linq;
using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class ViewMapTest : SqlObjectTest<View>, ICodeTest
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
        Row("IsReplicated"),
        Row("HasReplicationFilter"),
        Row("HasOpaqueMetadata"),
        Row("HasUncheckedAssemblyData"),
        Row("WithCheckOption"),
        Row("IsDateCorrelationView")]
        public void CheckPropertySpecialForView(string propertyName)
        {
            TestUtils.TestProperty(propertyName, ExpectedObject, TestedObject);
        }

        [Test]
        public void CheckDefinition()
        {
            TestUtils.TestSqlObjectDefinition(ExpectedObject.Definition, view.Definition);
        }

        [Test]
        public void CheckTriggers()
        {
            Assert.AreEqual(1, view.Triggers.Count);
            var testedTrigger = (from t in view.Triggers select t).First();
            using (var session = SessionFactory.OpenSession())
            {
                var testingTrigger = session.CreateCriteria<Trigger>()
                    .Add(Restrictions.Eq("Name", "test_view_trigger"))
                    .UniqueResult<Trigger>();
                Assert.AreEqual(testingTrigger, testedTrigger);
            }
        }

        protected override View ExpectedObject
        {
            get
            {
                return new View
                {
                    Definition = "CREATE VIEW [dbo].[test_view]  AS  SELECT * FROM dbo.test_table",
                    IsMsShipped = false,
                    IsPublished = false,
                    IsSchemaPublished = false,
                    Schema = new Schema { Id = 1 },
                    ParentObject = null,
                    Name = "test_view",
                    Type = SqlObjectType.View,
                    IsReplicated = false,
                    HasReplicationFilter = false,
                    HasOpaqueMetadata = false,
                    HasUncheckedAssemblyData = false,
                    WithCheckOption = false,
                    IsDateCorrelationView = false
                };
            }
        }

        protected override View TestedObject
        {
            get { return view; }
        }
    }
}