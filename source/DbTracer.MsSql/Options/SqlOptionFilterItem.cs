namespace DbTracer.MsSql.Options
{
    public class SqlOptionFilterItem
    {
        public SqlOptionFilterItem(ObjectType1 type1, string value)
        {
            Filter = value;
            Type1 = type1;
        }

        public ObjectType1 Type1 { get; set; }

        public string Filter { get; set; }
    }
}