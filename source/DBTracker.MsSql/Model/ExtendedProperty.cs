using System;
using DbTracker.Core.Schema.Model;

namespace DbTracker.MsSql.Model
{
    public class ExtendedProperty : MsSqlSchemaBase
    {
        public ExtendedProperty(ISchema parent)
            : base(parent, MsSql.ObjectType1.ExtendedProperty)
        { }

        public override string FullName
        {
            get
            {
                string normal = "[" + Level0Name + "]" + (String.IsNullOrEmpty(Level1Name) ? "" : ".[" + Level1Name + "]") + (String.IsNullOrEmpty(Level2Name) ? "" : ".[" + Level2Name + "]");
                if ((String.IsNullOrEmpty(Level1Type)) || (String.IsNullOrEmpty(Level2Type)))
                    return normal;
                if (!Level2Type.Equals("TRIGGER"))
                    return normal;
                return "[" + Level0Name + "].[" + Level2Name + "]";
            }
        }

        public string Level2Name { get; set; }

        public string Level2Type { get; set; }

        public string Level1Name { get; set; }

        public string Level1Type { get; set; }

        public string Level0Name { get; set; }

        public string Level0Type { get; set; }

        public string Value { get; set; }

        public override ObjectStatus Status { get; set; }
    }
}