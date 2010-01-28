namespace DbTracker.MsSql.Model
{
    public interface ICode : ISqlObject
    {
        string Definition { get; }
    }
}