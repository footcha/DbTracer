using System;

namespace DbTracker.MsSql.Model
{
    public class ConstraintColumns : SchemaList<ConstraintColumn, Constraint>
    {
        /// <summary>
        /// Clona el objeto ColumnConstraints en una nueva instancia.
        /// </summary>
        public new ConstraintColumns Clone()
        {
            var columns = new ConstraintColumns();
            for (var index = 0; index < Count; index++)
            {
                columns.Add(this[index].Clone());
            }
            return columns;
        }

        /// <summary>
        /// Compara dos campos y devuelve true si son iguales, caso contrario, devuelve false.
        /// </summary>
        public static Boolean Compare(ConstraintColumns origen, ConstraintColumns destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (origen.Count != destino.Count) return false;
            for (var j = 0; j < origen.Count; j++)
            {
                var item = destino[origen[j].FullName];
                if (item == null)
                    return false;
                if (!ConstraintColumn.Compare(origen[j], item)) return false;
            }
            for (var j = 0; j < destino.Count; j++)
            {
                var item = origen[destino[j].FullName];
                if (item == null)
                    return false;
                if (!ConstraintColumn.Compare(destino[j], item)) return false;
            }
            return true;
        }
    }
}