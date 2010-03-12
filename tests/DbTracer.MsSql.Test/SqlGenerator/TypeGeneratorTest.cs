using System;
using System.Text.RegularExpressions;
using DbTracer.Core.Schema.SqlGenerator;
using DbTracer.MsSql.SqlGenerator;
using DbTracer.MsSql.Test.Model;
using MbUnit.Framework;
using Rhino.Mocks;
using Type = DbTracer.MsSql.Model.Type;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class TypeGeneratorTest
    {
        private MockRepository mocks;
        private Type testedObject;
        private IKeywordEncoder keyWordEncoder;
        private IFullNameBuilder fullNameBuilder;

        [SetUp]
        public void SetUp()
        {
            mocks = new MockRepository();
            testedObject = UserTypeTest.TestingObject;
            keyWordEncoder = mocks.DynamicMock<IKeywordEncoder>();
            fullNameBuilder = mocks.DynamicMock<IFullNameBuilder>();
            SetupResult.For(fullNameBuilder.BuildName(null))
                .IgnoreArguments().Return("UnknownName");
        }

        [TearDown]
        public void TearDown()
        {
            mocks.VerifyAll();
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
            var testType = mocks.DynamicMock<Type>();
            SetupResult.For(testType.IsTypeOf(type)).Return(true);
            SetupResult.For(testType.MaxLength).Return(8);
            SetupResult.For(testType.Precision).Return(3);
            SetupResult.For(testType.Scale).Return(13);

            mocks.ReplayAll();

            Assert.AreEqual(expectedParametersString, TypeGenerator.ParametersToString(testType));
        }

        [Test,
        ExpectedException(typeof(NotSupportedException), "Assembly types currently are not supported")]
        public void AssemblyTypeTest()
        {
            var testType = mocks.DynamicMock<Type>();
            Expect.Call(testType.IsAssemblyType).Return(true);
            var generator = CreateGenerator(testType);

            mocks.ReplayAll();

            generator.ToCreateSql();
        }

        [Test]
        public void UserTypeCreateTest()
        {
            var generator = CreateGenerator(testedObject);
            RegisterEncodeString("nvarchar");

            mocks.ReplayAll();

            const string expectedSql = "CREATE TYPE UnknownName FROM [nvarchar](4000) NOT NULL";
            Utils.AreSqlEqual(expectedSql, generator.ToCreateSql());
        }

        [Test]
        public void DropTest()
        {
            var generator = CreateGenerator(new Type());
            const string expectedSql = "DROP TYPE UnknownName";

            mocks.ReplayAll();

            Utils.AreSqlEqual(expectedSql, generator.ToDropSql());
        }

        private void RegisterEncodeString(string text)
        {
            Expect.Call(keyWordEncoder.Encode(text))
                .Return(string.Format("[{0}]", text));
        }

        private TypeGenerator CreateGenerator(Type type)
        {
            return new TypeGenerator(type)
            {
                FullNameBuilder = fullNameBuilder,
                KeywordEncoder = keyWordEncoder
            };
        }

        private static class Utils
        {
            static readonly Regex regex = new Regex(@"\s+");

            public static void AreSqlEqual(string sql1, string sql2)
            {
                sql1 = regex.Replace(sql1, "");
                sql2 = regex.Replace(sql2, "");
                Assert.AreEqual(sql1, sql2);
            }
        }
    }
}