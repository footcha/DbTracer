using DbTracer.MsSql.Model;

namespace DbTracer.MsSql.Comparer
{
    public class TriggerComparer : ComparerBase<Trigger>
    {
        public TriggerComparer(Trigger source)
            : base(source)
        {
            ResultBuilder = (source1, destination1) =>
                new TriggerCompareResult(source1, destination1);
        }
    }
}