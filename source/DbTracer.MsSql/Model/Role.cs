namespace DbTracer.MsSql.Model
{
    public class Role
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

        #region Equality

#pragma warning disable 659
        public override bool Equals(object that)
#pragma warning restore 659
        {
            if (ReferenceEquals(null, that)) return false;
            if (ReferenceEquals(this, that)) return true;
            if (Id == 0) return false;
            var thatRole = that as Role;
            return thatRole != null && Equals(thatRole.Id, Id);
        }

        #endregion
    }
}