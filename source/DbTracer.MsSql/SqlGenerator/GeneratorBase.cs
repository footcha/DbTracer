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

        public abstract string ObjectNameKeyWord { get; }

        public abstract string ToCreateSql();

        public virtual string ToDropSql()
        {
            return ToDropSqlObjectNameKeyWord();
        }

        protected virtual string ToDropSqlObjectNameKeyWord()
        {
            return string.Format("DROP {0} {1}",
                ObjectNameKeyWord, FullNameBuilder.BuildName(SourceObject));
        }
    }
}