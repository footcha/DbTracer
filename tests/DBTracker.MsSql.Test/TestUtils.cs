using System.Text.RegularExpressions;
using MbUnit.Framework;

namespace DbTracker.MsSql.Test
{
    public static class TestUtils
    {
        private static readonly Regex whiteCharactersRegex = new Regex(@"\s+");

        public static void TestSqlObjectDefinition(string expectedDefinition, string testedDefinition)
        {
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
    }
}