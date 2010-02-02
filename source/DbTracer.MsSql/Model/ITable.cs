using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public interface ITable<T> where T : SchemaBase
    {
        //Columns<T> Columns { get; }
        SchemaList<Constraint, T> Constraints { get; }
        //SchemaList<Index, T> Indexes { get; }
        ISchema Parent { get; set; }
        string Owner { get; set; }
    }
}