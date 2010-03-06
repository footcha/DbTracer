using DbTracer.Core.Schema.Model;
using DbTracer.Core.Schema.SqlGenerator;

namespace DbTracer.MsSql.SqlGenerator
{
    public abstract class GeneratorBase<T> : IGenerator<T>
        where T : ISqlObject
    {
        protected GeneratorBase(T sourceObject)
        {
            SourceObject = sourceObject;
        }

        public IKeywordEncoder KeywordEncoder { get; set; }

        public IFullNameBuilder FullNameBuilder { get; set; }

        public T SourceObject { get; private set; }

        public abstract string ToCreateSql();

        public abstract string ToDropSql();
    }
}