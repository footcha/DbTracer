namespace DbTracer.MsSql.Model
{
    public class ViewMap : SqlClassMap<View>
    {
        protected override void Configure()
        {
            ConfigureBasic(this);
            ConfigureCode(this);
            HasMany(view => view.Triggers)
                .KeyColumn("parent_object_id")
                .AsMap("object_id")
                .Not.LazyLoad()
                .ReadOnly();
        }

        protected override string TableName
        {
            get { return "sys.views"; }
        }
    }
}