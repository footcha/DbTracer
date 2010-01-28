namespace DbTracker.MsSql.Model
{
    public interface ISqlObject
    {
        int Id { get; }
        string Name { get; }
        //SqlObjectType Type { get; }
    }
}