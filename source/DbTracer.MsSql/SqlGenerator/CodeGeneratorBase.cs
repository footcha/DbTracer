using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public abstract class CodeGeneratorBase<T> : GeneratorBase<T>
        where T : ICode
    {
        protected CodeGeneratorBase(T sourceObject)
            : base(sourceObject) { }

        public override string ToCreateSql()
        {
            return SourceObject.Definition ?? "";
        }
    }
}