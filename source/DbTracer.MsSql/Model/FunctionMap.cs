namespace DbTracer.MsSql.Model
{
    public class FunctionMap : SqlClassMap<Function>
    {
        protected override string TableName
        {
            get { return "sys.objects"; }
        }

        protected override void Configure()
        {
            ConfigureBasic(this);
            ConfigureCode(this);
        }
    }
}