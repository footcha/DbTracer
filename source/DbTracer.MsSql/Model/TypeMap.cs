using ConfOrm;
using ConfOrm.NH;
using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class TypeMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.Class<Type>(j =>
            {
                j.Schema("sys");
                j.Table("types");
                j.Id(e => e.Column("user_type_id"));
                j.Property(e => e.MaxLength, m => m.Column("max_length"));
                j.Property(e => e.Precision, m => m.Column("precision"));
                j.Property(e => e.Scale, m => m.Column("scale"));
                j.Property(e => e.Collation, m => m.Column("collation_name"));
                j.Property(e => e.IsNullable, m => m.Column("is_nullable"));
                j.Property(e => e.IsUserDefined, m => m.Column("is_user_defined"));
                j.Property(e => e.IsAssemblyType, m => m.Column("is_assembly_type"));
                j.Property(e => e.Name, m => m.Column("name"));
                j.ManyToOne(e => e.Schema, m => m.Column("schema_id"));
                j.ManyToOne(e => e.SystemType, m => m.Column("system_type_id"));
            });

            entities.Add(typeof(Type));
            orm.TablePerClass<Type>();

            orm.ExcludeProperty<Type>(e => e.Rule);
            orm.ExcludeProperty<Type>(e => e.Default);
            //orm.ExcludeProperty<Type>(e => e.SystemType);
        }

        //protected override void Configure()
        //{
        //    References(obj => obj.Default, "default_object_id")
        //        .Not.LazyLoad()
        //        .NotFound.Ignore();
        //    References(obj => obj.Rule, "rule_object_id")
        //        .Not.LazyLoad()
        //        .NotFound.Ignore();
        //}
    }
}