using System;
using DbTracer.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class StoredProcedureMapTest : SqlObjectTest<StoredProcedure>, ICodeTest
    {
        private StoredProcedure testedObject;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                testedObject = session.CreateCriteria<StoredProcedure>()
                    .Add(Restrictions.Eq("Name", ExpectedObject.Name))
                    .UniqueResult<StoredProcedure>();
            }
        }

        [RowTest,
        Row("IsAutoExecuted"),
        Row("IsExecutionReplicated"),
        Row("IsReplSerializableOnly"),
        Row("SkipsReplConstraints")]
        public void LoadTest(string propertyName)
        {
            TestUtils.TestProperty(propertyName, ExpectedObject, testedObject);
        }

        [Test]
        public void DefinitionTest()
        {
            TestUtils.TestSqlObjectDefinition(ExpectedObject.Definition, testedObject.Definition);
        }

        protected override StoredProcedure ExpectedObject
        {
            get
            {
                return new StoredProcedure()
                {
                    CreateDate = DateTime.Now,
                    Definition = "CREATE PROCEDURE test_stored_procedure    @id int  AS  BEGIN   SET NOCOUNT ON;  END  ",
                    IsMsShipped = false,
                    IsPublished = false,
                    IsSchemaPublished = false,
                    ModifyDate = DateTime.Now,
                    Name = "test_stored_procedure",
                    ParentObject = null,
                    PrincipalId = 0,
                    Schema = SchemaMapTest.CreateDboSchema(),
                    Type = SqlObjectType.SqlStoredProcedure,
                    IsAutoExecuted = false,
                    IsExecutionReplicated = false,
                    IsReplSerializableOnly = false,
                    SkipsReplConstraints = false
                };
            }
        }

        protected override StoredProcedure TestedObject
        {
            get { return testedObject; }
        }
    }
}