using System.Collections.Generic;
using ConfOrm;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class SchemaMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.Class<Schema>(
                cm =>
                {
                    cm.Schema("sys");
                    cm.Table("schemas");
                    cm.Id(c => c.Id, x => x.Column("schema_id"));
                    cm.Property(c => c.Name, c => c.Column("name"));
                    cm.Property(c => c.PrincipalId, c => c.Column("principal_id"));
                });
            orm.TablePerClass(new List<System.Type> { typeof(Schema) });
            entities.Add(typeof(Schema));
        }
    }
}