using System;
using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class ForeignKeyConstraint : KeyConstraint
    {
        public virtual SqlObject ReferencedObject { get; set; }
        public virtual bool IsDisabled { get; set; }
        public virtual bool IsNotForReplication { get; set; }
        public virtual bool IsNotTrusted { get; set; }
        public virtual int DeleteReferentialAction { get; set; }
        public virtual int UpdateReferentialAction { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
    }
}