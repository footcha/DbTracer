using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class Trigger : SqlObject, ICode, ISchemaMember
    {
        public virtual string Definition { get; set; }

        public virtual bool IsDisabled { get; set; }

        public virtual bool IsNotForReplication { get; set; }

        public virtual bool IsInsteadOfTrigger { get; set; }
    }
}