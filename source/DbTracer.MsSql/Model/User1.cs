using System;
using DbTracer.Core.Schema.Model;

namespace DbTracer.MsSql.Model
{
    public class User1 : MsSqlSchemaBase
    {
        public User1(ISchema parent)
            : base(parent, ObjectType1.User)
        {
        }

        public override string FullName
        {
            get { return "[" + Name + "]"; }
        }

        public string Login { get; set; }

        public bool Compare(User1 obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            return Login.Equals(obj.Login) && Owner.Equals(obj.Owner);
        }
    }
}