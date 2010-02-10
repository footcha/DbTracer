using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class View : SqlObject, ICode
    {
        public virtual string Definition { get; set; }

        public virtual IDictionary<int, Trigger> Triggers { get; set; }
    }
}