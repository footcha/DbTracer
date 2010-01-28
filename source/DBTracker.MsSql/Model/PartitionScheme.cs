using System;
using System.Collections.Generic;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class PartitionScheme : MsSqlSchemaBase
    {
        public PartitionScheme(ISchema parent)
            : base(parent, MsSql.ObjectType1.PartitionFunction)
        {
            FileGroups = new List<string>();
        }

        public List<string> FileGroups { get; set; }

        public string PartitionFunction { get; set; }

        public static Boolean Compare(PartitionScheme origen, PartitionScheme destino)
        {
            if (destino == null) throw new ArgumentNullException("destino");
            if (origen == null) throw new ArgumentNullException("origen");
            if (!origen.PartitionFunction.Equals(destino.PartitionFunction)) return false;
            if (origen.FileGroups.Count != destino.FileGroups.Count) return false;
            for (var j = 0; j < origen.FileGroups.Count; j++)
            {
                if (origen.CompareFullNameTo(origen.FileGroups[j], destino.FileGroups[j]) != 0)
                    return false;
            }
            return true;
        }
    }
}