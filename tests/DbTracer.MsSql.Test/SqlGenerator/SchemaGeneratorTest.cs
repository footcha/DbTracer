using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using MbUnit.Framework;
using Rhino.Mocks;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class SchemaGeneratorTest : GeneratorBaseTest<Schema>
    {
        [Test]
        public void CreateTest()
        {
            TestedObject = Mocks.DynamicMock<Schema>();
            using (Mocks.Record())
            {
                Expect.Call(TestedObject.Name)
                    .Return("test_schema");
            }
            using (Mocks.Playback())
            {
                const string expectedSql = "CREATE SCHEMA [test_schema]";
                var testedGenerator = BuildGenerator(new SchemaGenerator(TestedObject));
                Utils.AreSqlEqual(expectedSql, testedGenerator.ToCreateSql());
            }
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
                var testedGenerator = BuildGenerator(new SchemaGenerator(TestedObject));
                testedGenerator.GenerateAuthorization = true;

                Utils.AreSqlEqual(expectedSql, testedGenerator.ToCreateSql());
            }
        }

        [Test]
        public void DropTest()
        {
            TestedObject = Mocks.Stub<Schema>();
            using (Mocks.Record())
            {
                TestedObject.Name = "test_schema";
            }
            using (Mocks.Playback())
            {
                const string expectedSql = "DROP SCHEMA [test_schema]";
                var testedGenerator = BuildGenerator(new SchemaGenerator(TestedObject));
                Utils.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
            }
        }
    }
}