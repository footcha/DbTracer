namespace DbTracker.MsSql
{
    public enum SqlObjectType
    {
        Undefined = 0,
        AggregateFunction,
        CheckConstraint,
        DefaultConstraint,
        ForeignKeyConstraint,
        PrimarykeyConstraint,
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
        SqlDmLTrigger,
        SqlInlinedTableValuedFunction,
        SqlTableValuedFunction,
        TableUserDefined,
        UniqueConstraint,
        View,
        ExtendedStoredProcedure,
        InternalTable,
    }
}