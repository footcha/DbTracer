using System.Collections.Generic;
using ConfOrm;
using ConfOrm.NH;
using DbTracer.MsSql.Model;
using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using Type = System.Type;

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
            var cfg = new Configuration();
            cfg.DataBaseIntegration(db =>
            {
                db.ConnectionString = @"Server=stroj\czprg3k10_dev1;Initial Catalog=dbtracer;User ID=dbtracer;Password=dbtracer";
                db.Driver<SqlClientDriver>();
                db.Dialect<MsSql2005Dialect>();
                db.BatchSize = 20;
                db.Timeout = 6;
            });
            cfg.Proxy(proxy => proxy.ProxyFactoryFactory<ProxyFactoryFactory>());
            cfg.AddDeserializedMapping(GetMapping(), "ORMSamples_ConfORM");

            return cfg.BuildSessionFactory();
        }

        private static HbmMapping GetMapping()
        {
            var orm = new ObjectRelationalMapper();
            var mapper = new Mapper(orm);
            var entities = new List<Type>();

            new SqlObjectMap().Configure(orm, mapper, entities);
            new SchemaMap().Configure(orm, mapper, entities);
            new ViewMap().Configure(orm, mapper, entities);
            new TriggerMap().Configure(orm, mapper, entities);
            new TableMap().Configure(orm, mapper, entities);
            new CheckConstraintMap().Configure(orm, mapper, entities);
            new ColumnMap().Configure(orm, mapper, entities);
            new TypeMap().Configure(orm, mapper, entities);
            new DefaultConstraintMap().Configure(orm, mapper, entities);

            return mapper.CompileMappingFor(entities);
        }
    }
}