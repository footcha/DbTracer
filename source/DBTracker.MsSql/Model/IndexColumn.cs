using System;

namespace DbTracker.MsSql.Model
{
    public class IndexColumn : MsSqlSchemaBase, IComparable<IndexColumn>
    {
        public IndexColumn()
            : base(ObjectType1.IndexColumn)
        {
        }

        public new IndexColumn Clone()
        {
            return new IndexColumn
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

        public static Boolean Compare(IndexColumn origen, IndexColumn destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (origen.IsIncluded != destino.IsIncluded) return false;
            if (origen.Order != destino.Order) return false;
            if (origen.KeyOrder != destino.KeyOrder) return false;
            return true;
        }

        public int CompareTo(IndexColumn other)
        {
            return other.IsIncluded == IsIncluded
                ? KeyOrder.CompareTo(other.KeyOrder)
                : other.IsIncluded.CompareTo(IsIncluded);
        }
    }
}