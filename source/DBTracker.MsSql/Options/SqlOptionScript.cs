namespace DbTracker.MsSql.Options
{
    public class SqlOptionScript
    {
        public SqlOptionScript()
        {
            AlterObjectOnSchemaBinding = true;
        }

        public bool AlterObjectOnSchemaBinding { get; set; }
    }
}