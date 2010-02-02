using System.Collections.Generic;

namespace DbTracer.MsSql.Model
{
    public class ClrFunction : ClrCode
    {
        public ClrFunction()
            : base(ObjectType1.ClrFunction, ScripActionType.AddFunction, ScripActionType.DropFunction)
        {
            Parameters = new List<Parameter>();
            ReturnType = new Parameter();
        }

        public List<Parameter> Parameters { get; set; }

        public Parameter ReturnType { get; private set; }
    }
}