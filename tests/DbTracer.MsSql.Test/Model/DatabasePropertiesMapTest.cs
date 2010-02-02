using DbTracer.Core.Reflection;
using DbTracer.Core.Schema.Model;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public class DatabasePropertiesMapTest : ATestBase
    {
        private DatabaseProperties testedObject;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var q = DatabasePropertiesMap.CreateQuery(session);
                testedObject = q.UniqueResult<DatabaseProperties>();
            }
        }

        [Test]
        public void PropertiesCountTest()
        {
            var ps = Search.GetPropertiesWithAttribute<DatabasePropertyAttribute>(typeof(DatabaseProperties));
            Assert.AreEqual(32, ps.Count);
        }

        [RowTest,
        Row("Collation", "Czech_CI_AS"),
        Row("ComparisonStyle", 196609),
        Row("IsAnsiNullDefault", false),
        Row("IsAnsiNullsEnabled", false),
        Row("IsAnsiPaddingEnabled", false),
        Row("IsAnsiWarningsEnabled", false),
        Row("IsArithmeticAbortEnabled", false),
        Row("IsAutoClose", false),
        Row("IsAutoCreateStatistics", true),
        Row("IsAutoShrink", false),
        Row("IsAutoUpdateStatistics", true),
        Row("IsCloseCursorsOnCommitEnabled", false),
        Row("IsFulltextEnabled", false),
        Row("IsInStandBy", false),
        Row("IsLocalCursorsDefault", false),
        Row("IsMergePublished", false),
        Row("IsNullConcat", false),
        Row("IsNumericRoundAbortEnabled", false),
        Row("IsParameterizationForced", false),
        Row("IsQuotedIdentifiersEnabled", false),
        Row("IsPublished", false),
        Row("IsRecursiveTriggersEnabled", false),
        Row("IsSubscribed", false),
        Row("IsSyncWithBackup", false),
        Row("IsTornPageDetectionEnabled", false),
        Row("Lcid", 1029),
        Row("Recovery", "FULL"),
        Row("SqlSortOrder", 0),
        Row("Status", "ONLINE"),
        Row("Updateability", "READ_WRITE"),
        Row("UserAccess", "MULTI_USER"),
        Row("Version", 611)]
        public void LoadTest(string propertyName, object expectedValue)
        {
            var propInfo = typeof(DatabaseProperties).GetProperty(propertyName);
            var testedValue = propInfo.GetValue(testedObject, null);
            Assert.AreEqual(expectedValue, testedValue);

        }
    }
}