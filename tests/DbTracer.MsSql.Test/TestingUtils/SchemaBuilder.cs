using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.Test.TestingUtils
{
    public class SchemaBuilder
    {
        public Schema Build()
        {
            return new Schema
                   {
                       Id = -1,
                       Name = "test_schema"
                   };
        }
    }
}