using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class Role : ISqlObject
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual bool IsLogin { get; set; }

        public virtual bool IsNtName { get; set; }

        public virtual bool IsNtGroup { get; set; }

        public virtual bool IsNtUser { get; set; }

        public virtual bool IsSqlUser { get; set; }

        public virtual bool IsAliased { get; set; }

        public virtual bool IsSqlRole { get; set; }

        public virtual bool IsApplicationRole { get; set; }

        public virtual SqlObjectType Type { get; set; }

#pragma warning disable 659
        public override bool Equals(object that)
#pragma warning restore 659
        {
            return ModelUtils.Equals(this, that);
        }
    }
}