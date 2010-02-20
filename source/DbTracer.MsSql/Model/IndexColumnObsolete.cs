using System;

namespace DbTracer.MsSql.Model
{
    public class IndexColumnObsolete : MsSqlSchemaBase, IComparable<IndexColumnObsolete>
    {
        public IndexColumnObsolete()
            : base(ObjectType1.IndexColumn)
        {
        }

        public new IndexColumnObsolete Clone()
        {
            return new IndexColumnObsolete
            {
                Id = Id,
                IsIncluded = IsIncluded,
                Name = Name,
                Order = Order,
                Status = Status,
                KeyOrder = KeyOrder,
                DataTypeId = DataTypeId
            };
        }

        public int DataTypeId { get; set; }

        public int KeyOrder { get; set; }

        public Boolean IsIncluded { get; set; }

        public Boolean Order { get; set; }

        public static Boolean Compare(IndexColumnObsolete origen, IndexColumnObsolete destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (origen.IsIncluded != destino.IsIncluded) return false;
            if (origen.Order != destino.Order) return false;
            if (origen.KeyOrder != destino.KeyOrder) return false;
            return true;
        }

        public int CompareTo(IndexColumnObsolete other)
        {
            return other.IsIncluded == IsIncluded
                ? KeyOrder.CompareTo(other.KeyOrder)
                : other.IsIncluded.CompareTo(IsIncluded);
        }
    }
}