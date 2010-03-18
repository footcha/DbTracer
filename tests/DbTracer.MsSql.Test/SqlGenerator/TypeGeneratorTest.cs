using System;
using DbTracer.MsSql.SqlGenerator;
using DbTracer.MsSql.Test.Model;
using MbUnit.Framework;
using Rhino.Mocks;
using Type = DbTracer.MsSql.Model.Type;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class TypeGeneratorTest : GeneratorBaseTest<Type>
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            TestedObject = UserTypeTest.TestingObject;
        }

        [RowTest,
        Row("decimal", "(3, 13)"),
        Row("numeric", "(3, 13)"),
        Row("nchar", "(4)"),
        Row("nvarchar", "(4)"),
        Row("binary", "(8)"),
        Row("varbinary", "(8)"),
        Row("char", "(8)"),
        Row("varchar", "(8)"),
        Row("image", ""),
        ]
        public void ParametersToStringTest(string type, string expectedParametersString)
        {
            var testType = Mocks.DynamicMock<Type>();
            using (Mocks.Record())
            {
                SetupResult.For(testType.IsTypeOf(type)).Return(true);
                SetupResult.For(testType.MaxLength).Return(8);
                SetupResult.For(testType.Precision).Return(3);
                SetupResult.For(testType.Scale).Return(13);
            }
            using (Mocks.Playback())
            {
                Assert.AreEqual(expectedParametersString, TypeGenerator.ParametersToString(testType));
            }
        }

        [Test,
        ExpectedException(typeof(NotSupportedException), "Assembly types currently are not supported")]
        public void AssemblyTypeTest()
        {
            TestedObject = Mocks.DynamicMock<Type>();
            using (Mocks.Record())
            {
                Expect.Call(TestedObject.IsAssemblyType).Return(true);
            }
            using (Mocks.Playback())
            {
                var testedGenerator = BuildGenerator(new TypeGenerator(TestedObject));
                testedGenerator.ToCreateSql();
            }
        }

        [Test]
        public void UserTypeCreateTest()
        {
            using (Mocks.Record()) { }
            using (Mocks.Playback())
            {
                var testedGenerator = BuildGenerator(new TypeGenerator(TestedObject));
                const string expectedSql = "CREATE TYPE [test_type] FROM [nvarchar](4000) NOT NULL";
                Utils.AreSqlEqual(expectedSql, testedGenerator.ToCreateSql());
            }
        }

        [Test]
        public void DropTest()
        {
            using (Mocks.Record()) { }
            using (Mocks.Playback())
            {
                var testedGenerator = BuildGenerator(new TypeGenerator(TestedObject));
                const string expectedSql = "DROP TYPE [test_type]";
                Utils.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
            }
        }
    }
}