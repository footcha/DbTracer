namespace DbTracer.MsSql.Model
{
    public class ObjectMap : SqlClassMap<SqlObject>
    {
        protected override string TableName
        {
            get { return "sys.objects"; }
        }

        protected override void Configure()
        {
            ConfigureDatabaseObject(this);
            Id(o => o.Id, "object_id");
        }
    }
}