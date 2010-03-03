namespace DbTracer.MsSql.Model
{
    public class UniqueKeyConstraintMap : KeyConstraintMap<UniqueKeyConstraint>
    {
        protected override SqlObjectType ObjectType
        {
            get { return SqlObjectType.UniqueConstraint; }
        }
    }
}