namespace DbTracker.MsSql.Model
{
    public class TableType : MsSqlSchemaBase, ITable<TableType>
    {
        //private readonly Columns<TableType> columns;
        private readonly SchemaList<Constraint, TableType> constraints;
        //private readonly SchemaList<Index, TableType> indexes;

        public TableType(Database parent)
            : base(parent, ObjectType1.TableType)
        {
            //columns = new Columns<TableType>();
            constraints = new SchemaList<Constraint, TableType>(this);
            //indexes = new SchemaList<Index, TableType>(this);
        }

        //public Columns<TableType> Columns
        //{
        //    get { return columns; }
        //}

        public SchemaList<Constraint, TableType> Constraints
        {
            get { return constraints; }
        }

        //public SchemaList<Index, TableType> Indexes
        //{
        //    get { return indexes; }
        //}
    }
}