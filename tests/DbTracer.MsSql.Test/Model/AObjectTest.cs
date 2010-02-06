using System;
using DbTracer.MsSql.Model;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.Model
{
    public abstract class AObjectTest<T> : ATestBase
        where T : AObjectBase
    {
        protected abstract T ExpectedObject { get; }
        protected abstract T TestedObject { get; }

        [RowTest,
         Row("Name"),
         Row("PrincipalId"),
         Row("IsMsShipped"),
         Row("IsPublished"),
         Row("IsSchemaPublished"),
         Row("Schema"),
         Row("ParentObject"),
         Row("Type"),
        ]
        public void BasicPropertyTest(string propertyName)
        {
            var expectedValue = GetValue(propertyName, ExpectedObject);
            TestUtils.TestProperty(propertyName, expectedValue, TestedObject);
        }

        [RowTest,
        Row("CreateDate"),
        Row("ModifyDate")]
        public void DateTest(string propertyName)
        {
            var testedValue = GetValue(propertyName, TestedObject);
            var testedDate = (DateTime)testedValue;
            Assert.Between(testedDate, new DateTime(2010, 1, 1), DateTime.Now);
        }

        protected T CreateObject(DateTime createDate, bool isMsShipped, bool isPublished, bool isSchemaPublished,
            DateTime modifyDate, string name, object parentObject, int principalId, Schema schema,
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

        private static object GetValue(string propertyName, object obj)
        {
            return typeof(T).GetProperty(propertyName).GetValue(obj, null);
        }
    }
}