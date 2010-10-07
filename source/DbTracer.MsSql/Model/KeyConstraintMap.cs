using System.Collections.Generic;
using ConfOrm;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class KeyConstraintMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.JoinedSubclass<KeyConstraint>(j =>
            {
                j.Schema("sys");
                j.Table("key_constraints");
                j.Key(m => m.Column("object_id"));
                j.Property(p => p.IsSystemNamed, m => m.Column("is_system_named"));
            });

            orm.ExcludeProperty<KeyConstraint>(c => c.Index);
            //orm.TablePerClass<UniqueKeyConstraint>();
            // orm.NaturalId<Column>(e => e.Id, e => e.ParentObject);
            entities.Add(typeof(KeyConstraint));
        }

        //protected KeyConstraintMap()
        //{
        //    CreateMapping();
        //}

        //private void CreateMapping()
        //{
        //    DiscriminatorValue(SqlObjectTypeMap.GetCode(ObjectType));
        //    Join("sys.key_constraints", t =>
        //    {
        //        t.KeyColumn("object_id");
        //        t.Map(obj => obj.IsSystemNamed, "is_system_named");
        //        t.References(obj => obj.Index)
        //            .Columns("parent_object_id", "unique_index_id");
        //    });
        //}

        //protected abstract SqlObjectType ObjectType { get; }
    }
}