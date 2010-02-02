using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public abstract class SqlClassMap<T> : ClassMap<T>
        where T : ISqlObject
    {
        protected SqlClassMap()
        {
            ConfigurePrivate();
        }

        private void ConfigurePrivate()
        {
            Configure();
        }

        protected abstract string TableName { get; }

        protected abstract void Configure();

        protected static void ConfigureBasic<T1>(SqlClassMap<T1> classMap)
            where T1 : ISqlObject
        {
            classMap.ReadOnly();
            classMap.Table(classMap.TableName);
            classMap.Id(obj => obj.Id, "object_id");
            classMap.Map(obj => obj.Name, "name");
            //classMap.Map(obj => obj.Type, "type")
                //.CustomType<SqlObjectTypeMap>();
        }

        protected static void ConfigureCode<T1>(SqlClassMap<T1> classMap)
            where T1 : ICode
        {
            classMap.Map(view => view.Definition, "object_definition")
                .Formula("OBJECT_DEFINITION(object_id)");
        }
    }
}