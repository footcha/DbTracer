using System;

namespace DbTracer.MsSql.Model
{
    public abstract class SqlObject : ISqlObject
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Schema Schema { get; set; }

        public virtual int PrincipalId { get; set; }

        public virtual SqlObject ParentObject { get; set; }

        public virtual SqlObjectType Type { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime ModifyDate { get; set; }

        public virtual bool IsMsShipped { get; set; }

        public virtual bool IsPublished { get; set; }

        public virtual bool IsSchemaPublished { get; set; }

        public override string ToString()
        {
            return ModelUtils.ToStringWithId(this);
        }

        public override bool Equals(object that)
        {
            return ModelUtils.Equals(this, that);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}