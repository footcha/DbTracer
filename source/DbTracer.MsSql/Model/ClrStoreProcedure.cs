using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class ClrStoreProcedure : ClrCode
    {
        public ClrStoreProcedure()
            : base(ObjectType1.ClrStoreProcedure, ScripActionType.AddStoreProcedure, ScripActionType.DropStoreProcedure)
        {
            Parameters = new List<Parameter>();
        }

        public List<Parameter> Parameters { get; set; }
    }
}