using System;
using System.Collections.Generic;

namespace DbTracker.MsSql.Model
{
    public class PartitionFunction : MsSqlSchemaBase
    {
        private const int isString = 0;
        private const int isUnique = 1;
        private const int isDate = 2;
        private const int isNumeric = 3;

        public PartitionFunction()
            : base(ObjectType1.PartitionFunction)
        {
            Values = new List<string>();
        }

        public new PartitionFunction Clone()
        {
            var item = new PartitionFunction
            {
                Id = Id,
                IsBoundaryRight = IsBoundaryRight,
                Name = Name,
                Precision = Precision,
                Scale = Scale,
                Size = Size,
                Type = Type
            };
            Values.ForEach(value => item.Values.Add(value));
            return item;
        }

        public List<string> Values { get; set; }

        public PartitionFunction Old { get; set; }

        public int Precision { get; set; }

        public int Scale { get; set; }

        public int Size { get; set; }

        public bool IsBoundaryRight { get; set; }

        public string Type { get; set; }

        public static Boolean Compare(PartitionFunction origen, PartitionFunction destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (!origen.Type.Equals(destino.Type)) return false;
            if (origen.Size != destino.Size) return false;
            if (origen.Precision != destino.Precision) return false;
            if (origen.Scale != destino.Scale) return false;
            return origen.IsBoundaryRight == destino.IsBoundaryRight;
        }

        //public static Boolean CompareValues(PartitionFunction origen, PartitionFunction destino)
        //{
        //    if (destino == null) throw new ArgumentNullException("destino");
        //    if (origen == null) throw new ArgumentNullException("origen");
        //    if (origen.Values.Count != destino.Values.Count) return false;
        //    if (origen.Values.Except(destino.Values).ToList().Count != 0) return false;
        //    return true;
        //}
    }
}