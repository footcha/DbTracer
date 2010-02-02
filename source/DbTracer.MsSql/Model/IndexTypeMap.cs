using System;
using System.Data;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace DbTracer.MsSql.Model
{
    public class IndexTypeMap : IUserType
    {
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
            var value = (int)NHibernateUtil.Int32.NullSafeGet(rs, names[0]);

            switch (value)
            {
                case 0: return IndexType.Heap;
                case 1: return IndexType.Clustered;
                case 2: return IndexType.Nonclustered;
                default: return IndexType.Undefined;
            }
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            throw new NotSupportedException();
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
            get { return new[] { new SqlType(DbType.Int32) }; }
        }

        public System.Type ReturnedType
        {
            get { return typeof(IndexType); }
        }

        public bool IsMutable
        {
            get { return false; }
        }
    }
}