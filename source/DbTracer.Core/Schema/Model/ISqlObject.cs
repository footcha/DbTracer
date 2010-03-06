namespace DbTracer.Core.Schema.Model
{
    public interface ISqlObject
    {
        int Id { get; }
        string Name { get; }
    }
}