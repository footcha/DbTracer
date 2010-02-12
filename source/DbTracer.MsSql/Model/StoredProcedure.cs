namespace DbTracer.MsSql.Model
{
    public class StoredProcedure : SqlObject, ICode
    {
        public virtual string Definition { get; set; }
        public virtual bool IsAutoExecuted { get; set; }
        public virtual bool IsExecutionReplicated { get; set; }
        public virtual bool IsReplSerializableOnly { get; set; }
        public virtual bool SkipsReplConstraints { get; set; }
    }
}