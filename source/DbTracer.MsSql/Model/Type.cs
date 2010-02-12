namespace DbTracer.MsSql.Model
{
    public class Type : ISqlObject
    {
        public virtual int Id { get; set; }

        public virtual Type SystemType { get; set; }

        public virtual string Name { get; set; }

        public virtual Schema Schema { get; set; }

        public virtual int MaxLength { get; set; }

        public virtual int Precision { get; set; }

        public virtual int Scale { get; set; }

        public virtual string Collation { get; set; }

        public virtual bool IsNullable { get; set; }

        public virtual bool IsUserDefined { get; set; }

        public virtual bool IsAssemblyType { get; set; }

        public virtual SqlObject Default { get; set; } // sys.objects.type='D'

        public virtual SqlObject Rule { get; set; } // sys.objects.type='R'

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
            return ModelUtils.ToStringWithId(this);
        }
    }
}