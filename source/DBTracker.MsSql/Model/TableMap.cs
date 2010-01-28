namespace DbTracker.MsSql.Model
{
    public class TableMap : SqlClassMap<Table>
    {
        protected override string TableName
        {
            get { return "sys.tables"; }
        }

        protected override void Configure()
        {
            ConfigureBasic(this);
            HasMany(table => table.Triggers)
                .KeyColumn("parent_id")
                .AsMap("object_id")
                .Not.LazyLoad()
                .ReadOnly();
            HasMany(table => table.Indexes)
                .KeyColumn("object_id")
                .AsSet()
                .Not.LazyLoad()
                .ReadOnly();
        }
    }
}