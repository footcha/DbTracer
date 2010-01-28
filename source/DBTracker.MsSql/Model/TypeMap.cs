namespace DbTracker.MsSql.Model
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
            Map(o => o.SystemTypeId, "system_type_id");
            //Map(o => o.Schema, "schema_id"); // TODO implement schema as type
            Map(o => o.MaxLength, "max_length");
            Map(o => o.Precision, "precision");
            Map(o => o.Scale, "scale");
            Map(o => o.Collation, "collation_name");
            Map(o => o.IsNullable, "is_nullable");
            Map(o => o.IsUserDefined, "is_user_defined");
            Map(o => o.IsAssemblyType, "is_assembly_type");
            Map(o => o.DefaultObjectId, "default_object_id");
            Map(o => o.RuleObjectId, "rule_object_id");
        }
    }
}