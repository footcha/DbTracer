namespace DbTracker.MsSql.Model
{
    public interface ICode : ISqlObject //: ISchema
    {
        string Definition { get; }
        // SqlScriptList Rebuild();
        //List<string> DependenciesIn { get; set; }
        //List<string> DependenciesOut { get; set; }
        //bool IsSchemaBinding { get; set; }
    }
}