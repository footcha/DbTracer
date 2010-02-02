using NHibernate;

namespace DbTracer.MsSql.Test.Model
{
    public abstract class ATestBase
    {
        public static readonly ISessionFactory SessionFactory = TestConfig.SessionFactory;
    }
}