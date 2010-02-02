using System;
using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class Synonym : MsSqlSchemaBase
    {
        public Synonym()
            : base(ObjectType1.Synonym)
        {
        }

        public override ISchema Clone()
        {
            return new Synonym
            {
                Id = Id,
                Name = Name,
                Owner = Owner,
                Value = Value
            };
        }

        public string Value { get; set; }

        /// <summary>
        /// Compara dos Synonyms y devuelve true si son iguales, caso contrario, devuelve false.
        /// </summary>
        public static Boolean Compare(Synonym origen, Synonym destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            return origen.Value.Equals(destino.Value);
        }
    }
}