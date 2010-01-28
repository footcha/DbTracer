using System;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class User : MsSqlSchemaBase
    {
        public User(ISchema parent)
            : base(parent, ObjectType1.User)
        {
        }

        public override string FullName
        {
            get { return "[" + Name + "]"; }
        }

        public string Login { get; set; }

        public bool Compare(User obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            return Login.Equals(obj.Login) && Owner.Equals(obj.Owner);
        }
    }
}