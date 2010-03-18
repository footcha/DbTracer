using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public class TriggerGenerator : CodeGeneratorBase<Trigger>
    {
        public TriggerGenerator(Trigger sourceObject)
            : base(sourceObject) { }

        public override string ObjectNameKeyWord
        {
            get { return "TRIGGER"; }
        }

        public override string ToDropSql()
        {
            var sql = base.ToDropSql();
            if (SourceObject.ParentObject == null)
            {
                sql += " ON DATABASE";
            }
            return sql;
        }
    }
}