namespace DbTracer.MsSql.Test.Model
{
    public abstract class ASqlObjectTestBase : ATestBase
    {
        public abstract void LoadTest(string propertyName, object expectedValue);
    }

    //public abstract class AObjectTestBase : ASqlObjectTestBase
    //{
    //    [RowTest,
    //    Row("Name", "test_table"),
    //    ]
    //    public void LoadObjectTest()
    //    {
            
    //    }
    //}
}