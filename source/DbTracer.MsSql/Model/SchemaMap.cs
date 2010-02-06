namespace DbTracer.MsSql.Model
{
    public class SchemaMap : SqlClassMap<Schema>
    {
        protected override string TableName
        {
            get { return "sys.schemas"; }
        }

        protected override void Configure()
        {
            ReadOnly();
            Table(TableName);
            Id(obj => obj.Id, "schema_id");
            Map(obj => obj.Name, "name");
            Map(obj => obj.PrincipalId, "principal_id");
        }
    }
}