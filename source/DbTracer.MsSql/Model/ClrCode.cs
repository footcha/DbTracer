using System;

namespace DbTracer.MsSql.Model
{
    public abstract class ClrCode : Code
    {
        protected ClrCode(ObjectType1 type1, ScripActionType addAction, ScripActionType dropAction)
            : base(type1, addAction, dropAction)
        {
        }

        public string AssemblyMethod { get; set; }

        public string AssemblyExecuteAs { get; set; }

        public string AssemblyName { get; set; }

        public Boolean IsAssembly { get; set; }

        public string AssemblyClass { get; set; }

        public int AssemblyId { get; set; }

        public override Boolean IsCodeType
        {
            get { return true; }
        }
    }
}