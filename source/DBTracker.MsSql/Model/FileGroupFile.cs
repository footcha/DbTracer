using System;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class FileGroupFile : MsSqlSchemaBase
    {
        public FileGroupFile()
            : base(ObjectType1.File)
        {
        }

        public override ISchema Clone()
        {
            return new FileGroupFile
            {
                Growth = Growth,
                Id = Id,
                IsPercentGrowth = IsPercentGrowth,
                IsSparse = IsSparse,
                MaxSize = MaxSize,
                Name = Name,
                PhysicalName = PhysicalName,
                Size = Size,
                Type = Type
            };
        }

        public int Size { get; set; }

        public Boolean IsSparse { get; set; }

        public Boolean IsPercentGrowth { get; set; }

        public int Growth { get; set; }

        public int MaxSize { get; set; }

        public string PhysicalName { get; set; }

        public int Type { get; set; }

        /// <summary>
        /// Compara dos triggers y devuelve true si son iguales, caso contrario, devuelve false.
        /// </summary>
        public static Boolean Compare(FileGroupFile origen, FileGroupFile destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (origen.Growth != destino.Growth) return false;
            if (origen.IsPercentGrowth != destino.IsPercentGrowth) return false;
            if (origen.IsSparse != destino.IsSparse) return false;
            return origen.MaxSize == destino.MaxSize && origen.PhysicalName.Equals(destino.PhysicalName);
        }
    }
}