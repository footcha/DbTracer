namespace DbTracer.Core.Schema.Model
{
    public interface ISchemaList<TSchemaType, TParentType>
        where TSchemaType : ISchema
        where TParentType : ISchema
    {
        void Add(TSchemaType item);
        ISchemaList<TSchemaType, TParentType> Clone();
        bool Exists(string name);
        TSchemaType Find(int id);
        TSchemaType this[string name] { get; set; }
        TSchemaType this[int index] { get; set; }
        TParentType Parent { get; }
        int Count { get; }
    }
}