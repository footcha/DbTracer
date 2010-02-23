using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public abstract class KeyConstraintMap<T> : SubclassMap<T>
        where T : KeyConstraint
    {
        protected KeyConstraintMap()
        {
            CreateMapping();
        }

        private void CreateMapping()
        {
            DiscriminatorValue(SqlObjectTypeMap.GetCode(ObjectType));
            Join("sys.key_constraints", t =>
            {
                t.KeyColumn("object_id");
                t.Map(obj => obj.IsSystemNamed, "is_system_named");
                t.References(obj => obj.Index)
                    .Columns("parent_object_id", "unique_index_id");
            });
        }

        protected abstract SqlObjectType ObjectType { get; }
    }
}