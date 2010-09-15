using System;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Model
{
    public abstract class SqlObjectTest<T> : ATestBase
        where T : SqlObject
    {
        protected abstract T ExpectedObject { get; }
        protected abstract T TestedObject { get; }

        [Test,
         Row("Name"),
         Row("PrincipalId"),
         Row("IsMsShipped"),
         Row("IsPublished"),
         Row("IsSchemaPublished"),
         Row("Schema"),
         Row("ParentObject"),
         Row("Type"),
        ]
        public void CheckProperty(string propertyName)
        {
            var expectedValue = GetValue(propertyName, ExpectedObject);
            TestUtils.TestProperty(propertyName, expectedValue, TestedObject);
        }

        [Test,
        Row("CreateDate"),
        Row("ModifyDate")]
        public void CheckDate(string propertyName)
        {
            var testedValue = GetValue(propertyName, TestedObject);
            var testedDate = (DateTime)testedValue;
            Assert.Between(testedDate, new DateTime(2010, 1, 1), DateTime.Now);
        }

        protected T CreateObject(DateTime createDate, bool isMsShipped, bool isPublished, bool isSchemaPublished,
            DateTime modifyDate, string name, SqlObject parentObject, int principalId, Schema schema,
            SqlObjectType type)
        {
            var obj = typeof(T).GetConstructor(new System.Type[] { }).Invoke(new object[] { });
            var x = (T)obj;
            x.CreateDate = DateTime.Now;
            x.IsMsShipped = isMsShipped;
            x.IsPublished = isPublished;
            x.IsSchemaPublished = isSchemaPublished;
            x.ModifyDate = modifyDate;
            x.Name = name;
            x.ParentObject = parentObject;
            x.PrincipalId = principalId;
            x.Schema = schema;
            x.Type = type;

            return x;
        }

        protected static object GetValue(string propertyName, object obj)
        {
            return typeof(T).GetProperty(propertyName).GetValue(obj, null);
        }
    }
}