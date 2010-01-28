using NHibernate;

namespace DbTracker.MsSql.Test.Model
{
    public abstract class ATestBase
    {
        protected readonly ISessionFactory SessionFactory = TestConfig.SessionFactory;
    }
}