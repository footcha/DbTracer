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

        /// <summary>
        /// Returns SQL definition for creating <see cref="Source"/>
        /// if <see cref="Destination"/> does not exist.
        /// Returns SQL definition for creating <see cref="Destination"/>
        /// if <see cref="Source"/> does not exist.
        /// Returns SQL definition for altering <see cref="Source"/>.
        /// See <see cref="CreateAlterScript"/>
        /// </summary>
        public virtual string ToSqlSourceToDestination()
        {
            return CreateSql(Source, Destination);
        }

        /// <summary>
        /// Returns SQL definition for creating <see cref="Destination"/>
        /// if <see cref="Source"/> does not exist.
        /// Returns SQL definition for creating <see cref="Source"/>
        /// if <see cref="Destination"/> does not exist.
        /// Returns SQL definition for altering <see cref="Destination"/>.
        /// See <see cref="CreateAlterScript"/>
        /// </summary>
        public virtual string ToSqlDestinationToSource()
        {
            return CreateSql(Destination, Source);
        }

        private Func<T, IGenerator<T>> generatorBuilder =
            sourceObject =>
            {
                throw new NotSupportedException("Generator builder must be defined before it is used.");
            };
        public Func<T, IGenerator<T>> GeneratorBuilder
        {
            get { return generatorBuilder; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "GeneratorBuilder cannot be null.");
                }
                generatorBuilder = value;
            }
        }

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