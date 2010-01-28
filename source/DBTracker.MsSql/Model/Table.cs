using System.Collections.Generic;

namespace DbTracker.MsSql.Model
{
    public class Table : ISqlObject
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual SqlObjectType Type { get; set; }

        //public virtual IDictionary<int, Index> Indexes { get; set; }
        
        public virtual ICollection<Index> Indexes { get; set; }

        public virtual IDictionary<int, Trigger> Triggers { get; set; }
    }

    //public class Table : MsSqlSchemaBase, IComparable<Table>, ITable<Table>
    //{
    //    private Columns<Table> columns;
    //    private int dependenciesCount;
    //    private List<ISchema> dependencis;
    //    private Boolean? hasFileStream;

    //    public Table()
    //        : base(ObjectType1.Table)
    //    {
    //        dependenciesCount = -1;
    //        columns = new Columns<Table>();
    //        Constraints = new SchemaList<Constraint, Table>(this);
    //        Options = new SchemaList<TableOption, Table>(this);
    //        //Triggers = new SchemaList<Trigger, Table>(this);
    //        ClrTriggers = new SchemaList<ClrTrigger, Table>(this);
    //        Indexes = new SchemaList<Index, Table>(this);
    //        Partitions = new SchemaList<TablePartition, Table>(this);
    //        FullTextIndex = new SchemaList<FullTextIndex, Table>();
    //    }

    //    public string CompressType { get; set; }

    //    public string FileGroupText { get; set; }

    //    public Boolean HasChangeDataCapture { get; set; }

    //    public Boolean HasChangeTrackingTrackColumn { get; set; }

    //    public Boolean HasChangeTracking { get; set; }

    //    public string FileGroupStream { get; set; }

    //    public Boolean HasClusteredIndex { get; set; }

    //    public string FileGroup { get; set; }

    //    public Table OriginalTable { get; set; }

    //    [Description("Constraints")]
    //    public SchemaList<Constraint, Table> Constraints { get; private set; }

    //    [Description("Indexes")]
    //    public SchemaList<Index, Table> Indexes { get; private set; }

    //    [Description("CLR Triggers")]
    //    public SchemaList<ClrTrigger, Table> ClrTriggers { get; private set; }

    //    //[Description("Triggers")]
    //    //public SchemaList<Trigger, Table> Triggers { get; private set; }

    //    public SchemaList<FullTextIndex, Table> FullTextIndex { get; private set; }

    //    public SchemaList<TablePartition, Table> Partitions { get; set; }

    //    public SchemaList<TableOption, Table> Options { get; set; }

    //    /// <summary>
    //    /// Indica si la tabla tiene alguna columna que sea Identity.
    //    /// </summary>
    //    public Boolean HasIdentityColumn
    //    {
    //        get
    //        {
    //            foreach (Column col in Columns)
    //            {
    //                if (col.IsIdentity) return true;
    //            }
    //            return false;
    //        }
    //    }

    //    public Boolean HasFileStream
    //    {
    //        get
    //        {
    //            if (hasFileStream == null)
    //            {
    //                hasFileStream = false;
    //                foreach (Column col in Columns)
    //                {
    //                    if (col.IsFileStream) hasFileStream = true;
    //                }
    //            }
    //            return hasFileStream.Value;
    //        }
    //    }

    //    public Boolean HasBlobColumn
    //    {
    //        get
    //        {
    //            foreach (Column col in Columns)
    //            {
    //                if (col.IsBlob) return true;
    //            }
    //            return false;
    //        }
    //    }

    //    //public override int DependenciesCount
    //    //{
    //    //    get
    //    //    {
    //    //        if (dependenciesCount == -1)
    //    //            dependenciesCount = ((Database)Parent).Dependencies.DependenciesCount(Id,
    //    //                                                                                   ObjectType1.Constraint);
    //    //        return dependenciesCount;
    //    //    }
    //    //}

    //    #region IComparable<Table> Members

    //    /// <summary>
    //    /// Compara en primer orden por la operacion 
    //    /// (Primero van los Drops, luego los Create y finalesmente los Alter).
    //    /// Si la operacion es la misma, ordena por cantidad de tablas dependientes.
    //    /// </summary>
    //    public int CompareTo(Table other)
    //    {
    //        if (other == null) throw new ArgumentNullException("other");
    //        if (Status == other.Status)
    //            return DependenciesCount.CompareTo(other.DependenciesCount);
    //        return other.Status.CompareTo(Status);
    //    }

    //    #endregion

    //    #region ITable<Table> Members

    //    /// <summary>
    //    /// Coleccion de campos de la tabla.
    //    /// </summary>
    //    [Description("Columns")]
    //    public Columns<Table> Columns
    //    {
    //        get { return columns; }
    //        set { columns = value; }
    //    }

    //    #endregion

    //    /// <summary>
    //    /// Clona el objeto Table en una nueva instancia.
    //    /// </summary>
    //    public override ISchema Clone()
    //    {
    //        var table = new Table
    //        {
    //            Owner = Owner,
    //            Name = Name,
    //            Id = Id,
    //            Status = Status,
    //            FileGroup = FileGroup,
    //            FileGroupText = FileGroupText,
    //            FileGroupStream = FileGroupStream,
    //            HasClusteredIndex = HasClusteredIndex,
    //            HasChangeTracking = HasChangeTracking,
    //            HasChangeTrackingTrackColumn = HasChangeTrackingTrackColumn,
    //            HasChangeDataCapture = HasChangeDataCapture,
    //            dependenciesCount = DependenciesCount
    //        };
    //        table.Columns = Columns.Clone();
    //        table.Options = Options.Clone();
    //        table.CompressType = CompressType;
    //        //table.Triggers = Triggers.Clone();
    //        table.Indexes = Indexes.Clone();
    //        table.Partitions = Partitions.Clone();
    //        return table;
    //    }

    //    /// <summary>
    //    /// Compara dos tablas y devuelve true si son iguales, caso contrario, devuelve false.
    //    /// </summary>
    //    public static Boolean CompareFileGroup(Table origen, Table destino)
    //    {
    //        if (destino == null) throw new ArgumentNullException("destino");
    //        if (origen == null) throw new ArgumentNullException("origen");
    //        if ((!String.IsNullOrEmpty(destino.FileGroup) && (!String.IsNullOrEmpty(origen.FileGroup))))
    //            if (!destino.FileGroup.Equals(origen.FileGroup))
    //                return false;
    //        return true;
    //    }

    //    /// <summary>
    //    /// Compara dos tablas y devuelve true si son iguales, caso contrario, devuelve false.
    //    /// </summary>
    //    public static Boolean CompareFileGroupText(Table origen, Table destino)
    //    {
    //        if (destino == null) throw new ArgumentNullException("destino");
    //        if (origen == null) throw new ArgumentNullException("origen");
    //        if ((!String.IsNullOrEmpty(destino.FileGroupText) && (!String.IsNullOrEmpty(origen.FileGroupText))))
    //            if (!destino.FileGroupText.Equals(origen.FileGroupText))
    //                return false;
    //        return true;
    //    }
    //}
}