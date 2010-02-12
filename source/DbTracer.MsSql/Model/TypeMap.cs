namespace DbTracer.MsSql.Model
{
    public class TypeMap : SqlClassMap<Type>
    {
        protected override string TableName
        {
            get { return "sys.types"; }
        }

        protected override void Configure()
        {
            ReadOnly();
            Table(TableName);
            Id(obj => obj.Id, "user_type_id");
            Map(obj => obj.Name, "name");
            References(o => o.SystemType, "system_type_id")
                .Not.LazyLoad();
            References(obj => obj.Schema, "schema_id")
                .Not.LazyLoad();
            Map(o => o.MaxLength, "max_length");
            Map(o => o.Precision, "precision");
            Map(o => o.Scale, "scale");
            Map(o => o.Collation, "collation_name");
            Map(o => o.IsNullable, "is_nullable");
            Map(o => o.IsUserDefined, "is_user_defined");
            Map(o => o.IsAssemblyType, "is_assembly_type");
            References(obj => obj.Default, "default_object_id")
                .Not.LazyLoad()
                .NotFound.Ignore();
            References(obj => obj.Rule, "rule_object_id")
                .Not.LazyLoad()
                .NotFound.Ignore();
        }
    }
}