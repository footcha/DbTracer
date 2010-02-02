using System;
using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public abstract class MsSqlSchemaBase : SchemaBase
    {
        protected MsSqlSchemaBase(ObjectType1 objectType1)
            : base(objectType1)
        {
            ExtendedProperties = new SchemaList<ExtendedProperty, SchemaBase>();
        }

        protected MsSqlSchemaBase(ISchema schema, ObjectType1 index)
            : base(ObjectType1.Undefined)
        {
            throw new NotSupportedException();
        }

        public virtual SchemaList<ExtendedProperty, SchemaBase> ExtendedProperties { get; private set; }
    }
}