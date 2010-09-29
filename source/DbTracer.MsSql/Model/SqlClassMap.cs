using ConfOrm.NH;
using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public abstract class SqlClassMap
    {
        protected abstract string TableName { get; }

        protected abstract void Configure();

        protected static void ConfigureBasic(Mapper classMap)
        {
            //classMap.ReadOnly();
            classMap.Table(classMap.TableName);
            classMap.Id(obj => obj.Id, "object_id");
            classMap.Map(obj => obj.Name, "name");
        }

        protected static void ConfigureDatabaseObject<T1>(SqlClassMap<T1> classMap)
            where T1 : SqlObject
        {
            ConfigureBasic(classMap);
            classMap.References(obj => obj.Schema, "schema_id")
                .Not.LazyLoad()
                .ReadOnly();
            classMap.Map(obj => obj.Type, "type")
                .CustomType<SqlObjectTypeMap>();
            classMap.Map(obj => obj.CreateDate, "create_date");
            classMap.Map(obj => obj.ModifyDate, "modify_date");
            classMap.Map(obj => obj.IsMsShipped, "is_ms_shipped");
            classMap.Map(obj => obj.IsPublished, "is_published");
            classMap.Map(obj => obj.IsSchemaPublished, "is_schema_published");
        }

        public static void ConfigureCode<T1>(ClasslikeMapBase<T1> classMap)
            where T1 : ICode
        {
            classMap.Map(view => view.Definition, "object_definition")
                .Formula("OBJECT_DEFINITION(object_id)");
        }

        public static void Where<T1>(SqlClassMap<T1> classMap, SqlObjectType type)
            where T1 : SqlObject
        {
            classMap.Where(string.Format("type='{0}'", SqlObjectTypeMap.GetCode(type)));
        }

        public static void Where<T1>(SubclassMap<T1> classMap, SqlObjectType type)
            where T1 : SqlObject{
            
            classMap.Subselect(string.Format("type='{0}'", SqlObjectTypeMap.GetCode(type)));
        }
    }
}