namespace DbTracer.Core.Schema.SqlGenerator
{
    public interface IGenerator<T>
    {
        IKeywordEncoder KeywordEncoder { get; set; }
        IFullNameBuilder FullNameBuilder { get; set; }
        T SourceObject { get; }
        string ToCreateSql();
        string ToDropSql();
    }
}