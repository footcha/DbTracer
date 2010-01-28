using DbTracker.MsSql.Model;
using MbUnit.Framework;
using NHibernate.Criterion;

namespace DbTracker.MsSql.Test.Model
{
    [TestFixture]
    public class TypeMapTest : ASqlObjectTestBase
    {
        private Type type;
        private Type userType;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            type = GetTypeByName("sysname");
            userType = GetTypeByName("test_type");
        }

        private Type GetTypeByName(string typeName)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                return session.CreateCriteria<Type>()
                    .Add(Restrictions.Eq("Name", typeName))
                    .UniqueResult<Type>();
            }
        }

        [RowTest,
        Row("Name", "sysname"),
        Row("Schema", 4),
        Row("Id", 256),
        Row("MaxLength", 256),
        Row("Precision", 0),
        Row("Scale", 0),
        Row("Collation", "Czech_CI_AS"),
        Row("IsNullable", false),
        Row("IsUserDefined", false),
        Row("IsAssemblyType", false),
        Row("DefaultObjectId", 0),
        Row("RuleObjectId", 0),
        ]
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, type);
        }

        [RowTest,
        Row("Name", "test_type"),
        Row("Schema", 1),
        Row("Id", 257),
        Row("MaxLength", 8000),
        Row("Precision", 0),
        Row("Scale", 0),
        Row("Collation", "Czech_CI_AS"),
        Row("IsNullable", false),
        Row("IsUserDefined", true),
        Row("IsAssemblyType", false),
        Row("DefaultObjectId", 0),
        Row("RuleObjectId", 0),
        ]
        public void UserTypeLoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, userType);
        }

        [Test]
        public void TypeGetSystemTypeTest()
        {
            var testingObject = GetTypeByName("nvarchar");
            Assert.IsAssignableFrom(typeof(Type), testingObject.SystemType);
            Assert.AreEqual(testingObject.SystemType, type.SystemType);
        }

        [Test]
        public void UserTypeGetSystemTypeTest()
        {
            var testingObject = GetTypeByName("nvarchar");
            Assert.IsAssignableFrom(typeof(Type), testingObject.SystemType);
            Assert.AreEqual(testingObject.SystemType, userType.SystemType);
        }
    }
}