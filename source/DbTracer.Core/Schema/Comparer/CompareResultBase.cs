using System;
using DbTracer.Core.Schema.Model;
using DbTracer.Core.Schema.SqlGenerator;

namespace DbTracer.Core.Schema.Comparer
{
    public abstract class CompareResultBase<T> : ICompareResult<T>
        where T : class, ISqlObject
    {
        protected CompareResultBase(T source, T destination)
        {
            Source = source;
            Destination = destination;
        }
        public T Source { get; private set; }
        public T Destination { get; private set; }

        public virtual bool IsDifferent
        {
            get { return Source.Equals(Destination); }
        }

        public virtual string ToSqlSourceToDestination()
        {
            return CreateSql(Source, Destination);
        }

        public virtual string ToSqlDestinationToSource()
        {
            return CreateSql(Destination, Source);
        }

        public Func<T, IGenerator<T>> GeneratorBuilder;

        private string CreateSql(T source, T destination)
        {
            if (source == null) return GeneratorBuilder(destination).ToDropSql();
            return destination == null
                ? GeneratorBuilder(source).ToCreateSql()
                : CreateAlterScript(source);
        }

        protected abstract string CreateAlterScript(T source);
    }
}