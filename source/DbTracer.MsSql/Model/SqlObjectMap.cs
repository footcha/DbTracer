using System.Collections.Generic;
using ConfOrm;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class SqlObjectMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.Class<SqlObject>(
                cm =>
                {
                    cm.Schema("sys");
                    cm.Table("objects");
                    cm.Discriminator(d =>
                    {
                        d.Column("type");
                        d.Formula("RTRIM(type)");
                    });
                    cm.Id(c => c.Id, x => x.Column("object_id"));
                    cm.ManyToOne(x => x.Schema, m => m.Column("schema_id"));
                    cm.ManyToOne(o => o.ParentObject, c => c.Column("parent_object_id"));
                    cm.Property(t => t.CreateDate, m => m.Column("modify_date"));
                    cm.Property(t => t.ModifyDate, m => m.Column("create_date"));
                    cm.Property(t => t.PrincipalId, m => m.Column("principal_id"));
                    cm.Property(t => t.PrincipalId, m => m.Column("principal_id"));
                    cm.Property(t => t.IsMsShipped, m => m.Column("is_ms_shipped"));
                    cm.Property(t => t.IsPublished, m => m.Column("is_published"));
                    cm.Property(t => t.IsSchemaPublished, m => m.Column("is_schema_published"));

                });
            orm.TablePerClass<SqlObject>();
            entities.Add(typeof(SqlObject));
        }
    }
}