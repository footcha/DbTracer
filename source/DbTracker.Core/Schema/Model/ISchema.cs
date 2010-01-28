using System;
using DbTracker.MsSql;

namespace DbTracker.Core.Schema.Model
{
    public interface ISchema
    {
        ISchema Clone();
        int DependenciesCount { get; }
        string FullName { get; }
        int Id { get; set; }
        bool HasState(ObjectStatus statusFind);
        string Name { get; set; }
        string Owner { get; set; }
        ISchema Parent { get; set; }
        ObjectStatus Status { get; set; }
        Boolean IsSystem { get; set; }
        Enum ObjectType { get; set; }
        int CompareFullNameTo(string name, string myName);
        Boolean IsCodeType { get; }
        IDatabase Database { get; }
    }
}