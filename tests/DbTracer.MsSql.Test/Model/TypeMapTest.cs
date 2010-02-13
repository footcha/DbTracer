using MbUnit.Framework;
using NHibernate;
using NHibernate.Criterion;
using Type = DbTracer.MsSql.Model.Type;

namespace DbTracer.MsSql.Test.Model
{
    public class SystemTypeTest : TypeMapTestBase
    {
        protected override Type ExpectedObject
        {
            get
            {
                return new Type
                {
                    Collation = "Czech_CI_AS",
                    Default = null,
                    Id = 256,
                    IsAssemblyType = false,
                    IsNullable = false,
                    IsUserDefined = false,
                    MaxLength = 256,
                    Name = "sysname",
                    Precision = 0,
                    Rule = null,
                    Scale = 0,
                    Schema = SchemaMapTest.CreateSysSchema(),
                    SystemType = GetTypeByName("nvarchar")
                };
            }
        }
    }

    public class UserTypeTest : TypeMapTestBase
    {
        protected override Type ExpectedObject
        {
            get
            {
                return new Type
                {
                    Collation = "Czech_CI_AS",
                    Default = null,
                    Id = 257,
                    IsAssemblyType = false,
                    IsNullable = false,
                    IsUserDefined = true,
                    MaxLength = 8000,
                    Name = "test_type",
                    Precision = 0,
                    Rule = null,
                    Scale = 0,
                    Schema = SchemaMapTest.CreateDboSchema(),
                    SystemType = GetTypeByName("nvarchar")
                };
            }
        }
    }

    [TestFixture]
    public abstract class TypeMapTestBase : ASqlObjectTestBase
    {
        private Type testedObject;

        protected abstract Type ExpectedObject { get; }

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            testedObject = GetTypeByName(ExpectedObject.Name);
        }

        public static Type GetTypeByName(string typeName)
        {
            using (var session = SessionFactory.OpenSession())
            {
                return GetTypeByName(typeName, session);
            }
        }

        public static Type GetTypeByName(string typeName, ISession session)
        {
            return session.CreateCriteria<Type>()
                    .Add(Restrictions.Eq("Name", typeName))
                    .UniqueResult<Type>();
        }

        public override void LoadTest(string propertyName, object expectedValue) { }

        [RowTest,
        Row("Name"),
        Row("Id"),
        Row("MaxLength"),
        Row("Precision"),
        Row("Scale"),
        Row("Collation"),
        Row("IsNullable"),
        Row("IsUserDefined"),
        Row("IsAssemblyType")]
        public void LoadTest(string propertyName)
        {
            TestUtils.TestProperty(propertyName, ExpectedObject, testedObject);
        }

        [Test]
        public void SystemTypeTest()
        {
            Assert.IsAssignableFrom(typeof(Type), testedObject.SystemType);
            Assert.AreEqual(ExpectedObject.SystemType, testedObject.SystemType);
        }

        [Test]
        public void SchemaTest()
        {
            Assert.IsNotNull(testedObject.Schema);
            Assert.AreEqual(ExpectedObject.Schema, testedObject.Schema);
        }

        [Test,
        Ignore("Create test type containing default object setting")
        ]
        public void DefaultTest()
        {
            Assert.IsNotNull(testedObject.Default);
        }

        [Test,
        Ignore("Create test type containing rule object setting")
        ]
        public void RuleTest()
        {
            Assert.IsNotNull(testedObject.Rule);
        }
    }
}