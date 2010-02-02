using System.Collections.ObjectModel;

namespace DbTracer.MsSql.Options
{
    public class SqlOptionFilter
    {
        private readonly Collection<SqlOptionFilterItem> items;

        public SqlOptionFilter()
        {
            items = new Collection<SqlOptionFilterItem>();
            Items.Add(new SqlOptionFilterItem(ObjectType1.Table, "dbo.dtproperties"));
        }

        public Collection<SqlOptionFilterItem> Items
        {
            get { return items; }
        }

    }
}