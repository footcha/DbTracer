using System;

namespace DbTracker.MsSql.Model
{
    public class IndexColumns : SchemaList<IndexColumn, SchemaBase>
    {
        /// <summary>
        /// Clona el objeto ColumnConstraints en una nueva instancia.
        /// </summary>
        public new IndexColumns Clone()
        {
            var columns = new IndexColumns();
            for (var index = 0; index < Count; index++)
            {
                columns.Add(this[index].Clone());
            }
            return columns;
        }

        /// <summary>
        /// Compara dos campos y devuelve true si son iguales, caso contrario, devuelve false.
        /// </summary>
        public static Boolean Compare(IndexColumns origen, IndexColumns destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (origen.Count != destino.Count) return false;
            for (int j = 0; j < origen.Count; j++)
            {
                var item = destino[origen[j].FullName];
                if (item == null)
                    return false;
                if (!IndexColumn.Compare(origen[j], item)) return false;
            }
            for (int j = 0; j < destino.Count; j++)
            {
                var item = origen[destino[j].FullName];
                if (item == null)
                    return false;
                if (!IndexColumn.Compare(destino[j], item)) return false;
            }
            return true;
        }
    }
}