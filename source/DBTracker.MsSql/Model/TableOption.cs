using System;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class TableOption : MsSqlSchemaBase
    {
        public TableOption(string name, string value)
            : this()
        {
            Name = name;
            Value = value;
        }

        public TableOption()
            : base(ObjectType1.TableOption)
        { }

        /// <summary>
        /// Clona el objeto en una nueva instancia.
        /// </summary>
        public override ISchema Clone()
        {
            var option = new TableOption(Name, Value)
                             {
                                 Status = Status
                             };
            return option;
        }

        public string Value { get; set; }

        /// <summary>
        /// Compara dos indices y devuelve true si son iguales, caso contrario, devuelve false.
        /// </summary>
        public static Boolean Compare(TableOption origen, TableOption destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (!destino.Value.Equals(origen.Value)) return false;
            return true;
        }
    }
}