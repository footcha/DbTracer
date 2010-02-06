namespace DbTracer.MsSql.Model
{
    public class Schema : ISqlObject
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int PrincipalId { get; set; }

#pragma warning disable 659
        public override bool Equals(object that)
#pragma warning restore 659
        {
            if (ReferenceEquals(null, that)) return false;
            if (ReferenceEquals(this, that)) return true;
            if (Id == 0) return false;
            var thatSchema = that as Schema;
            return thatSchema != null && Equals(Id, thatSchema.Id);
        }
    }
}