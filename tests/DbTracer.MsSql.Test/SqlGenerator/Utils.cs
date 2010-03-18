using System.Text.RegularExpressions;
using MbUnit.Framework;

namespace DbTracer.MsSql.Test.SqlGenerator
{
    public static class Utils
    {
        static readonly Regex regex = new Regex(@"\s+");

        public static void AreSqlEqual(string sql1, string sql2)
        {
            sql1 = regex.Replace(sql1, "");
            sql2 = regex.Replace(sql2, "");
            Assert.AreEqual(sql1, sql2);
        }
    }
}