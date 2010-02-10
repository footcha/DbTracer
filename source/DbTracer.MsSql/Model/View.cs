using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class View : SqlObject, ICode
    {
        public View()
        {
            Init();
        }

        private void Init()
        {
            Triggers = new List<Trigger>();
        }

        public virtual string Definition { get; set; }

        public virtual ICollection<Trigger> Triggers { get; set; }

        public virtual bool IsReplicated { get; set; }

        public virtual bool HasReplicationFilter { get; set; }

        public virtual bool HasOpaqueMetadata { get; set; }

        public virtual bool HasUncheckedAssemblyData { get; set; }

        public virtual bool WithCheckOption { get; set; }

        public virtual bool IsDateCorrelationView { get; set; }
    }
}