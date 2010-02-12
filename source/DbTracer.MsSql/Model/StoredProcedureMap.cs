using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class StoredProcedureMap : SubclassMap<StoredProcedure>
    {
        protected StoredProcedureMap()
        {
            DiscriminatorValue(SqlObjectTypeMap.GetCode(SqlObjectType.SqlStoredProcedure));
            SqlClassMap<SqlObject>.ConfigureCode(this);
            Join("sys.procedures", join =>
            {
                join.KeyColumn("object_id");
                join.Map(obj => obj.IsAutoExecuted, "is_auto_executed");
                join.Map(obj => obj.IsReplSerializableOnly, "is_repl_serializable_only");
                join.Map(obj => obj.IsExecutionReplicated, "is_execution_replicated");
                join.Map(obj => obj.SkipsReplConstraints, "skips_repl_constraints");
            });
        }
    }
}