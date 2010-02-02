using System;

namespace DbTracer.MsSql.Model
{
    public class ConstraintColumn : MsSqlSchemaBase, IComparable<ConstraintColumn>
    {
        public ConstraintColumn()
            : base(ObjectType1.ConstraintColumn)
        { }

        public new ConstraintColumn Clone()
        {
            return new ConstraintColumn
            {
                ColumnRelationalName = ColumnRelationalName,
                ColumnRelationalId = ColumnRelationalId,
                Name = Name,
                IsIncluded = IsIncluded,
                Order = Order,
                KeyOrder = KeyOrder,
                Id = Id,
                DataTypeId = DataTypeId,
                ColumnRelationalDataTypeId = ColumnRelationalDataTypeId
            };
        }

        public int DataTypeId { get; set; }

        public int ColumnRelationalDataTypeId { get; set; }

        public int ColumnRelationalId { get; set; }

        /// <summary>
        /// Gets or sets the column key order in the index.
        /// </summary>
        /// <value>The key order.</value>
        public int KeyOrder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this column is included in the index leaf page.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this column is included; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsIncluded { get; set; }

        /// <summary>
        /// Orden de la columna (Ascendente o Descendente). Se usa solo en Primary Keys.
        /// </summary>
        public Boolean Order { get; set; }

        public string ColumnRelationalName { get; set; }

        public static Boolean Compare(ConstraintColumn origen, ConstraintColumn destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if ((origen.ColumnRelationalName == null) && (destino.ColumnRelationalName != null)) return false;
            if (origen.ColumnRelationalName != null)
            {
                if (!origen.ColumnRelationalName.Equals(destino.ColumnRelationalName, StringComparison.CurrentCultureIgnoreCase)) return false;
            }
            if (origen.IsIncluded != destino.IsIncluded) return false;
            if (origen.Order != destino.Order) return false;
            if (origen.KeyOrder != destino.KeyOrder) return false;
            return true;
        }

        public int CompareTo(ConstraintColumn other)
        {
            return KeyOrder.CompareTo(other.KeyOrder);
        }
    }
}