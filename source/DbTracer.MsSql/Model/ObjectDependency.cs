namespace DbTracer.MsSql.Model
{
    public class ObjectDependency
    {
        private string columnName;
        private string name;
        private ObjectType1 type1;

        public ObjectDependency(string name, string Column, ObjectType1 type1)
        {
            this.name = name;
            this.columnName = Column;
            this.type1 = type1;
        }

        public ObjectDependency(string name, string Column)
        {
            this.name = name;
            this.columnName = Column;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        public ObjectType1 Type1
        {
            get { return type1; }
            set { type1 = value; }
        }

        public bool IsCodeType
        {
            get { return ((type1 == ObjectType1.StoreProcedure) || (type1 == ObjectType1.Trigger) || (type1 == ObjectType1.View) || (type1 == ObjectType1.Function)); }

        }
    }
}