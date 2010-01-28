using NHibernate;

namespace DbTracker.MsSql.Test.Model
{
    public abstract class ATestBase
    {
        public static readonly ISessionFactory SessionFactory = TestConfig.SessionFactory;
    }
}