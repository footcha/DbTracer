using System;
using DbTracer.MsSql.Model;
using DbTracer.MsSql.SqlGenerator;
using DbTracer.MsSql.Test.TestingUtils;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    [TestFixture]
    public class TriggerGeneratorTest : CodeGeneratorBaseTest<TriggerGenerator, Trigger>
    {
        private TriggerGenerator testedGenerator;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            TestedObject = new TriggerBuilder().Build();
            testedGenerator = BuildGenerator(new TriggerGenerator(TestedObject));
        }

        //[TestSuite]
        //public TestSuite Suite()
        //{
        //    var suite = new TestSuite("test test test"){};
        //    suite.Add(suite.Add( "Test1", new TestDelegate(x=> Test(x) ), "hello" );

        //    return suite;
        //}

        //public void Test(object testContext)
        //{
        //    Console.WriteLine("Test");
        //    Assert.AreEqual("hello", testContext);
        //}


        [Test]
        public void CreateSql()
        {
            const string expectedSql = "CREATE TRIGGER [dbo].[test_trigger]     ON  [dbo].[test_table]     AFTER INSERT,DELETE  AS   BEGIN   SET NOCOUNT ON;  END";
            SqlAssert.AreSqlEqual(expectedSql, testedGenerator.ToCreateSql());
        }

        [Test]
        public void DropSql()
        {
            const string expectedSql = "DROP TRIGGER [test_trigger]";
            SqlAssert.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
        }

        [Test]
        public void DropDdlTrigger()
        {
            TestedObject.ParentObject = null;
            const string expectedSql = "DROP TRIGGER [test_trigger] ON DATABASE";
            SqlAssert.AreSqlEqual(expectedSql, testedGenerator.ToDropSql());
        }
    }
}