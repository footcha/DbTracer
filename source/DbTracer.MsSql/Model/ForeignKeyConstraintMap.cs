using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class ForeignKeyConstraintMap : SubclassMap<ForeignKeyConstraint>
    {
        public ForeignKeyConstraintMap()
        {
            DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.ForeignKeyConstraint));
            Join("sys.foreign_keys", join =>
            {
                join.KeyColumn("object_id");
                join.References(obj => obj.ReferencedObject, "referenced_object_id")
                    .Not.LazyLoad();
                join.References(obj => obj.Index)
                    .Columns("referenced_object_id", "key_index_id")
                    .Not.LazyLoad();
                join.Map(obj => obj.IsDisabled, "is_disabled");
                join.Map(obj => obj.IsNotForReplication, "is_not_for_replication");
                join.Map(obj => obj.IsNotTrusted, "is_not_trusted");
                join.Map(obj => obj.DeleteReferentialAction, "delete_referential_action");
                join.Map(obj => obj.UpdateReferentialAction, "update_referential_action");
                join.Map(obj => obj.IsSystemNamed, "is_system_named");
            });
        }
    }
}