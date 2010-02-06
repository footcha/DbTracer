using System;

namespace DbTracer.MsSql.Model
{
    public abstract class AObjectBase : ISqlObject
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Schema Schema { get; set; }

        public virtual int PrincipalId { get; set; }

        public virtual object ParentObject { get; set; }

        public virtual SqlObjectType Type { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual DateTime ModifyDate { get; set; }

        public virtual bool IsMsShipped { get; set; }

        public virtual bool IsPublished { get; set; }

        public virtual bool IsSchemaPublished { get; set; }
    }
}