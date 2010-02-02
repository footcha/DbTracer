using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class Table : ISqlObject
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual SqlObjectType Type { get; set; }
        
        public virtual ICollection<Index> Indexes { get; set; }

        public virtual IDictionary<int, Trigger> Triggers { get; set; }
    }
}