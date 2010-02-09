namespace DbTracer.MsSql
{
    public enum SqlObjectType
    {
        Undefined = 0,
        AggregateFunction,
        CheckConstraint,
        DefaultConstraint,
        ForeignKeyConstraint,
        PrimaryKeyConstraint,
        SqlStoredProcedure,
        AssemblyClrStoredProcedure,
        SqlScalarFunction,
        AssemblyClrScalarFunction,
        AssemblyClrTableValuedFunction,
        RuleOldStyleStandalone,
        ReplicationFilterProcedure,
        Synonym,
        ServiceQueue,
        AssemblyClrDmlTrigger,
        SqlDmlTrigger,
        SqlInlinedTableValuedFunction,
        SqlTableValuedFunction,
        TableUserDefined,
        UniqueConstraint,
        View,
        ExtendedStoredProcedure,
        InternalTable,
        SystemTable
    }
}