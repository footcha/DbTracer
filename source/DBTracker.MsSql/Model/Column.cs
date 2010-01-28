namespace DbTracker.MsSql.Model
{
    public class Column : ISqlObject
    {
        public virtual int Id { get; set; }
        public virtual int ColumnId { get; set; }
        public virtual string Name { get; set; }
        public virtual Type SystemType { get; set; }
        public virtual Type UserType { get; set; }
        public virtual int MaxLength { get; set; }
        public virtual int Precision { get; set; }
        public virtual int Scale { get; set; }
        public virtual string Collation { get; set; }
        public virtual bool IsNullable { get; set; }
        public virtual bool IsAnsiPadded { get; set; }
        public virtual bool IsRowGuidCol { get; set; }
        public virtual bool IsIdentity { get; set; }
        public virtual bool IsComputed { get; set; }
        public virtual bool IsFileStream { get; set; }
        public virtual bool IsReplicated { get; set; }
        public virtual bool IsNonSqlSubscribed { get; set; }
        public virtual bool IsMergePublished { get; set; }
        public virtual bool IsDtsReplicated { get; set; }
        public virtual bool IsXmlDocument { get; set; }
        public virtual int XmlCollectionId { get; set; }
        public virtual int DefaultObjectId { get; set; }
        public virtual int RuleObjectId { get; set; }

        public override bool Equals(object that)
        {
            if (ReferenceEquals(null, that)) return false;
            if (ReferenceEquals(this, that)) return true;
            var thatColumn = that as Column;
            if (thatColumn == null) return false;
            return thatColumn.Id == Id && thatColumn.ColumnId == ColumnId; ;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ ColumnId;
            }
        }
    }

    //public class Column : MsSqlSchemaBase, IComparable<Column>
    //{
    //    public Column()
    //        : base(ObjectType1.Column)
    //    {
    //        ComputedFormula = "";
    //        Collation = "";
    //        Default = new Default();
    //        Rule = new Rule();
    //        DefaultConstraint = null;
    //    }

    //    /// <summary>
    //    /// Clona el objeto Column en una nueva instancia.
    //    /// </summary>
    //    public new Column Clone()
    //    {
    //        var col = new Column
    //        {
    //            ComputedFormula = ComputedFormula,
    //            DataUserTypeId = DataUserTypeId,
    //            Id = Id,
    //            Owner = Owner,
    //            IdentityIncrement = IdentityIncrement,
    //            IdentitySeed = IdentitySeed,
    //            IsIdentity = IsIdentity,
    //            IsIdentityForReplication = IsIdentityForReplication,
    //            IsComputed = IsComputed,
    //            IsRowGuid = IsRowGuid,
    //            IsPersisted = IsPersisted,
    //            IsFileStream = IsFileStream,
    //            IsSparse = IsSparse,
    //            IsXmlDocument = IsXmlDocument,
    //            IsUserDefinedType = IsUserDefinedType,
    //            HasComputedDependencies = HasComputedDependencies,
    //            HasIndexDependencies = HasIndexDependencies,
    //            Name = Name,
    //            IsNullable = IsNullable,
    //            Position = Position,
    //            Precision = Precision,
    //            Scale = Scale,
    //            Collation = Collation,
    //            Size = Size,
    //            Status = Status,
    //            Type = Type,
    //            XmlSchema = XmlSchema,
    //            Default = Default.Clone(),
    //            Rule = Rule.Clone()
    //        };
    //        if (DefaultConstraint != null)
    //            col.DefaultConstraint = DefaultConstraint.Clone();

    //        return col;
    //    }

    //    public ColumnConstraint DefaultConstraint { get; set; }

    //    public Rule Rule { get; set; }

    //    public Default Default { get; set; }

    //    public bool IsFileStream { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether this instance is Xml document.
    //    /// </summary>
    //    /// <value>
    //    /// 	<c>true</c> if this instance is Xml document; otherwise, <c>false</c>.
    //    /// </value>
    //    public Boolean IsXmlDocument { get; set; }

    //    /// <summary>
    //    /// Gets or sets the Xml schema.
    //    /// </summary>
    //    /// <value>The Xml schema.</value>
    //    public string XmlSchema { get; set; }

    //    public Boolean IsSparse { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether this instance is user defined type.
    //    /// </summary>
    //    /// <value>
    //    /// 	<c>true</c> if this instance is user defined type; otherwise, <c>false</c>.
    //    /// </value>
    //    public Boolean IsUserDefinedType { get; set; }

    //    public int DataUserTypeId { get; set; }

    //    /// <summary>
    //    /// Gets or sets the column position.
    //    /// </summary>
    //    /// <value>The position.</value>
    //    public int Position { get; set; }

    //    /// <summary>
    //    /// Gets or sets the scale (only in numeric or decimal datatypes).
    //    /// </summary>
    //    /// <value>The scale.</value>
    //    public int Scale { get; set; }

    //    /// <summary>
    //    /// Gets or sets the precision (only in numeric or decimal datatypes).
    //    /// </summary>
    //    /// <value>The precision.</value>
    //    public int Precision { get; set; }

    //    /// <summary>
    //    /// Gets or sets the collation (only in text datatypes).
    //    /// </summary>
    //    /// <value>The collation.</value>
    //    public string Collation { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether this <see cref="Column"/> is nullable.
    //    /// </summary>
    //    /// <value><c>true</c> if nullable; otherwise, <c>false</c>.</value>
    //    public Boolean IsNullable { get; set; }

    //    /// <summary>
    //    /// Gets or sets the size.
    //    /// </summary>
    //    /// <value>The size.</value>
    //    public int Size { get; set; }

    //    /// <summary>
    //    /// Gets or sets the type.
    //    /// </summary>
    //    /// <value>The type.</value>
    //    public string Type { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether this instance is persisted (only in Computed columns).
    //    /// </summary>
    //    /// <value>
    //    /// 	<c>true</c> if this instance is persisted; otherwise, <c>false</c>.
    //    /// </value>
    //    public Boolean IsPersisted { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether this instance has index dependencies.
    //    /// </summary>
    //    /// <value>
    //    /// 	<c>true</c> if this instance has index dependencies; otherwise, <c>false</c>.
    //    /// </value>
    //    public Boolean HasIndexDependencies { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether this instance has computed dependencies.
    //    /// </summary>
    //    /// <value>
    //    /// 	<c>true</c> if this instance has computed dependencies; otherwise, <c>false</c>.
    //    /// </value>
    //    public Boolean HasComputedDependencies { get; set; }

    //    /// <summary>
    //    /// Gets a value indicating whether this instance has to rebuild only constraint.
    //    /// </summary>
    //    /// <value>
    //    /// 	<c>true</c> if this instance has to rebuild only constraint; otherwise, <c>false</c>.
    //    /// </value>
    //    public Boolean HasToRebuildOnlyConstraint
    //    {
    //        get
    //        {
    //            return (HasIndexDependencies && !HasComputedDependencies && !IsComputed);
    //        }
    //    }
    //    /// <summary>
    //    /// Gets a value indicating whether this instance has to rebuild.
    //    /// </summary>
    //    /// <value>
    //    /// 	<c>true</c> if this instance has to rebuild; otherwise, <c>false</c>.
    //    /// </value>
    //    public Boolean HasToRebuild(int newPosition, string newType, bool isFileStream)
    //    {
    //        if (newType.Equals("text") && (!IsText)) return true;
    //        if (newType.Equals("ntext") && (!IsText)) return true;
    //        if (newType.Equals("image") && (!IsBinary)) return true;
    //        if (isFileStream != IsFileStream) return true;
    //        return ((Position != newPosition) || HasComputedDependencies || HasIndexDependencies || IsComputed || Type.ToLower().Equals("timestamp"));
    //    }

    //    /// <summary>
    //    /// Gets or sets the computed formula (only in Computed columns).
    //    /// </summary>
    //    /// <value>The computed formula.</value>
    //    public string ComputedFormula { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether this instance is computed.
    //    /// </summary>
    //    /// <value>
    //    /// 	<c>true</c> if this instance is computed; otherwise, <c>false</c>.
    //    /// </value>
    //    public bool IsComputed { get; set; }

    //    /// <summary>
    //    /// Gets a value indicating whether this column is BLOB.
    //    /// </summary>
    //    /// <value><c>true</c> if this column is BLOB; otherwise, <c>false</c>.</value>
    //    public Boolean IsBlob
    //    {
    //        get
    //        {
    //            return Type.Equals("varchar(MAX)") || Type.Equals("nvarchar(MAX)") || Type.Equals("varbinary(MAX)") || Type.Equals("text") || Type.Equals("image") || Type.Equals("ntext") || Type.Equals("xml");
    //        }
    //    }

    //    public Boolean IsText
    //    {
    //        get
    //        {
    //            return Type.Equals("varchar(MAX)") || Type.Equals("nvarchar(MAX)") || Type.Equals("ntext") || Type.Equals("text") || Type.Equals("nvarchar") || Type.Equals("varchar") || Type.Equals("xml") || Type.Equals("char") || Type.Equals("nchar");
    //        }
    //    }

    //    public Boolean IsBinary
    //    {
    //        get
    //        {
    //            return Type.Equals("varbinary") || Type.Equals("varbinary(MAX)") || Type.Equals("image") || Type.Equals("binary");
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether this field is identity for replication.
    //    /// </summary>
    //    /// <value>
    //    /// 	<c>true</c> if this field is identity for replication; otherwise, <c>false</c>.
    //    /// </value>
    //    public bool IsIdentityForReplication { get; set; }

    //    /// <summary>
    //    /// Gets or sets a value indicating whether this field is identity.
    //    /// </summary>
    //    /// <value>
    //    /// 	<c>true</c> if this field is identity; otherwise, <c>false</c>.
    //    /// </value>
    //    public bool IsIdentity { get; set; }

    //    /// <summary>
    //    /// Gets or sets the identity increment (only if the field is Identity).
    //    /// </summary>
    //    /// <value>The identity increment.</value>
    //    public int IdentityIncrement { get; set; }

    //    /// <summary>
    //    /// Gets or sets the identity seed (only if the field is Identity).
    //    /// </summary>
    //    /// <value>The identity seed.</value>
    //    public int IdentitySeed { get; set; }

    //    /// <summary>
    //    /// Indica si el campo es Row Guid
    //    /// </summary>
    //    public Boolean IsRowGuid { get; set; }

    //    /// <summary>
    //    /// Nombre completo del objeto, incluyendo el owner.
    //    /// </summary>
    //    public override string FullName
    //    {
    //        get
    //        {
    //            return Parent.FullName + ".[" + Name + "]";
    //        }
    //    }

    //    public Boolean HasToForceValue
    //    {
    //        get
    //        {
    //            return (HasState(ObjectStatus.UpdateStatus)) || ((!IsNullable) && (Status == ObjectStatus.CreateStatus));
    //        }
    //    }

    //    /// <summary>
    //    /// Gets the default force value.
    //    /// </summary>
    //    /// <value>The default force value.</value>
    //    public string DefaultForceValue
    //    {
    //        get
    //        {
    //            var tl = Type;
    //            if (IsUserDefinedType)
    //                tl = ((Database)Parent.Parent).UserTypes[Type].Type.ToLower();

    //            if ((((Database)Parent.Parent).Options.Defaults.UseDefaultValueIfExists) && (DefaultConstraint != null))
    //            {
    //                return DefaultConstraint.Definition;
    //            }
    //            if (tl.Equals("time")) return ((Database)Parent.Parent).Options.Defaults.DefaultTime;
    //            if (tl.Equals("int") || tl.Equals("bit") || tl.Equals("smallint") || tl.Equals("bigint") || tl.Equals("tinyint")) return ((Database)Parent.Parent).Options.Defaults.DefaultIntegerValue;
    //            if (tl.Equals("text") || tl.Equals("char") || tl.Equals("varchar") || tl.Equals("varchar(max)")) return ((Database)Parent.Parent).Options.Defaults.DefaultTextValue;
    //            if (tl.Equals("ntext") || tl.Equals("nchar") || tl.Equals("nvarchar") || tl.Equals("nvarchar(max)")) return ((Database)Parent.Parent).Options.Defaults.DefaultNTextValue;
    //            if (tl.Equals("date") || tl.Equals("datetimeoffset") || tl.Equals("datetime2") || tl.Equals("datetime") || tl.Equals("smalldatetime")) return ((Database)Parent.Parent).Options.Defaults.DefaultDateValue;
    //            if (tl.Equals("numeric") || tl.Equals("decimal") || tl.Equals("float") || tl.Equals("money") || tl.Equals("smallmoney") || tl.Equals("real")) return ((Database)Parent.Parent).Options.Defaults.DefaultRealValue;
    //            if (tl.Equals("sql_variant")) return ((Database)Parent.Parent).Options.Defaults.DefaultVariantValue;
    //            if (tl.Equals("uniqueidentifier")) return ((Database)Parent.Parent).Options.Defaults.DefaultUniqueValue;
    //            if (tl.Equals("image") || tl.Equals("binary") || tl.Equals("varbinary")) return ((Database)Parent.Parent).Options.Defaults.DefaultBlobValue;
    //            return "";
    //        }
    //    }

    //    /// <summary>
    //    /// Compara solo las propiedades de dos campos relacionadas con los Identity. Si existen
    //    /// diferencias, devuelve falso, caso contrario, true.
    //    /// </summary>
    //    public static Boolean CompareIdentity(Column origen, Column destino)
    //    {
    //        if (destino == null) throw new ArgumentNullException("destino");
    //        if (origen == null) throw new ArgumentNullException("origen");
    //        if (origen.IsIdentity != destino.IsIdentity) return false;
    //        if (origen.IsIdentityForReplication != destino.IsIdentityForReplication) return false;
    //        if (origen.IdentityIncrement != destino.IdentityIncrement) return false;
    //        return origen.IdentitySeed == destino.IdentitySeed;
    //    }

    //    public static Boolean CompareRule(Column origen, Column destino)
    //    {
    //        if (destino == null) throw new ArgumentNullException("destino");
    //        if (origen == null) throw new ArgumentNullException("origen");
    //        if ((origen.Rule.Name != null) && (destino.Rule.Name == null)) return false;
    //        if ((origen.Rule.Name == null) && (destino.Rule.Name != null)) return false;
    //        if (origen.Rule.Name != null)
    //            if (!origen.Rule.Name.Equals(destino.Rule.Name)) return false;
    //        return true;
    //    }

    //    /// <summary>
    //    /// Compara dos campos y devuelve true si son iguales, caso contrario, devuelve false.
    //    /// </summary>
    //    public static Boolean Compare(Column origen, Column destino)
    //    {
    //        if (destino == null) throw new ArgumentNullException("destino");
    //        if (origen == null) throw new ArgumentNullException("origen");
    //        if (!origen.ComputedFormula.Equals(destino.ComputedFormula)) return false;
    //        if (origen.IsComputed != destino.IsComputed) return false;
    //        //if (origen.Position != destino.Position) return false;
    //        if (!origen.IsComputed)
    //        {
    //            if (origen.IsXmlDocument != destino.IsXmlDocument) return false;
    //            if ((origen.XmlSchema == null) && (destino.XmlSchema != null)) return false;
    //            if (origen.XmlSchema != null)
    //                if (!origen.XmlSchema.Equals(destino.XmlSchema)) return false;
    //            if (origen.IsNullable != destino.IsNullable) return false;
    //            if (origen.IsFileStream != destino.IsFileStream) return false;
    //            if (origen.IsSparse != destino.IsSparse) return false;
    //            if (!origen.Collation.Equals(destino.Collation)) return false;
    //            if (!origen.Type.Equals(destino.Type, StringComparison.CurrentCultureIgnoreCase)) return false;
    //            //Si el tipo de campo es custom, no compara size del campo.
    //            if (!origen.IsUserDefinedType)
    //            {
    //                if (origen.Precision != destino.Precision) return false;
    //                if (origen.Scale != destino.Scale) return false;
    //                //Si el tamaño de un campo Text cambia, entonces por la opcion TextInRowLimit.
    //                if ((origen.Size != destino.Size) && (origen.Type.Equals(destino.Type, StringComparison.CurrentCultureIgnoreCase)) && (!origen.Type.Equals("text", StringComparison.CurrentCultureIgnoreCase))) return false;
    //            }

    //        }
    //        else
    //        {
    //            if (origen.IsPersisted != destino.IsPersisted) return false;
    //        }
    //        return CompareIdentity(origen, destino) && CompareRule(origen, destino);
    //    }

    //    public int CompareTo(Column other)
    //    {
    //        return Id.CompareTo(other.Id);
    //    }
    //}
}