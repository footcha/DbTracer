using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class FunctionMapTest : ASqlObjectTestBase, ICodeTest
    {
        private Function function;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                function = session.CreateCriteria<Function>()
                    .Add(Restrictions.Eq("Name", "test_fcn"))
                    .UniqueResult<Function>();
            }
        }

        [RowTest,
        Row("Name", "test_fcn"),
        ]
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, function);
        }

        [Test]
        public void DefinitionTest()
        {
            const string expectedDefinition = "CREATE FUNCTION test  (   @x int  )  RETURNS int  AS  BEGIN   RETURN @x;  END";
            TestUtils.TestSqlObjectDefinition(expectedDefinition, function.Definition);
        }
    }
}