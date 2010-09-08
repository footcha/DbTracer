using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using MbUnit.Framework;
using Rhino.Mocks;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class SchemaGeneratorTest : GeneratorBaseTest<SchemaGenerator, Schema>
    {
        [Test]
        public void CreateTest()
        {
            TestedObject = new Schema
            {
                Name = "test_schema"
            };
            const string expectedSql = "CREATE SCHEMA [test_schema]";
            var testedGenerator = BuildGenerator(new SchemaGenerator(TestedObject));
            Utils.AreSqlEqual(expectedSql, testedGenerator.ToCreateSql());
        }

        [Test]
        public void CreateWithAuthorizationTest()
        {
            TestedObject = Mocks.DynamicMock<Schema>();
            using (Mocks.Record())
            {
                Expect.Call(TestedObject.Name)
                    .Return("test_schema");
                Expect.Call(TestedObject.Principal.Name)
                    .Return("test_user");
            }
            using (Mocks.Playback())
            {
                const string expectedSql = "CREATE SCHEMA [test_schema] AUTHORIZATION [test_user]";
                TestedGenerator = BuildGenerator(new SchemaGenerator(TestedObject));
                TestedGenerator.GenerateAuthorization = true;

                Utils.AreSqlEqual(expectedSql, TestedGenerator.ToCreateSql());
            }
        }

        [Test]
        public void DropTest()
        {
            TestedObject = new Schema
            {
                Name = "test_schema"
            };
            const string expectedSql = "DROP SCHEMA [test_schema]";
            TestedGenerator = BuildGenerator(new SchemaGenerator(TestedObject));
            Utils.AreSqlEqual(expectedSql, TestedGenerator.ToDropSql());
        }
    }
}