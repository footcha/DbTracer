using System.Collections.Generic;
using ConfOrm;
using ConfOrm.NH;

namespace DbTracer.MsSql.Model
{
    public class RoleMap
    {
        public void Configure(ObjectRelationalMapper orm, Mapper mapper, List<System.Type> entities)
        {
            mapper.Class<Role>(j =>
            {
                j.Schema("sys");
                j.Table("sysusers");
                j.Id(p => p.Id, m => m.Column("uid"));
                j.Property(p => p.Name, m => m.Column("name"));
                j.Property(p => p.IsLogin, m => m.Column("islogin"));
                j.Property(p => p.IsNtName, m => m.Column("isntname"));
                j.Property(p => p.IsNtGroup, m => m.Column("isntgroup"));
                j.Property(p => p.IsNtUser, m => m.Column("isntuser"));
                j.Property(p => p.IsSqlUser, m => m.Column("issqluser"));
                j.Property(p => p.IsAliased, m => m.Column("isaliased"));
                j.Property(p => p.IsSqlRole, m => m.Column("issqlrole"));
                j.Property(p => p.IsApplicationRole, m => m.Column("isapprole"));
            });

            orm.TablePerClass<Role>();
            entities.Add(typeof(Role));
        }

        //public RoleMap()
        //{
        //    Configure();
        //}

        //private void Configure()
        //{
        //    ReadOnly();
        //    Table("sys.sysusers");
        //    Id(p => p.Id, "uid");
        //    Map(p => p.Name, "name");
        //    Map(p => p.IsLogin, "islogin");
        //    Map(p => p.IsNtName, "isntname");
        //    Map(p => p.IsNtGroup, "isntgroup");
        //    Map(p => p.IsNtUser, "isntuser");
        //    Map(p => p.IsSqlUser, "issqluser");
        //    Map(p => p.IsAliased, "isaliased");
        //    Map(p => p.IsSqlRole, "issqlrole");
        //    Map(p => p.IsApplicationRole, "isapprole");
        //}
    }
}