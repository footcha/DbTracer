using System;
using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public class StoredProcedureGenerator : CodeGeneratorBase<StoredProcedure>
    {
        public StoredProcedureGenerator(StoredProcedure sourceObject)
            : base(sourceObject) { }

        public override string ObjectNameKeyWord
        {
            get { throw new NotImplementedException(); }
        }
    }
}