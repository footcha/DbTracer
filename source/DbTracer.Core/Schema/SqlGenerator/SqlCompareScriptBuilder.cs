using DbTracer.Core.Schema.Model;

namespace DbTracer.Core.Schema.SqlGenerator
{
    /// <summary>
    /// Converts SQL object to its SQL representation.
    /// </summary>
    /// <see cref="ToSql"/>
    /// <typeparam name="T">Sql object fro which this builder is dedicated.</typeparam>
    public abstract class SqlCompareScriptBuilder<T>
        where T : class, ISqlObject
    {
        protected readonly T Source;
        protected readonly T Destination;
        protected IGenerator<T> SourceGenerator;
        protected IGenerator<T> DestinationGenerator;

        protected SqlCompareScriptBuilder(T source, T destination)
        {
            Source = source;
            Destination = destination;
        }

        protected abstract string CreateAlterScriptFromSource();

        /// <returns>
        /// "create SQL" if <see cref="Source"/> exists and <see cref="Destination"/> does not exist,
        /// "drop SQL" if <see cref="Source"/> does not exist and <see cref="Destination"/> exists, 
        /// "ALTER SQL" both <see cref="Source"/> and <see cref="Destination"/> exist.
        /// </returns>
        public virtual string ToSql()
        {
            if (Source == null) return DestinationGenerator.ToDropSql();
            return Destination == null
                ? SourceGenerator.ToCreateSql()
                : CreateAlterScriptFromSource();
        }
    }
}