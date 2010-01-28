namespace DbTracker.MsSql.Model
{
    public class Type : ISqlObject
    {
        public virtual int Id { get; set; }

        public virtual Type SystemType { get; set; }

        public virtual string Name { get; set; }

        public virtual int Schema { get; set; } // TODO foreing key to schema type

        public virtual int MaxLength { get; set; }

        public virtual int Precision { get; set; }

        public virtual int Scale { get; set; }

        public virtual string Collation { get; set; }

        public virtual bool IsNullable { get; set; }

        public virtual bool IsUserDefined { get; set; }

        public virtual bool IsAssemblyType { get; set; }

        public virtual int DefaultObjectId { get; set; } // TODO foreing key to object type

        public virtual int RuleObjectId { get; set; } // TODO foreing key to rule type

#pragma warning disable 659
        public override bool Equals(object that)
#pragma warning restore 659
        {
            if (ReferenceEquals(null, that)) return false;
            if (ReferenceEquals(this, that)) return true;
            if (Id == 0) return false;
            var thatType = that as Type;
            if (thatType == null) return false;
            return thatType.Id == Id;
        }

        public override string ToString()
        {
            return string.Format("{0}, ID={1}", GetType().FullName, Id);
        }
    }
}