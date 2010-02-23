using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class DefaultConstraintMap : SubclassMap<DefaultConstraint>
    {
        public DefaultConstraintMap()
        {
            DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.DefaultConstraint));
            Join("sys.default_constraints", t =>
            {
                t.KeyColumn("object_id");
                t.Map(obj => obj.Definition, "definition");
                t.Map(obj => obj.IsSystemNamed, "is_system_named");
            });
        }
    }
}