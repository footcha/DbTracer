using FluentNHibernate.Mapping;

namespace DbTracer.MsSql.Model
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Configure();
        }

        private void Configure()
        {
            ReadOnly();
            Table("sys.sysusers");
            Id(p => p.Id, "uid");
            Map(p => p.Name, "name");
            Map(p => p.IsLogin, "islogin");
            Map(p => p.IsNtName, "isntname");
            Map(p => p.IsNtGroup, "isntgroup");
            Map(p => p.IsNtUser, "isntuser");
            Map(p => p.IsSqlUser, "issqluser");
            Map(p => p.IsAliased, "isaliased");
            Map(p => p.IsSqlRole, "issqlrole");
            Map(p => p.IsApplicationRole, "isapprole");
        }
    }
}