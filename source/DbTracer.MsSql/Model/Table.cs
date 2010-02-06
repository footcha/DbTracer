using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class Table : AObjectBase
    {
        public virtual int LobDataSpaceId { get; set; } // TODO foreign keys to LOB

        // public virtual int max_column_id_used{ get; set; } // It is not necessary in object model

        public virtual bool LockOnBulkLoad { get; set; }

        public virtual bool UsesAnsiNulls { get; set; }

        public virtual bool IsReplicated { get; set; }

        public virtual bool HasReplicationFilter { get; set; }

        public virtual bool IsMergePublished { get; set; }

        public virtual bool IsSyncTranSubscribed { get; set; }

        public virtual bool HasUncheckedAssemblyData { get; set; }

        public virtual int TextInRowLimit { get; set; }

        public virtual bool LargeValueTypesOutOfRow { get; set; }

        public virtual ICollection<Index> Indexes { get; set; }

        public virtual IDictionary<int, Trigger> Triggers { get; set; }
        
        public virtual IDictionary<int, Column> Columns { get; set; } // TODO foreign keys to columns
    }
}