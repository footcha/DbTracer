namespace DbTracer.MsSql.Model
{
    public class PrimaryKeyConstraintMap : KeyConstraintMap<PrimaryKeyConstraint>
    {
        protected override SqlObjectType ObjectType
        {
            get { return SqlObjectType.PrimaryKeyConstraint; }
        }
    }
}