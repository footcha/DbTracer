using DbTracker.MsSql.Model;
using FluentNHibernate.Cfg;
using NHibernate;

namespace DbTracker.MsSql.Test.Model
{
    public static class TestConfig
    {
        private static readonly ISessionFactory sessionFactory = CreateSessionFactory();

        public static ISessionFactory SessionFactory
        {
            get { return sessionFactory; }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2005
                    .ConnectionString(connectionStringBuilder =>
                                      connectionStringBuilder
                                          .Server(@"stroj\czprg3k10_dev1")
                                          .Database("dbtracker")
                                          .Username("dbtracker")
                                          .Password("dbtracker"))
                )
                .Mappings(map => map.FluentMappings.AddFromAssemblyOf<DatabaseProperties>())
                .BuildSessionFactory();
        }
    }
}