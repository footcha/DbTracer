using DbTracker.Core.Reflection;
using MbUnit.Framework;

namespace DbTracker.Core.Test.Reflection
{
    [TestFixture]
    public class SearchTest
    {
        [Test]
        public void GetPropertiesWithAttributeTest()
        {
            var result = Search.GetPropertiesWithAttribute<DescriptionAttribute>(typeof(TestStub));
            
            Assert.AreEqual(1, result.Count);
            var iter = result.GetEnumerator();
            iter.MoveNext();
            var item = iter.Current;
            Assert.AreEqual("Property2", item.Key.Name);
            Assert.AreEqual("Property second", item.Value.Name);
        }

        private class TestStub
        {
            public string Property1 { get; set; }

            [Description("Property second")]
            public string Property2 { get; set; }
            
            public string Property3 { get; set; }
        }
    }
}