namespace DbTracer.MsSql.Test.Model
{
    public abstract class ASqlObjectTestBase : ATestBase
    {
        public abstract void CheckProperty(string propertyName, object expectedValue);
    }

    //public abstract class AObjectTestBase : ASqlObjectTestBase
    //{
    //    [Test,
    //    Row("Name", "test_table"),
    //    ]
    //    public void LoadObjectTest()
    //    {
            
    //    }
    //}
}