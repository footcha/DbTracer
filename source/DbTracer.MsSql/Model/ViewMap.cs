using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class ViewMap : SubclassMap<View>
    {
        public ViewMap()
        {
            Table("sys.views");
            KeyColumn("object_id");
            SqlClassMap<View>.ConfigureCode(this);
            HasMany(view => view.Triggers)
                .KeyColumn("parent_id")
                .AsMap("object_id")
                .Not.LazyLoad()
                .ReadOnly();
        }
    }
}