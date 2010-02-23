using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Model
{
    [TestFixture]
    public abstract class KeyConstraintMapTest<T> : SqlObjectTest<T>
        where T : KeyConstraint
    {
        protected abstract Index ExpectedIndex { get; }

        [Test]
        public void IsSystemNamedTest()
        {
            Assert.AreEqual(ExpectedObject.IsSystemNamed, TestedObject.IsSystemNamed);
        }

        [Test]
        public void IndexTest()
        {
            Assert.IsNotNull(TestedObject.Index);
            Assert.AreEqual(ExpectedIndex, TestedObject.Index);
            Assert.AreSame(ExpectedIndex, TestedObject.Index);
        }
    }
}