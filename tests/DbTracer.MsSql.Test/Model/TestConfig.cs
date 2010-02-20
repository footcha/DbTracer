using DbTracer.MsSql.Model;
using FluentNHibernate.Cfg;
using NHibernate;

namespace DbTracer.MsSql.Test.Model
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
                                          .Database("dbtracer")
                                          .Username("dbtracer")
                                          .Password("dbtracer"))
                )
                .Mappings(map =>
                {
                    map.FluentMappings.AddFromAssemblyOf<DatabaseProperties>();
                    map.HbmMappings.AddFromAssemblyOf<SqlObject>();
                })
                .BuildSessionFactory();
        }
    }
}