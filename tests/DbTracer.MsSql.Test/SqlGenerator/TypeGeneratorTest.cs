using System;
using DbTracer.MsSql.SqlGenerator;
using DbTracer.MsSql.Test.Model;
using MbUnit.Framework;
using Rhino.Mocks;
using Type = DbTracer.MsSql.Model.Type;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class TypeGeneratorTest : GeneratorBaseTest<TypeGenerator, Type>
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
        public void ParametersToString(string type, string expectedParametersString)
        {
            var testType = Mocks.Stub<Type>();
            testType.MaxLength = 8;
            testType.Precision = 3;
            testType.Scale = 13;
            SetupResult.For(testType.IsTypeOf(type)).Return(true);
            Mocks.ReplayAll();
            Assert.AreEqual(expectedParametersString, TypeGenerator.ParametersToString(testType));
        }

        [Test,
        ExpectedException(typeof(NotSupportedException), "Assembly types currently are not supported")]
        public void AssemblyTypeIsNotSupported()
        {
            TestedObject = new Type
            {
                IsAssemblyType = true
            };
            var testedGenerator = BuildGenerator(new TypeGenerator(TestedObject));
            testedGenerator.ToCreateSql();
        }

        [Test]
        public void CreateSql()
        {
            var testedGenerator = BuildGenerator(new TypeGenerator(TestedObject));
            const string expectedSql = "CREATE TYPE [test_type] FROM [nvarchar](4000) NOT NULL";
            SqlAssert.AreSqlEqual(expectedSql, testedGenerator.ToCreateSql());
        }

        [Test]
        public void DropSql()
        {
            var testedGenerator = BuildGenerator(new TypeGenerator(TestedObject));
            const string expectedSql = "DROP TYPE [test_type]";
            SqlAssert.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
        }
    }
}