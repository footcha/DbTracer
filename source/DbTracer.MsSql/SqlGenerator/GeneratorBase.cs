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
            KeywordEncoder = KeyWordEncoder.Instance;
            FullNameBuilder = DefaultFullNameBuilder.Instance;
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

        private class KeyWordEncoder : IKeywordEncoder
        {
            public static KeyWordEncoder Instance { get; private set; }

            static KeyWordEncoder()
            {
                Instance = new KeyWordEncoder();
            }

            private KeyWordEncoder() { }

            public string Encode(string text)
            {
                return text;
            }
        }

        private class DefaultFullNameBuilder : IFullNameBuilder
        {
            public static DefaultFullNameBuilder Instance { get; private set; }

            static DefaultFullNameBuilder()
            {
                Instance = new DefaultFullNameBuilder();
            }

            private DefaultFullNameBuilder() { }

            public string BuildName(ISqlObject sqlObject)
            {
                return sqlObject.Name;
            }
        }
    }
}