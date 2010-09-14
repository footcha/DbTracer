using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.Test.TestingUtils
{
    public class TableBuilder
    {
        public Table Build()
        {
            return new Table
            {
                Name = "test_table",
                Type = SqlObjectType.TableUserDefined
            };
        }
    }
}