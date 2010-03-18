using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public class FunctionGenerator : CodeGeneratorBase<Function>
    {
        public FunctionGenerator(Function sourceObject) 
            : base(sourceObject) {}

        public override string ObjectNameKeyWord
        {
            get { return "FUNCTION"; }
        }
    }
}