using System;
using System.Text.RegularExpressions;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test
{
    public static class TestUtils
    {
        private static readonly Regex whiteCharactersRegex = new Regex(@"[\[\]\s]+");

        public static void TestSqlObjectDefinition(string expectedDefinition, string testedDefinition)
        {
            Assert.IsNotNull(testedDefinition, "Parameter [testedDefinition] cannot be null.");
            Assert.AreEqual(
                whiteCharactersRegex.Replace(expectedDefinition, ""),
                whiteCharactersRegex.Replace(testedDefinition, ""));
        }

        public static void TestProperty<T>(string propertyName, object expectedValue, T testedObject)
        {
            Assert.IsNotNull(testedObject, "Object cannot be null");
            var propInfo = typeof(T).GetProperty(propertyName);
            if (propInfo == null)
            {
                Assert.Fail("[{0}] does not contain property [{1}].",
                    typeof(T).FullName, propertyName);
            }
            else
            {
                var testedValue = propInfo.GetValue(testedObject, null);
                Assert.AreEqual(expectedValue, testedValue);
            }
        }

        public static void TestPropertyIsInRange<T, T1>(
            string propertyName, T1 expectedMinValue, T1 expectedMaxValue, T testedObject)
            where T1 : IComparable
        {
            Assert.IsNotNull(testedObject, "Object cannot be null");
            var propInfo = typeof(T).GetProperty(propertyName);
            if (propInfo == null)
            {
                Assert.Fail("[{0}] does not contain property [{1}].",
                    typeof(T).FullName, propertyName);
                return;
            }
            var x = propInfo.GetValue(testedObject, null);
            var testedValue = x as IComparable;

            if (x == null)
            {
                Assert.Fail("Property [{0}] is not of type IComparable.", propertyName);
                return;
            }

            Assert.Between(testedValue, expectedMinValue, expectedMaxValue);
        }
    }
}