using System.Linq;
using DbTracker.MsSql.Model;
using MbUnit.Framework;

namespace DbTracker.MsSql.Test.Model
{
    [TestFixture]
    public class RoleMapTest : ASqlObjectTestBase
    {
        private Role testRole;
        private Role dbOwnerRole;
        private Role dboRole;
        private Role guestRole;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            using (var session = SessionFactory.OpenSession())
            {
                var roles = session.CreateCriteria<Role>().List<Role>();
                testRole = (from role in roles where role.Name == "test_role" select role).First();
                dbOwnerRole = (from role in roles where role.Name == "db_owner" select role).First();
                dboRole = (from role in roles where role.Name == "dbo" select role).First();
                guestRole = (from role in roles where role.Name == "guest" select role).First();
            }
        }

        #region Tests

        //[Test, Ignore]
        //public override void TypeTest()
        //{
        //    throw new NotImplementedException();
        //}

        [RowTest,
        Row("Name", "test_role"),
        Row("IsLogin", false),
        Row("IsNtName", false),
        Row("IsNtGroup", false),
        Row("IsNtUser", false),
        Row("IsSqlUser", false),
        Row("IsAliased", false),
        Row("IsSqlRole", false),
        Row("IsApplicationRole", true),
        ]
        public override void LoadTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, testRole);
        }

        [RowTest,
        Row("Name", "db_owner"),
        Row("IsLogin", false),
        Row("IsNtName", false),
        Row("IsNtGroup", false),
        Row("IsNtUser", false),
        Row("IsSqlUser", false),
        Row("IsAliased", false),
        Row("IsSqlRole", true),
        Row("IsApplicationRole", false),
        ]
        public void LoadDbOwnerRoleTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, dbOwnerRole);
        }


        [RowTest,
        Row("Name", "dbo"),
        Row("IsLogin", true),
        Row("IsNtName", true),
        Row("IsNtGroup", false),
        Row("IsNtUser", true),
        Row("IsSqlUser", false),
        Row("IsAliased", false),
        Row("IsSqlRole", false),
        Row("IsApplicationRole", false),
        ]
        public void LoadDboRoleTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, dboRole);
        }

        [RowTest,
        Row("Name", "guest"),
        Row("IsLogin", true),
        Row("IsNtName", false),
        Row("IsNtGroup", false),
        Row("IsNtUser", false),
        Row("IsSqlUser", true),
        Row("IsAliased", false),
        Row("IsSqlRole", false),
        Row("IsApplicationRole", false),
        ]
        public void LoadGuestRoleTest(string propertyName, object expectedValue)
        {
            TestUtils.TestProperty(propertyName, expectedValue, guestRole);
        }

        #endregion
    }
}