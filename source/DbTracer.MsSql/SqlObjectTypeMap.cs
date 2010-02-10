using System;
using System.Collections.Generic;
using System.Data;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace DbTracer.MsSql
{
    public class SqlObjectTypeMap : IUserType
    {
        private static readonly IDictionary<string, SqlObjectType> dict;
        private static readonly Dictionary<SqlObjectType, string> dict2;

        static SqlObjectTypeMap()
        {
            dict = new Dictionary<string, SqlObjectType>();
            dict["AF"] = SqlObjectType.AggregateFunction;
            dict["C"] = SqlObjectType.CheckConstraint;
            dict["D"] = SqlObjectType.DefaultConstraint;
            dict["F"] = SqlObjectType.ForeignKeyConstraint;
            dict["PK"] = SqlObjectType.PrimaryKeyConstraint;
            dict["P"] = SqlObjectType.SqlStoredProcedure;
            dict["PC"] = SqlObjectType.AssemblyClrStoredProcedure;
            dict["FN"] = SqlObjectType.SqlScalarFunction;
            dict["FS"] = SqlObjectType.AssemblyClrScalarFunction;
            dict["FT"] = SqlObjectType.AssemblyClrTableValuedFunction;
            dict["R"] = SqlObjectType.RuleOldStyleStandalone;
            dict["RF"] = SqlObjectType.ReplicationFilterProcedure;
            dict["SN"] = SqlObjectType.Synonym;
            dict["SQ"] = SqlObjectType.ServiceQueue;
            dict["TA"] = SqlObjectType.AssemblyClrDmlTrigger;
            dict["TR"] = SqlObjectType.SqlDmlTrigger;
            dict["IF"] = SqlObjectType.SqlInlinedTableValuedFunction;
            dict["TF"] = SqlObjectType.SqlTableValuedFunction;
            dict["U"] = SqlObjectType.TableUserDefined;
            dict["UQ"] = SqlObjectType.UniqueConstraint;
            dict["V"] = SqlObjectType.View;
            dict["X"] = SqlObjectType.ExtendedStoredProcedure;
            dict["IT"] = SqlObjectType.InternalTable;
            dict["S"] = SqlObjectType.SystemTable;

            dict2 = new Dictionary<SqlObjectType, string>();
            foreach (var item in dict)
            {
                dict2[item.Value] = item.Key;
            }
        }

        public static string GetCode(SqlObjectType type)
        {
            return dict2[type];
        }

        public new bool Equals(object x, object y)
        {
            return Equals(x, y);
        }

        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var value = (string)NHibernateUtil.String.NullSafeGet(rs, names[0]);

            return dict[value.Trim()];
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            NHibernateUtil.String.NullSafeSet(cmd, dict2[(SqlObjectType)value], index);
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Replace(object original, object target, object owner)
        {
            throw new NotSupportedException();
        }

        public object Assemble(object cached, object owner)
        {
            throw new NotSupportedException();
        }

        public object Disassemble(object value)
        {
            throw new NotSupportedException();
        }

        public SqlType[] SqlTypes
        {
            get { return new[] { new SqlType(DbType.String) }; }
        }

        public Type ReturnedType
        {
            get { return typeof(SqlObjectType); }
        }

        public bool IsMutable
        {
            get { return false; }
        }
    }
}