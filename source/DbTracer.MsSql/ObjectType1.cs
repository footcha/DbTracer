using DbTracer.Core;

namespace DbTracer.MsSql
{
    public enum ObjectType1
    {
        Undefined = 0,
        Table = 1,
        Column = 2,
        Trigger = 3,
        Constraint = 4,
        ConstraintColumn = 5,
        Index = 6,
        IndexColumn = 7,
        [Description("User Data Type1")]
        UserDataType = 8,
        [Description("Xml Schema")]
        XmlSchema = 9,
        View = 10,
        Function = 11,
        [Description("Store Procedure")]
        StoreProcedure = 12,
        TableOption = 13,
        Database = 14,
        Schema = 15,
        FileGroup = 16,
        File = 17,
        Default = 18,
        Rule = 19,
        Synonym = 20,
        Assembly = 21,
        User = 22,
        Role = 23,
        FullText = 24,
        AssemblyFile = 25,
        [Description("CLR Store Procedure")]
        ClrStoreProcedure = 26,
        [Description("CLR Trigger")]
        ClrTrigger = 27,
        [Description("CLR Function")]
        ClrFunction = 28,
        [Description("Extended Property")]
        ExtendedProperty = 30,
        Partition = 31,
        [Description("Partition Function")]
        PartitionFunction = 32,
        [Description("Partition Scheme")]
        PartitionScheme = 33,
        [Description("Table Type1")]
        TableType = 34,
        FullTextIndex = 35
    }
}