using System;
using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class FunctionMapTest : SqlObjectTest<Function>, ICodeTest
    {
        private Function testedObject;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                testedObject = session.CreateCriteria<Function>()
                    .Add(Restrictions.Eq("Name", "test_fcn"))
                    .UniqueResult<Function>();
            }
        }

        [Test]
        public void DefinitionTest()
        {
            TestUtils.TestSqlObjectDefinition(ExpectedObject.Definition, testedObject.Definition);
        }

        protected override Function ExpectedObject
        {
            get
            {
                return new Function
                {
                    CreateDate = DateTime.Now,
                    Definition = "CREATE FUNCTION test  (   @x int  )  RETURNS int  AS  BEGIN   RETURN @x;  END",
                    IsMsShipped = false,
                    IsPublished = false,
                    IsSchemaPublished = false,
                    ModifyDate = DateTime.Now,
                    Name = "test_fcn",
                    ParentObject = null,
                    PrincipalId = 0,
                    Schema = SchemaMapTest.CreateDboSchema(),
                    Type = SqlObjectType.SqlScalarFunction
                };
            }
        }

        protected override Function TestedObject
        {
            get { return testedObject; }
        }
    }
}