namespace DbTracker.MsSql.Test.Model
{
    public abstract class ASqlObjectTestBase : ATestBase
    {
        public abstract void LoadTest(string propertyName, object expectedValue);
        
        //public abstract void TypeTest();
    }
}