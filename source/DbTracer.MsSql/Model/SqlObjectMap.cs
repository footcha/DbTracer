namespace DbTracer.MsSql.Model
{
    public class SqlObjectMap : SqlClassMap<SqlObject>
    {
        protected override string TableName
        {
            get { return "sys.objects"; }
        }

        protected override void Configure()
        {
            ConfigureDatabaseObject(this);
            Id(o => o.Id, "object_id");
            References(obj => obj.ParentObject, "parent_object_id")
                .Not.LazyLoad()
                .NotFound.Ignore();
        }
    }
}