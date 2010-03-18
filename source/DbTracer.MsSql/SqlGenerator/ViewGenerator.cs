using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.SqlGenerator
{
    public class ViewGenerator : CodeGeneratorBase<View>
    {
        public ViewGenerator(View sourceObject)
            : base(sourceObject) { }

        public override string ObjectNameKeyWord
        {
            get { return "VIEW"; }
        }
    }
}