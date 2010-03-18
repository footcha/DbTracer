using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class Schema : ISqlObject, ISchema
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int PrincipalId { get; set; }
        
        public virtual User Principal { get; set; }

#pragma warning disable 659
        public override bool Equals(object that)
#pragma warning restore 659
        {
            return ModelUtils.Equals(this, that);
        }

        public override string ToString()
        {
            return ModelUtils.ToStringWithId(this);
        }
    }
}