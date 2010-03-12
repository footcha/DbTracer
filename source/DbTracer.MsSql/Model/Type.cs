using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class Type : ISqlObject, ISchemaMember, INullable
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
            return ModelUtils.Equals(this, that);
        }

        public override string ToString()
        {
            return ModelUtils.ToStringWithId(this);
        }

        /// <summary>
        /// Determines whether this object is inherited from specified system type
        /// </summary>
        /// <param name="types">system type names</param>
        /// <returns>true if this object matches one of given system types</returns>
        public virtual bool IsTypeOf(params string[] types)
        {
            foreach (var type in types)
            {
                if (SystemType.Name == type) return true;
            }
            return false;
        }

        ISchema ISchemaMember.Schema
        {
            get { return Schema; }
        }
    }
}