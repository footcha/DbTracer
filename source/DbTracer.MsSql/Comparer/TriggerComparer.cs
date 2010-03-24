using DbTracer.Core.Schema.Comparer;
using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.Comparer
{
    public class TriggerComparer : ComparerBase<Trigger>
    {
        public TriggerComparer(Trigger source)
            : base(source) { }

        public override ICompareResult<Trigger> Compare(Trigger destinationObject)
        {
            return new TriggerCompareResult(Source, destinationObject);
        }
    }
}